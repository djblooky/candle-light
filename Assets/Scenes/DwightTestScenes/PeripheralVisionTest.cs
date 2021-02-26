using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeripheralVisionTest : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Child = transform.Find("mannequin_01 (1)");
    }

    private Transform Child;
    private bool ISLOOKING = false;
    [SerializeField] private float VanishTime = 0.1f;

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        Debug.Log("invis");
        Child.localScale = new Vector3(0f, 0f, 0f);

    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        Debug.Log("VISIBLE");
        Child.localScale = new Vector3(2.71135f, 0.7335142f, 2.859676f);
        Invoke("VanishMode", VanishTime);

    }

    void VanishMode()
    {
        
        Debug.Log("VANISH");
        Child.localScale = new Vector3(0f,0f,0f);

    }

}
