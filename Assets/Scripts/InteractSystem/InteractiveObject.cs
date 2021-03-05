using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [Header("InteractiveObject.cs")]
    public bool displayTextOnHover = true;
    public string objectName;

    [Tooltip("The currently displayed hover text")]
    public string hoverText;

    [SerializeField] protected AudioSource audioSource;

    [SerializeField]
    protected AudioClip ragtimeMusic;

    private void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
    }

    protected virtual void OnHoveredOver(InteractiveObject i)
    {
        //Debug.Log("Hovered over " + i);
    }

    protected virtual void OnHoveredOff()
    {
        
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacted with {objectName}");
    }

    private void OnEnable()
    {
        PlayerRaycast.HoveredOver += OnHoveredOver;
        PlayerRaycast.HoveredOff += OnHoveredOff;
    }

    private void OnDisable()
    {
        PlayerRaycast.HoveredOver -= OnHoveredOver;
        PlayerRaycast.HoveredOff -= OnHoveredOff;
    }

}
