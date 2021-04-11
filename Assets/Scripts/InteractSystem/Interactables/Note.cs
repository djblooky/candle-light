using System;
using UnityEngine;

public class Note : InteractiveObject
{
    public bool IsOpen = false;
    public bool HasBeenRead = false;
    public static event Action<string, bool> OpenedNote;
    public static event Action ClosedNote, TutorialNoteRead;

    [SerializeField] private bool showOverlayImage = false;
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
            HasBeenRead = true;
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
            if (Input.anyKeyDown) //TODO: change to input axes to make rebindable
            {
                if (objectName == "TutorialNote")
                    TutorialNoteRead?.Invoke();

                ClosedNote?.Invoke();
                noteAudioSource.PlayOneShot(notePutDown);
                //noteAudioSource.PlayOneShot(burnNote);
                IsOpen = false;
            }
        }
    }
}
