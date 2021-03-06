﻿using UnityEngine;

public class PlayObject : InteractiveObject
{
    AudioSource audioData;

    private void Start()
    {
        InteractObjInit();
    }

    protected override void OnHoveredOver(InteractiveObject i)
    {
        base.OnHoveredOver(i);
        hoverText = "Play?";
    }

    public override void Interact(InteractiveObject i)
    {
        base.Interact(i);
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
}