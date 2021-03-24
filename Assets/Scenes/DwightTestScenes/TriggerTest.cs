using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerTest : MonoBehaviour
{

    public static event Action Jump1;
    public static event Action Jump2;
    public static event Action Jump3;
    public static event Action JumpCancel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.name == "ScareTriggerCube_1")
        {
            Jump1?.Invoke();
        }

        if (gameObject.name == "ScareTriggerCube_2")
        {
            Jump2?.Invoke();
        }

        if (gameObject.name == "ScareTriggerCube_3")
        {
            Jump3?.Invoke();
        }


    }

    private void OnTriggerExit(Collider other)
    {
        JumpCancel?.Invoke();
    }
}
