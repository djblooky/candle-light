      using UnityEngine;

public class Candle : EquippableObject
{
    public Vector3 RespawnPoint = new Vector3(6.106f, 1f, -15.12936f);
    private Renderer[] renderers;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void OnCandleUnequipped()
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
        Debug.Log("Candle moved to respawn point and hidden");
    }

    public void OnRespawn()
    {
        
        tag = "InteractiveObject";

        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
        Debug.Log("Candle unhidden");
    }

    private void OnEnable()
    {
        EquipmentManager.CandleUnequipped += OnCandleUnequipped;
        RespawnManager.RespawnTriggered += OnRespawn;
    }

    private void OnDisable()
    {
        EquipmentManager.CandleUnequipped -= OnCandleUnequipped;
        RespawnManager.RespawnTriggered -= OnRespawn;
    }


}
