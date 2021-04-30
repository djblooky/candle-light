using UnityEngine;
using System;

public class BurnableObjectForDoor : MonoBehaviour
{
    [Header("BurnableObjectForDoor.cs")]
    [SerializeField] private GameObject gameObjectToDestroy;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private float spawnEffectTime = 1f;
    [SerializeField] protected AudioSource audioSource;

    private ParticleSystem ps;
    private bool isBurning = false;
    private Renderer _renderer;
    private int shaderProperty;
    private float timer = 0;
    //private int WhichOneIsBurning;
    public Material PhotoMat;
    public Material Disolve1Mat;
    public Material CubeKeyMat1;
    public Material CubeKeyMat2;
    public Material Disolve2Mat;
    public Material CubeKey2Mat1;
    public Material CubeKey2Mat2;
    public Material Disolve3Mat;

    public static event Action Key1PlacedLockDrop;
    public static event Action Key2PlacedLockDrop;
    public static event Action Key3PlacedLockDrop;

    [SerializeField] protected AudioClip burnObject;


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

        if (gameObject.name == "Family_Picture")
            _renderer.material = PhotoMat; 

        if (gameObject.name == "Death_Cert")
        {
            _renderer.materials[0] = CubeKeyMat1;
            _renderer.materials[1] = CubeKeyMat2;
        }

        if (gameObject.name == "Ritual_Prop")
        {
            _renderer.materials[0] = CubeKey2Mat1;
            _renderer.materials[1] = CubeKey2Mat2;
        }


    }

    private void Update()
    {
        if (isBurning)
        {

            if (gameObject.name == "Family_Picture")
            {
                timer += Time.deltaTime;
                _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }
            if (gameObject.name == "Death_Cert")
            {
                timer += Time.deltaTime;
                _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }
            if (gameObject.name == "Ritual_Prop")
            {
                timer += Time.deltaTime;
                _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }

            if (timer > spawnEffectTime)
            {
                isBurning = false;
                Destroy(gameObjectToDestroy, .5f);
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
            audioSource.PlayOneShot(burnObject);
        }
        
    }
    private void BurnObject2()
    {
        if (gameObject.name == "Death_Cert")
        {
            Key2PlacedLockDrop?.Invoke();
            Debug.Log("Death_Cert TRIGGER BURNOBJECT()");
            //WhichOneIsBurning = 2;
            _renderer.material = Disolve2Mat;
            tag = "Untagged";
            ps.Play();
            isBurning = true;
            audioSource.PlayOneShot(burnObject);
        }
        
    }
    private void BurnObject3()
    {
        if (gameObject.name == "Ritual_Prop")
        {
            Key3PlacedLockDrop?.Invoke();
            Debug.Log("Ritual_Prop TRIGGER BURNOBJECT()");
            //WhichOneIsBurning = 3;
            _renderer.material = Disolve3Mat;
            tag = "Untagged";
            ps.Play();
            isBurning = true;
            audioSource.PlayOneShot(burnObject);
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
