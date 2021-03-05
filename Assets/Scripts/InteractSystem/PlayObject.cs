using UnityEngine;

public class PlayObject : InteractiveObject
{
    AudioSource audioData;

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);
        hoverText = "Play?";
    }

    public override void Interact()
    {
        base.Interact();
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}