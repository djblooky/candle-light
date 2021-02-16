using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager current;
    public GameObject leftHandEquipmentHolder, rightHandEquipmentHolder;
    public bool leftHandEquipped = false, rightHandEquipped = false;

    private float lerpDuration = 1f;
    private EquippableObject objectToEquip = null;
    private float lerpTimeElapsed = 0;

    private void Start()
    {
        current = this;
    }

    private void Update()
    {
        CheckForInteractWithEquippable();

        if (objectToEquip != null)
            MoveObjectToHand();
    }

    private void CheckForInteractWithEquippable()
    {
        if (Input.GetMouseButtonDown(0) && PlayerRaycast.objectLookingAt is EquippableObject)
        {
            if(!leftHandEquipped || !rightHandEquipped)
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
        }
        else //child to right hand
        {
            objectToEquip.transform.SetParent(leftHandEquipmentHolder.transform);
            leftHandEquipped = true;
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
}
