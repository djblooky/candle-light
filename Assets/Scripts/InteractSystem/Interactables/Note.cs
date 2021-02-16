using System;
using UnityEngine;

public class Note : InteractiveObject
{
    public static event Action<string, bool> OpenedNote;

    [SerializeField] bool showOverlayImage = false;

    [SerializeField]
    [TextArea(1,10)]
    private string noteText;

    public override void Interact()
    {
        OpenedNote?.Invoke(noteText, showOverlayImage);
        audioSource.Play();
    }
}
