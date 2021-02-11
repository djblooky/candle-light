using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEditor.Animations;

public class Candle_Movement_Listener : MonoBehaviour
{

    bool isMoving = false;
    public Animator AnimController;

    // Start is called before the first frame update
    void Start()
    {
        AnimController = GetComponent<Animator>();
        AnimController.SetBool("Is_Moving", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            AnimController.SetBool("Is_Moving", true);
        }
        else
        {
            AnimController.SetBool("Is_Moving", false);
        }

    }
}
