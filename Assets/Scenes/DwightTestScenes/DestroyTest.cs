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
            if (gameObject.name == "mannequin_01")
                TriggerOnce = false;
            Invoke("DestroyTime", VanishTime);
        }

    }

    private bool INTHAZONE = false;
    private bool ISLOOKING = false;
    private bool TriggerOnce = true;
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

        //Destroy(gameObject);
        transform.localScale = new Vector3(0f,0f,0f);

    }

    private void inzone1()
    {

        if (gameObject.name == "mannequin_01" && TriggerOnce)
        {
            INTHAZONE = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
    private void inzone2()
    {

        if (gameObject.name == "mannequin_02")
        {
            INTHAZONE = true;
        }

    }
    private void inzone3()
    {

        if (gameObject.name == "mannequin_03")
        {
            INTHAZONE = true;
        }

    }
    private void inzoneCancel()
    {

            INTHAZONE = false;
        
    }

    private void OnEnable()
    {
        TriggerTest.Jump1 += inzone1;
        TriggerTest.Jump2 += inzone2;
        TriggerTest.Jump3 += inzone3;
        TriggerTest.JumpCancel += inzoneCancel;
        RespawnManager.RespawnTriggered += ResetTrigger;
    }

    private void OnDisable()
    {
        TriggerTest.Jump1 -= inzone1;
        TriggerTest.Jump2 -= inzone2;
        TriggerTest.Jump3 -= inzone3;
        TriggerTest.JumpCancel -= inzoneCancel;
        RespawnManager.RespawnTriggered -= ResetTrigger;
    }

    public void ResetTrigger()
    {

        ISLOOKING = false;
        INTHAZONE = false;
        transform.localScale = new Vector3(1f, 1f, 1f);

    }

}
