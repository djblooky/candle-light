using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (INTHAZONE && ISLOOKING)
        {
            Invoke("DestroyTime", VanishTime);
        }

    }

    private bool INTHAZONE = false;
    private bool ISLOOKING = false;
    [SerializeField] private float VanishTime = 0.2f;

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        ISLOOKING = false;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        ISLOOKING = true;
    }

    void DestroyTime()
    {

        Destroy(gameObject);

    }

    private void inzone()
    {
        //Debug.Log("IN THA ZONE");
        INTHAZONE = true;

    }

    private void OnEnable()
    {
        TriggerTest.Jump1 += inzone;
    }

    private void OnDisable()
    {
        TriggerTest.Jump1 -= inzone;
    }

}
