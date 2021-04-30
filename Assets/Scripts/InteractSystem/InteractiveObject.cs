using UnityEngine;
using System;

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

    private InteractiveObject currentInteractiveObject;
    private GameObject hoverIcon;

    private void Start()
    {
        InteractObjInit();
    }

    protected void InteractObjInit()
    {
        hoverIcon = GetComponentInChildren<HoverIcon>(true).gameObject;
        if (hoverIcon != null) hoverIcon.SetActive(false);
        Debug.Log("Hover Icon: " + hoverIcon + " is a child of: " + gameObject);

        audioSource = audioSource.GetComponent<AudioSource>();
    }

    protected virtual void OnHoveredOver(InteractiveObject i)
    {
        Debug.Log("Hovered over " + i.objectName);
        if (i.hoverIcon != null)
            i.hoverIcon.SetActive(true);
    }

    protected virtual void OnHoveredOff(InteractiveObject i)
    {
        //Debug.Log("Hovered off " + i.objectName);
        if(i.hoverIcon != null)
            i.hoverIcon.SetActive(false);
    }

    public virtual void Interact(InteractiveObject i)
    {
        //audioSource.Play();
        //Debug.Log($"Interacted with {i.objectName}");
        if (i.hoverIcon != null) 
            i.hoverIcon.SetActive(false);
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
