using UnityEngine;

public class Candle : EquippableObject
{
    public Vector3 RespawnPoint;



    private void OnCandleBurnedOut()
    {
        gameObject.transform.SetParent(null);
        gameObject.transform.position = RespawnPoint;
    }


    private void OnEnable()
    {
        CandleBurnDown.CandleBurnedOut += OnCandleBurnedOut;
    }

    private void OnDisable()
    {
        CandleBurnDown.CandleBurnedOut -= OnCandleBurnedOut;
    }


}
