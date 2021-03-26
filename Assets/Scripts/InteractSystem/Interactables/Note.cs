using System;
using UnityEngine;

public class Note : InteractiveObject
{
    public bool IsOpen = false;
    public bool HasBeenRead = false;
    public static event Action<string, bool> OpenedNote;
    public static event Action ClosedNote;

    [SerializeField] bool showOverlayImage = false;
    [SerializeField] protected AudioClip notePickUp, notePutDown, burnNote;
    [SerializeField] protected AudioSource noteAudioSource;

    [SerializeField]
    [TextArea(1, 10)]
    private string noteText;

    private void Start()
    {
        noteAudioSource.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (!IsOpen)
        {
            OpenedNote?.Invoke(noteText, showOverlayImage);
            noteAudioSource.PlayOneShot(notePickUp);
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
                noteAudioSource.PlayOneShot(notePutDown);
                //noteAudioSource.PlayOneShot(burnNote);
                IsOpen = false;
            }
        }
    }
}
