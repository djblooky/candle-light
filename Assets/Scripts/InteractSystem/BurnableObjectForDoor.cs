using UnityEngine;
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
    public Material PhotoMat;
    public Material DisolveMat;

    public static event Action Key1PlacedLockDrop;


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

        _renderer.material = PhotoMat;

    }

    private void Update()
    {
        if (isBurning)
        {
            Debug.Log("PHOTO TRIGGER IS BURNING IN UPDATE");

            timer += Time.deltaTime;
            _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));

            if (timer > spawnEffectTime)
            {
                isBurning = false;
                Destroy(gameObjectToDestroy);
            }
        }
    }

    //public override void Interact()
    //{
    //    base.Interact();

    //    //BurnObject();
    //}



    private void BurnObject()
    {
        Key1PlacedLockDrop?.Invoke();
        Debug.Log("PHOTO TRIGGER BURNOBJECT()");
        _renderer.material = DisolveMat;
        tag = "Untagged";
        ps.Play();
        isBurning = true;
        audioSource.Play();
    }

    private void OnEnable()
    {

        PlaceObjectTrigger.Key1Placed += BurnObject;

        //NoteSpawner.NoteSpawned += Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote += BurnObject;

        //}      
    }

    private void OnDisable()
    {

        PlaceObjectTrigger.Key1Placed -= BurnObject;

        //NoteSpawner.NoteSpawned -= Init;

        //if (gameObject.GetComponentInParent<Note>())
        //{
        //    Note.ClosedNote -= BurnObject;
        //} 
    }


}
