using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDropController : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Drop1()
    {

        if (gameObject.name == "Lock1")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    
    }

    private void OnEnable()
    {

        PlaceObjectTrigger.Key1Placed += Drop1;

        //NoteSpawner.NoteSpawned += Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote += BurnObject;

        //}      
    }

    private void OnDisable()
    {

        PlaceObjectTrigger.Key1Placed -= Drop1;

        //NoteSpawner.NoteSpawned -= Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote -= BurnObject;
        //} 
    }
}
