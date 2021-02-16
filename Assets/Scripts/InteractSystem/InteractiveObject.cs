using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [Header("Interactable.cs")]
    public bool displayTextOnHover = true;
    public string hoverText;

    [SerializeField] protected string objectName;
    [SerializeField] protected AudioSource audioSource;

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
