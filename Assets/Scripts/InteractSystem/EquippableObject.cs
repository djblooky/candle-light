using UnityEngine;

public class EquippableObject : InteractiveObject
{
    [Header("EquippableObject.cs")]
    public Vector3 EquippedRotation, PlacedRotation;

    public override void Interact()
    {
        base.Interact();

    }


}
