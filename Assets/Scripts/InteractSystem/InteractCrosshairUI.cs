using UnityEngine;
using UnityEngine.UI;

public class InteractCrosshairUI : MonoBehaviour
{
    [SerializeField]
    private Sprite defaultCrosshair, examineCrosshair, handCrosshair, lookCrosshair;

    [SerializeField]
    private float defaultScale = 5, examineScale, handScale, lookScale;

    private Image image;
    private RectTransform rectTransform;

    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnHoveredOverInteractable(InteractiveObject mousedOver)
    {
        switch (mousedOver)
        {
            case Note n:
                image.sprite = examineCrosshair;
                SetScale(examineScale);
                break;
            case Toggleable t:
            case Openable o:
            case Key k:
                image.sprite = handCrosshair;
                SetScale(handScale);
                break;
            default:
                image.sprite = defaultCrosshair;
                SetScale(defaultScale);
                break;
        }
    }

    private void OnHoveredOffInteractable()
    {
        image.sprite = defaultCrosshair;
        SetScale(defaultScale);
    }

    private void SetScale(float f)
    {
        rectTransform.sizeDelta = new Vector2(f, f);
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
