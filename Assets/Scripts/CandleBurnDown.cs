﻿using System;
using UnityEngine;

public class CandleBurnDown : MonoBehaviour
{
    public static event Action CandleBurnedOut;

    [Tooltip("When set to false, the candle will stay lit infinitely")]
    [SerializeField] private bool candleCanBurnDown = true;

    [SerializeField] private bool addToCandleDurationAfterRespawn;

    [SerializeField] private float CandleScale = 1f;
    [SerializeField] private float BurnDurationSeconds = 300f;
    [SerializeField] private float BurnSecondsRemaining;
    [SerializeField] private GameObject CandlePivotPointer;
    public static event Action CandlePickedUp;
    [SerializeField] private bool AlreadyCalled = false;
    public bool InZoneTime = false;

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

        if (BurnSecondsRemaining > 85)
        {
            AkSoundEngine.SetState("Music_Switch", "Game_Start");
        }

        if (BurnSecondsRemaining <= 84.5f && BurnSecondsRemaining > 83.5)
        {
            AkSoundEngine.SetState("Music_Switch", "Candle_RunningOut");
            
        }

        if (BurnSecondsRemaining < BurnDurationSeconds && !AlreadyCalled)
        {
            CandlePickedUp?.Invoke();
            AlreadyCalled = true;
        }

        if (InZoneTime && BurnSecondsRemaining <= 150)
        {
            BurnSecondsRemaining = BurnSecondsRemaining + .1f; /////////////////////////////// CANDLE UP
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

        AlreadyCalled = false;

        // EquipmentManager.current.rightHandEquipped = false;
        //TODO: equiptment manager unequip candle
    }

    public void MakeCandleUp()
    {

        InZoneTime = true;

    }
    public void MakeCandleResume()
    {

        InZoneTime = false;

    }

    private void OnEnable()
    {
        RespawnManager.RespawnTriggered += ResetCandle;
        CandleUP.InZone += MakeCandleUp;
        CandleUP.OutZone += MakeCandleResume;
    }

    private void OnDisable()
    {
        RespawnManager.RespawnTriggered -= ResetCandle;
        CandleUP.OutZone -= MakeCandleResume;

    }
}
