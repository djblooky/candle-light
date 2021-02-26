using System.Collections.Generic;
using UnityEngine;

public class Candle : EquippableObject
{
    public Vector3 RespawnPoint;

    Renderer[] renderers;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnCandleBurnedOut()
    {
        //unparent the candle from the player's hand and reset its position to spawn
        gameObject.transform.SetParent(null);
        gameObject.transform.position = RespawnPoint;
        gameObject.transform.localEulerAngles = Vector3.zero; 
        
        //hide candle until player has respawned
        foreach(Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }

    void OnRespawn()
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

    private void OnEnable()
    {
        CandleBurnDown.CandleBurnedOut += OnCandleBurnedOut;
        RespawnManager.RespawnTriggered += OnRespawn;
    }

    private void OnDisable()
    {
        CandleBurnDown.CandleBurnedOut -= OnCandleBurnedOut;
        RespawnManager.RespawnTriggered -= OnRespawn;
    }


}
