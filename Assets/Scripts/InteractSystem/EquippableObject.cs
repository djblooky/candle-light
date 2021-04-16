using UnityEngine;

public class EquippableObject : InteractiveObject
{
    [Header("EquippableObject.cs")]
    public Vector3 EquippedRotation, PlacedRotation;
    public float xPositionOffset = 0f, yPositionOffset = 0f, zPositionOffset = 0f;

    private void Start()
    {
        InteractObjInit();
        Debug.Log("EquippableObj start");
    }

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);

        if (EquipmentManager.current.leftHandEquipped)
            hoverText = "";
        else
            hoverText = "Pick up " + objectName + " ?";
    }
    /*
    public override void Interact()
    {
        base.Interact();
    }*/
}
