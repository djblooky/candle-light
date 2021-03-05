using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterZoneTriggerController : MonoBehaviour
{

    private bool isActive = true;
    [SerializeField] private Transform Child1;
    [SerializeField] private Transform Child2;
    [SerializeField] private Transform Child3;

    [SerializeField] private BoxCollider Child1_C;
    [SerializeField] private BoxCollider Child2_C;
    [SerializeField] private BoxCollider Child3_C;


    // Start is called before the first frame update
    void Start()
    {
        Child1 = transform.Find("Wall_1");
        Child2 = transform.Find("Wall_2");
        Child3 = transform.Find("Wall_3");

        Child1_C = Child1.GetComponent<BoxCollider>();
        Child2_C = Child2.GetComponent<BoxCollider>();
        Child3_C = Child3.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isActive)
        {
            // QUEUE AUDIO HERE//////////////////////////////////////////////////////////////////////&& other.gameObject.CompareTag("Player")
            Debug.Log("AUDIO = GO BACK YOU ARE LEAVING STARTING ZONE");
        }

    }

    public void ResetTrigger()
    {

        isActive = true;

        Child1_C.enabled = true;
        Child2_C.enabled = true;
        Child3_C.enabled = true;

    }

    private void OnEnable()
    {

        InteractiveObject.CandlePickedUp += CandleUp;
        RespawnManager.RespawnTriggered += ResetTrigger;

    }

    private void OnDisable()
    {

        InteractiveObject.CandlePickedUp -= CandleUp;
        RespawnManager.RespawnTriggered -= ResetTrigger;

    }

    public void CandleUp()
    {
        //Debug.Log("CANDLEUP!");
        isActive = false;

        Child1_C.enabled = false;
        Child2_C.enabled = false;
        Child3_C.enabled = false;

        // PLAY VO AUDIO HERE

    }

}
