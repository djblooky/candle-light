﻿using UnityEngine;
using System;

public class BurnableObjectForDoor : InteractiveObject
{
    [Header("BurnableObjectForDoor.cs")]
    [SerializeField] private GameObject gameObjectToDestroy;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private float spawnEffectTime = 1f;

    private ParticleSystem ps;
    private bool isBurning = false;
    private Renderer _renderer;
    private int shaderProperty;
    private float timer = 0;
    //private int WhichOneIsBurning;
    public Material PhotoMat;
    public Material Disolve1Mat; 
    public Material CubeKeyMat;
    public Material Disolve2Mat; 
    public Material CubeKey2Mat;
    public Material Disolve3Mat;

    public static event Action Key1PlacedLockDrop;
    public static event Action Key2PlacedLockDrop;
    public static event Action Key3PlacedLockDrop;


    private void Start()
    {
        Init();    
    }

    private void Init()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();

        var main = ps.main;
        main.duration = spawnEffectTime;

        if (gameObjectToDestroy == null)
            gameObjectToDestroy = gameObject;

        if (gameObject.name == "Photo")
            _renderer.material = PhotoMat; 

        if (gameObject.name == "CubeKey")
            _renderer.material = CubeKeyMat; 

        if (gameObject.name == "CubeKey2")
            _renderer.material = CubeKey2Mat;


    }

    private void Update()
    {
        if (isBurning)
        {

            timer += Time.deltaTime;
            _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));

            if (timer > spawnEffectTime)
            {
                isBurning = false;
                Destroy(gameObjectToDestroy);
            }
        }
    }

    private void BurnObject1()
    {
        if (gameObject.name == "Family_Picture")
        {
            Key1PlacedLockDrop?.Invoke();
            Debug.Log("PHOTO TRIGGER BURNOBJECT()");
            //WhichOneIsBurning = 1;
            _renderer.material = Disolve1Mat;
            tag = "Untagged";
            ps.Play();
            isBurning = true;
            audioSource.Play();
        }
        
    }
    private void BurnObject2()
    {
        if (gameObject.name == "CubeKey")
        {
            Key2PlacedLockDrop?.Invoke();
            Debug.Log("CUBEKEY TRIGGER BURNOBJECT()");
            //WhichOneIsBurning = 2;
            _renderer.material = Disolve2Mat;
            tag = "Untagged";
            ps.Play();
            isBurning = true;
            audioSource.Play();
        }
        
    }
    private void BurnObject3()
    {
        if (gameObject.name == "CubeKey2")
        {
            Key3PlacedLockDrop?.Invoke();
            Debug.Log("CUBEKEY2 TRIGGER BURNOBJECT()");
            //WhichOneIsBurning = 3;
            _renderer.material = Disolve3Mat;
            tag = "Untagged";
            ps.Play();
            isBurning = true;
            audioSource.Play();
        }
        
    }

    private void OnEnable()
    {

        PlaceObjectTrigger.Key1Placed += BurnObject1;

        PlaceObjectTrigger.Key2Placed += BurnObject2;

        PlaceObjectTrigger.Key3Placed += BurnObject3;

        //NoteSpawner.NoteSpawned += Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote += BurnObject;

        //}      
    }

    private void OnDisable()
    {

        PlaceObjectTrigger.Key1Placed -= BurnObject1;

        PlaceObjectTrigger.Key2Placed -= BurnObject2;

        PlaceObjectTrigger.Key3Placed -= BurnObject3;

        //NoteSpawner.NoteSpawned -= Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote -= BurnObject;
        //} 
    }


}
