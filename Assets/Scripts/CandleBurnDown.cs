using System;
using UnityEngine;

public class CandleBurnDown : MonoBehaviour
{
    public static event Action CandleBurnedOut;

    [SerializeField] private bool addToCandleDurationAfterRespawn;

    [SerializeField] private float CandleScale = 1f;
    [SerializeField] private float BurnDurationSeconds = 300f;
    [SerializeField] private float BurnSecondsRemaining;
    [SerializeField] private GameObject CandlePivotPointer;

    private void Start()
    {
        BurnSecondsRemaining = BurnDurationSeconds;
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && CandleScale > 0f && EquipmentManager.current.rightHandEquipped)
        {
            BurnSecondsRemaining -= 2 * Time.deltaTime;
        }
        else if (CandleScale > 0f && EquipmentManager.current.rightHandEquipped)
        {
            BurnSecondsRemaining -= 1 * Time.deltaTime;
        }

        CandleScale = BurnSecondsRemaining / BurnDurationSeconds;

        CandlePivotPointer.transform.localScale = new Vector3(1f, CandleScale, 1f);

        if (CandleScale <= 0.1f && EquipmentManager.current.rightHandEquipped)
        {
            CandleBurnedOut?.Invoke();
            //ResetCandle()
        }
    }

    public void ResetCandle()
    {
        if (addToCandleDurationAfterRespawn)
            BurnSecondsRemaining = BurnDurationSeconds + (RespawnManager.DeathCount * 10); //TODO: remove magic number
        else
            BurnSecondsRemaining = BurnDurationSeconds;

        BurnDurationSeconds = BurnSecondsRemaining;
        CandleScale = 1;

        
       // EquipmentManager.current.rightHandEquipped = false;
        //TODO: equiptment manager unequip candle
    }

    private void OnEnable()
    {
        RespawnManager.DeathReset += ResetCandle;
    }

    private void OnDisable()
    {
        RespawnManager.DeathReset -= ResetCandle;
    }
}
