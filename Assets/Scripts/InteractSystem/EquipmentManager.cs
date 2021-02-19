using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static event Action ObjectPlaced, CandlePickedUp;

    public static EquipmentManager current;
    public GameObject leftHandEquipmentHolder, rightHandEquipmentHolder;
    public bool leftHandEquipped = false, rightHandEquipped = false;
    public EquippableObject currentLeftObject, currentRightObject;

    private float lerpDuration = 1f;
    private float lerpTimeElapsed = 0;
    private EquippableObject objectToEquip = null, objectToPlace = null;
    private PlaceObjectTrigger nextSpotToPlace;

    private void Start()
    {
        current = this;
    }

    private void Update()
    {
        CheckForInteractWithEquippable();

        if (objectToEquip != null)
            MoveObjectToHand();

        CheckForInteractWithPlaceObjectTrigger();

        if (objectToPlace != null)
            MoveObjectToPlace();
    }

    private void CheckForInteractWithPlaceObjectTrigger()
    {
        if (Input.GetMouseButtonDown(0) && PlayerRaycast.objectLookingAt is PlaceObjectTrigger)
        {
            if (PlaceObjectTrigger.IsEmpty && leftHandEquipped)
            {
                nextSpotToPlace = PlayerRaycast.objectLookingAt as PlaceObjectTrigger;
                objectToPlace = currentLeftObject;
                objectToPlace.tag = "Untagged"; //no longer interactive
                nextSpotToPlace.tag = "Untagged";
            }
        }
    }

    private void MoveObjectToPlace()
    {
        objectToPlace.transform.position = Vector3.Lerp(objectToPlace.transform.position, nextSpotToPlace.transform.position, lerpTimeElapsed / lerpDuration);

        lerpTimeElapsed += Time.deltaTime;

        if (lerpTimeElapsed >= lerpDuration - 0.7) //once it's done lerping
        {
            ObjectPlaced?.Invoke(); //TODO: remove this and create invoke an event when the lock flames are lit instead
            UnequipObject();
            lerpTimeElapsed = 0;
        }
    }

    private void CheckForInteractWithEquippable()
    {
        if (Input.GetMouseButtonDown(0) && PlayerRaycast.objectLookingAt is EquippableObject)
        {
            if (!leftHandEquipped || !rightHandEquipped)
                objectToEquip = PlayerRaycast.objectLookingAt as EquippableObject;
        }
    }

    private void MoveObjectToHand()
    {
        if (objectToEquip is Candle) //move to right hand
        {
            objectToEquip.transform.position = Vector3.Lerp(objectToEquip.transform.position, rightHandEquipmentHolder.transform.position, lerpTimeElapsed / lerpDuration);
        }
        else //move to left hand
        {
            objectToEquip.transform.position = Vector3.Lerp(objectToEquip.transform.position, leftHandEquipmentHolder.transform.position, lerpTimeElapsed / lerpDuration);
        }

        lerpTimeElapsed += Time.deltaTime;

        if (lerpTimeElapsed >= lerpDuration - 0.7) //once it's done lerping
        {
            EquipNewObject();
            lerpTimeElapsed = 0;
        }
    }

    private void EquipNewObject()
    {
        if (objectToEquip is Candle) //child to left hand
        {
            objectToEquip.transform.SetParent(rightHandEquipmentHolder.transform);
            rightHandEquipped = true;
            currentRightObject = objectToEquip;
            CandlePickedUp?.Invoke();
        }
        else //child to right hand
        {
            objectToEquip.transform.SetParent(leftHandEquipmentHolder.transform);
            leftHandEquipped = true;
            currentLeftObject = objectToEquip;
        }

        objectToEquip.gameObject.layer = 8; //set to equipment layer
        foreach (Transform t in objectToEquip.GetComponentsInChildren<Transform>()) //set children of the object to equipment layer
        {
            t.gameObject.layer = 8;
        }

        objectToEquip.transform.localPosition = Vector3.zero;
        objectToEquip.transform.localEulerAngles = objectToEquip.EquippedRotation;

        objectToEquip = null;
    }

    private void UnequipObject()
    {
        objectToPlace.transform.SetParent(nextSpotToPlace.transform);
        leftHandEquipped = false;
        currentLeftObject = null;

        objectToPlace.gameObject.layer = 0; //set to equipment layer
        foreach (Transform t in objectToPlace.GetComponentsInChildren<Transform>()) //set children of the object to equipment layer
        {
            t.gameObject.layer = 0;
        }

        objectToPlace.transform.localPosition = Vector3.zero;
        objectToPlace.transform.localEulerAngles = objectToPlace.PlacedRotation;

        objectToPlace = null;
        nextSpotToPlace = null;
    }
}
