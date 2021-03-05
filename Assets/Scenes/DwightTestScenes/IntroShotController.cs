using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroShotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SwitchScenes", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchScenes()
    {

        SceneManager.LoadScene("Prototype V2");
    
    }
}
