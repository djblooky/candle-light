using UnityEngine;

public class BurnableObject : InteractiveObject
{
    [Header("BurnableObject.cs")]
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private float spawnEffectTime = 1f;

    private ParticleSystem ps;
    private bool isBurning = false;
    private Renderer _renderer;
    private int shaderProperty;
    private float timer = 0;

    private void Start()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren<ParticleSystem>();

        var main = ps.main;
        main.duration = spawnEffectTime;
    }

    private void Update()
    {
        if (isBurning)
        {
            timer += Time.deltaTime;
            _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer)));
        }
       
    }

    public override void Interact()
    {
        base.Interact();

        BurnObject();
        
    }



    private void BurnObject()
    {
        ps.Play();
        isBurning = true;
    }

    private void OnEnable()
    {
        //TODO: add object burning from other sources
    }

    private void OnDisable()
    {

    }


}
