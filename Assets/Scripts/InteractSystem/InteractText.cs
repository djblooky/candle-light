using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    private TMP_Text textComponent;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private void OnHoveredOverInteractable(InteractiveObject i)
    {
        if (i.displayTextOnHover)
        {
            textComponent.text = i.hoverText;
            canvasGroup.alpha = 1;
        }
    }

    private void OnHoveredOffInteractable()
    {
        canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        PlayerRaycast.HoveredOver += OnHoveredOverInteractable;
        PlayerRaycast.HoveredOff += OnHoveredOffInteractable;
    }

    private void OnDisable()
    {
        PlayerRaycast.HoveredOver -= OnHoveredOverInteractable;
        PlayerRaycast.HoveredOff -= OnHoveredOffInteractable;
    }
}
