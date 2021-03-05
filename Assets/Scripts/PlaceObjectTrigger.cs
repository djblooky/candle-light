using System;
using UnityEngine;

public class PlaceObjectTrigger : InteractiveObject
{
    public static event Action PiecePlaced;

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

    public override void Interact()
    {
        base.Interact();

        if (EquipmentManager.current.leftHandEquipped && EquipmentManager.current.currentLeftObject.objectName == fitsPieceWithName)
        {
            IsEmpty = false;
            PiecePlaced?.Invoke();
        }
    }
}
