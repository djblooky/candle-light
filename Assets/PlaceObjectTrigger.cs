using UnityEngine;

public class PlaceObjectTrigger : InteractiveObject
{
    public static bool IsEmpty = true;

    private void Start()
    {

    }

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if(EquipmentManager.current.leftHandEquipped)
            hoverText = "place " + EquipmentManager.current.currentLeftObject.name + "?"; //can also use name from InteractiveObject component instead
    }

    public override void Interact()
    {
        base.Interact();
    }

}
