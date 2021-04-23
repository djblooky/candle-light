using UnityEngine;

public class BurnableObject : InteractiveObject
{
    [Header("BurnableObject.cs")]
    [SerializeField] private GameObject gameObjectToDestroy;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private float spawnEffectTime = 1f;
    [SerializeField] protected AudioClip burnObject;
    [SerializeField] protected AudioSource burnAudioSource;

    private ParticleSystem ps;
    private bool isBurning = false;
    private Renderer _renderer;
    private int shaderProperty;
    private float timer = 0;

    private void Start()
    {
        burnAudioSource.GetComponent<AudioSource>();
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
                Destroy(gameObjectToDestroy,burnObject.length);
            }
        }
    }

    /*
    public override void Interact()
    {
        base.Interact();

        //BurnObject();
    }*/

    private void BurnObject()
    {
        tag = "Untagged";
        ps.Play();
        isBurning = true;
        burnAudioSource.PlayOneShot(burnObject);
    }

    private void OnEnable()
    {
        NoteSpawner.NoteSpawned += Init;

        if (gameObject.GetComponentInParent<Note>())
        {
            Note.ClosedNote += BurnObject;
        }      
    }

    private void OnDisable()
    {
        NoteSpawner.NoteSpawned -= Init;

        if (gameObject.GetComponentInParent<Note>())
        {
            Note.ClosedNote -= BurnObject;
        } 
    }
}
