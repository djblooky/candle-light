using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
    public GameObject pause;
    public bool check = true;
    public GameObject playerCon;
    public RushCharacterController Rcc;
    public GameObject IntroNote;
    private Note NoteCheck;
    private bool NoteBool;
    
    void Start()
    {

        Rcc = playerCon.GetComponent<RushCharacterController>();

        NoteCheck = IntroNote.GetComponent<Note>();
    
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (check == false) && !NoteBool)
        {
            OpenPauseMenu();
            Debug.Log("tick on ");
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (check == true) && !NoteBool)
        {
            ClosePauseMenu();
            Debug.Log("tick off");
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (check == false) && NoteBool)
        {
            NoteBool = false;
        }

        if (NoteCheck.IsOpen)
        {
            NoteBool = true;
        }
        else
        {
            Invoke("SetNote", 1f);
        }

    }

    private void SetNote()
    {

        NoteBool = false;

    }

    public void OpenPauseMenu()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Rcc.lockCamera = true;
        Rcc.cursorManagement = false;
        Cursor.visible = true; //Cursor is hidden.
        Cursor.lockState = CursorLockMode.None; //Cursor is locked.
        check = true;
    }

    public void ClosePauseMenu()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        Rcc.lockCamera = false;
        Cursor.visible = false; //Cursor is hidden.
        Cursor.lockState = CursorLockMode.Locked; //Cursor is locked.
        check = false;
        Rcc.cursorManagement = true;

    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);

    }

}
