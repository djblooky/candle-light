using System;
using UnityEngine;

public class Note : InteractiveObject
{
    public bool IsOpen = false;
    public static event Action<string, bool> OpenedNote;
    public static event Action ClosedNote;

    [SerializeField] bool showOverlayImage = false;

    [SerializeField]
    [TextArea(1,10)]
    private string noteText;

    public override void Interact()
    {
        if (!IsOpen)
        {
            OpenedNote?.Invoke(noteText, showOverlayImage);
            audioSource.Play();
            IsOpen = true;
            hoverText = "";
        }
        
    }

    private void Update()
    {
        if (IsOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)) //TODO: change to input axes to make rebindable
            {
                ClosedNote?.Invoke();
                audioSource.Play();
                IsOpen = false;
            }
        }
    }
}
