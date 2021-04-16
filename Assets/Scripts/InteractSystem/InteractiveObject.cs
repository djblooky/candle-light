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

    private GameObject hoverIcon;

    private void Start()
    {
        StartMethod();
    }

    protected void StartMethod()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
        hoverIcon = GetComponentInChildren<HoverIcon>(true).gameObject;
        hoverIcon.SetActive(false);
        Debug.Log("Hover Icon got from child: " + hoverIcon);
    }

    protected virtual void OnHoveredOver(InteractiveObject i)
    {
        //Debug.Log("Hovered over " + objectName);
        if (hoverIcon != null)
            hoverIcon.SetActive(true);
    }

    protected virtual void OnHoveredOff()
    {
        //Debug.Log("Hovered off " + objectName);
        if(hoverIcon != null)
            hoverIcon.SetActive(false);
    }

    public virtual void Interact()
    {
        Debug.Log($"Interacted with {objectName}");
        hoverIcon.SetActive(false);
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
