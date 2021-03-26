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

    void Start()
    {

        Rcc = playerCon.GetComponent<RushCharacterController>();
    
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (check == false))
        {
            OpenPauseMenu();
            Debug.Log("tick on ");
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (check == true))
        {
            ClosePauseMenu();
            Debug.Log("tick off");
        }
    }

    public void OpenPauseMenu()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        Rcc.lockCamera = true;
        check = true;
    }

    public void ClosePauseMenu()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        Rcc.lockCamera = false;
        check = false;

    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);

    }

}
