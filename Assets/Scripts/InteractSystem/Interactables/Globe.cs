﻿using System.Collections;
using UnityEngine;

public class Globe : Openable
{
    [SerializeField] Door doorToUnlock;
    [SerializeField] GameObject keyItemInside;
    [SerializeField] protected AudioSource globeAudioSource;
    [SerializeField] protected AudioClip globeUnlock;


    private int piecesRemaining = 3;

    private void Start()
    {
        isLocked = true;
    }

    private void OnPiecePlaced()
    {
        Debug.Log("Piece Placed");
        piecesRemaining--;
        //play SFX
        CheckForUnlockedDoor();
    }

    private void CheckForUnlockedDoor()
    {
        if (piecesRemaining <= 0)
        {
           
            isLocked = false;
            Debug.Log("Globe opened");
            IsOpen = true;
            StartCoroutine(MakeKeyItemInteractable());
            doorToUnlock.isLocked = false; 
            //globeAudioSource = doorToUnlock.GetComponents<AudioSource>();
            globeAudioSource.PlayOneShot(globeUnlock);
        }
    }

    IEnumerator MakeKeyItemInteractable()
    {
        yield return new WaitForSeconds(1); //TODO: change to length of open animation
        keyItemInside.tag = "InteractiveObject";
    }

    private void OnEnable()
    {
        EquipmentManager.ObjectPlaced += OnPiecePlaced;
    }

    private void OnDisable()
    {
        EquipmentManager.ObjectPlaced -= OnPiecePlaced;
    }
}
