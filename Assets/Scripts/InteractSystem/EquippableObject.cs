using UnityEngine;

public class EquippableObject : InteractiveObject
{
    [Header("EquippableObject.cs")]
    public Vector3 EquippedRotation, PlacedRotation;
    public float yPositionOffset = 0f;

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if (EquipmentManager.current.leftHandEquipped)
            hoverText = "";
        else
            hoverText = "Pick up " + objectName + " ?";
    }

    public override void Interact()
    {
        base.Interact();

    }
}
