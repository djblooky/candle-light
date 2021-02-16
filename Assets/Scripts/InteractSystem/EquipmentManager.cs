using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager current;

    [Header("")]
    public GameObject leftHandEquipmentHolder, rightHandEquipmentHolder;

    public float equipSpeed = 2f;

    [HideInInspector] public int equippedIndex;
    [HideInInspector] public bool holdingEquipment = false;


    private void Start()
    {
        current = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerRaycast.objectLookingAt is EquippableObject) 
        {
            EquippableObject objectToEquip = PlayerRaycast.objectLookingAt as EquippableObject;

            //check if hand is empty
            if (PlayerRaycast.objectLookingAt is Candle) //equip to right hand
            {
                objectToEquip.transform.position = Vector3.Lerp(objectToEquip.transform.position, rightHandEquipmentHolder.transform.position, Time.deltaTime * equipSpeed);
            }
            else //equip to left hand
            {
                objectToEquip.transform.position = Vector3.Lerp(objectToEquip.transform.position, leftHandEquipmentHolder.transform.position, Time.deltaTime * equipSpeed);
            }


        }
    }




}
