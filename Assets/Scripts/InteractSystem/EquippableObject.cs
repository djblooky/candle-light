using UnityEngine;

public class EquippableObject : InteractiveObject
{
    [Header("EquippableObject.cs")]
    public Vector3 EquippedRotation, PlacedRotation;

    [SerializeField] private string pickUpObjectText;

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if (EquipmentManager.current.leftHandEquipped)
            hoverText = "";
        else
            hoverText = pickUpObjectText;
    }

    public override void Interact()
    {
        base.Interact();

    }


}
