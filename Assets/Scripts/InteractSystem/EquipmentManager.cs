using System;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static event Action ObjectPlaced, CandlePickedUp, CandleUnequipped;

    public static EquipmentManager current;
    public GameObject leftHandEquipmentHolder, rightHandEquipmentHolder;
    public bool leftHandEquipped = false, rightHandEquipped = false;
    public EquippableObject currentLeftObject, currentRightObject;

    private float lerpDuration = 1f;
    private float lerpTimeElapsed = 0;
    private EquippableObject objectToEquip = null, objectToUnequip = null;
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

        if (objectToUnequip != null)
            MoveObjectToPlace();
    }

    private void CheckForInteractWithPlaceObjectTrigger()
    {
        if (Input.GetMouseButtonDown(0) && PlayerRaycast.objectLookingAt is PlaceObjectTrigger)
        {
            nextSpotToPlace = PlayerRaycast.objectLookingAt as PlaceObjectTrigger;

            if (PlaceObjectTrigger.IsEmpty && leftHandEquipped )
            {
                if(current.currentLeftObject.objectName == nextSpotToPlace.fitsPieceWithName)
                {
                    objectToUnequip = currentLeftObject;
                    objectToUnequip.tag = "Untagged"; //no longer interactive
                    nextSpotToPlace.tag = "Untagged";
                }
                else nextSpotToPlace = null;

            }
        }
    }

    private void MoveObjectToPlace()
    {
        objectToUnequip.transform.position = Vector3.Lerp(objectToUnequip.transform.position, nextSpotToPlace.transform.position, lerpTimeElapsed / lerpDuration);

        lerpTimeElapsed += Time.deltaTime;

        if (lerpTimeElapsed >= lerpDuration - 0.7) //once it's done lerping
        {
            if (objectToUnequip.name == "Family_Picture" || objectToUnequip.name == "Death_Cert" || objectToUnequip.name == "Ritual_Prop")
            {
                //
            }
            else
            {
                ObjectPlaced?.Invoke(); //TODO: remove this and create invoke an event when the lock flames are lit instead
            }
            objectToUnequip.transform.SetParent(nextSpotToPlace.transform);
            UnequipObject(0, true);
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

        objectToEquip.transform.localPosition = new Vector3(0 + objectToEquip.xPositionOffset, 0 + objectToEquip.yPositionOffset,0 + objectToEquip.zPositionOffset);
        objectToEquip.transform.localEulerAngles = objectToEquip.EquippedRotation;

        objectToEquip = null;
    }

    private void UnequipObject(int layer, bool leftHand)
    {
        if (leftHand)
        {
            leftHandEquipped = false;
            currentLeftObject = null;
        }
        else
        {
            rightHandEquipped = false;
            currentRightObject = null;
        }

        objectToUnequip.gameObject.layer = layer; //set to default layer or ignore multiraycast layer
        foreach (Transform t in objectToUnequip.GetComponentsInChildren<Transform>()) //set children of the object to equipment layer
        {
            t.gameObject.layer = layer;
        }
       
         objectToUnequip.transform.localPosition = Vector3.zero;
         objectToUnequip.transform.localEulerAngles = objectToUnequip.PlacedRotation;

        if(objectToUnequip is Candle)
        {
            CandleUnequipped?.Invoke();
        }
       
        objectToUnequip = null;
        nextSpotToPlace = null;
    }

    private void OnCandleBurnedOut()
    {
        //unequip candle
        objectToUnequip = currentRightObject;
        UnequipObject(9, false);
    }

    private void OnEnable()
    {
        CandleBurnDown.CandleBurnedOut += OnCandleBurnedOut;
    }

    private void OnDisable()
    {
        CandleBurnDown.CandleBurnedOut -= OnCandleBurnedOut;
    }
}
