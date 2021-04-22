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

        Debug.Log("LOCKDROP1MAIN");

        Invoke("Drop1Delay", 0.1f);
        
        if (gameObject.name == "1BottomHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }

    private void Drop1Delay()
    {

        Debug.Log("LOCKDROP1DELAY");

        if (gameObject.name == "1TopHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }

    private void OnEnable()
    {

        BurnableObjectForDoor.Key1PlacedLockDrop += Drop1;

        //NoteSpawner.NoteSpawned += Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote += BurnObject;

        //}      
    }

    private void OnDisable()
    {

        BurnableObjectForDoor.Key1PlacedLockDrop -= Drop1;

        //NoteSpawner.NoteSpawned -= Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote -= BurnObject;
        //} 
    }
}
