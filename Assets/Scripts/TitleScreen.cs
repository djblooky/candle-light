using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    [SerializeField] protected AudioSource menuAudioSource;
    [SerializeField] protected AudioClip gameStart, menuSelect, mouseOver, gameQuit;
    // Start is called before the first frame update
    void Start()
    {
        menuAudioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        menuAudioSource.PlayOneShot(gameStart);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        menuAudioSource.PlayOneShot(gameQuit);
        Application.Quit();
        Debug.Log("We outta here.");
    }
}
