using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDropController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] protected AudioClip lockDrop;
    [SerializeField] protected AudioSource lockAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        lockAudioSource = lockAudioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Drop1()
    {

        //Debug.Log("LOCKDROP1MAIN");

        Invoke("Drop1Delay", 0.1f);

        if (gameObject.name == "1BottomHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            //lockAudioSource.PlayOneShot(lockDrop);
        }

    }
    private void Drop2()
    {

        //Debug.Log("LOCKDROP2MAIN");

        Invoke("Drop2Delay", 0.1f);

        if (gameObject.name == "2BottomHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }
    private void Drop3()
    {

        //Debug.Log("LOCKDROP3MAIN");

        Invoke("Drop3Delay", 0.1f);

        if (gameObject.name == "3BottomHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }

    private void Drop1Delay()
    {

        //Debug.Log("LOCKDROP1DELAY");

        if (gameObject.name == "1TopHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }
    private void Drop2Delay()
    {

        //Debug.Log("LOCKDROP2DELAY");

        if (gameObject.name == "2TopHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }
    private void Drop3Delay()
    {

        //Debug.Log("LOCKDROP3DELAY");

        if (gameObject.name == "3TopHalf")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }

    }

    private void OnEnable()
    {

        BurnableObjectForDoor.Key1PlacedLockDrop += Drop1;

        BurnableObjectForDoor.Key2PlacedLockDrop += Drop2;

        BurnableObjectForDoor.Key3PlacedLockDrop += Drop3;

        //NoteSpawner.NoteSpawned += Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote += BurnObject;

        //}      
    }

    private void OnDisable()
    {

        BurnableObjectForDoor.Key1PlacedLockDrop -= Drop1;

        BurnableObjectForDoor.Key2PlacedLockDrop -= Drop2;

        BurnableObjectForDoor.Key3PlacedLockDrop -= Drop3;

        //NoteSpawner.NoteSpawned -= Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote -= BurnObject;
        //} 
    }
}
