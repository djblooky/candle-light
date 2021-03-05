using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    
    [SerializeField] private Image paperTexture, noteOverlayImage;
    [SerializeField] private TMP_Text noteText;

    private RushCharacterController player;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RushCharacterController>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    private void OnOpenedNote(string text, bool showOverlayImage)
    {
        if(showOverlayImage){
            noteOverlayImage.enabled = true;
        }
        else
            noteOverlayImage.enabled = false;

        player.lockMovement = true;
        player.lockCamera = true;
        
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;

        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        noteText.text = text;
    }

    public void OnClosedNote()
    {
        player.lockMovement = false;
        player.lockCamera = false;

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        Note.OpenedNote += OnOpenedNote;
        Note.ClosedNote += OnClosedNote;
    }

    private void OnDisable()
    {
        Note.OpenedNote -= OnOpenedNote;
        Note.ClosedNote -= OnClosedNote;
    }
}
