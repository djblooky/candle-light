using System;
using UnityEngine;

public class PlaceObjectTrigger : InteractiveObject
{
    public static event Action PiecePlaced;
    public static event Action Key1Placed;
    public static event Action Key2Placed;
    public static event Action Key3Placed;

    public static bool IsEmpty = true;

    [Tooltip("This name must match the object's name for it to fit correctly")]
    [SerializeField] public string fitsPieceWithName;

    private void Start()
    {

    }

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if (EquipmentManager.current.leftHandEquipped && EquipmentManager.current.currentLeftObject.objectName == fitsPieceWithName)
        {
            hoverText = "Place " + EquipmentManager.current.currentLeftObject.objectName + "?";
        }
        else
        {
            hoverText = "";
        }
          
    }

    public override void Interact(InteractiveObject i)
    {
        base.Interact(i);

        if (EquipmentManager.current.leftHandEquipped && EquipmentManager.current.currentLeftObject.objectName == fitsPieceWithName)
        {
            //IsEmpty = false;
            //if (EquipmentManager.current.currentLeftObject.objectName == "Family_Picture" || EquipmentManager.current.currentLeftObject.objectName == "Death_Cert" || EquipmentManager.current.currentLeftObject.objectName == "Ritual_Prop")
            //{
            //    //
            //}
            //else
            //{
            //    PiecePlaced?.Invoke();
            //}

            PiecePlaced?.Invoke();

            // DOOR ZONE

            if (EquipmentManager.current.currentLeftObject.objectName == "Family_Picture")
            {
                Key1Placed?.Invoke();
            }
            if (EquipmentManager.current.currentLeftObject.objectName == "Death_Cert")
            {
                Key2Placed?.Invoke();
            }
            if (EquipmentManager.current.currentLeftObject.objectName == "Ritual_Prop")
            {
                Key3Placed?.Invoke();
            }

            // DOOR ZONE

        }
    }
}
