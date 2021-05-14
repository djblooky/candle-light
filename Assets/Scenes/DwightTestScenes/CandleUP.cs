using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CandleUP : MonoBehaviour
{

    public static event Action InZone;
    public static event Action OutZone;
    public bool InZoneToggle;


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

        if (other.CompareTag("Player"))
        {
            InZone?.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OutZone?.Invoke();
        }
    }
}
