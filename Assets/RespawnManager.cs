using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public static event Action DeathReset;

    public static int DeathCount = 0;

    [SerializeField] GameObject playerController;

    [SerializeField] private float delayBeforeDeathAnim = 5f;
    [SerializeField] private float delayBeforeDeathReset = 2f;

    [SerializeField] private Vector3 RespawnPoint = new Vector3(4.86f, 0.25f, -13.58f);

    [SerializeField] private GameObject DeathMaskPointer;
    [SerializeField] private GameObject CandlePivotPointer;

    private CanvasGroup canvasGroup;
    private bool dyinganim = false;

    private void Start()
    {
        canvasGroup = DeathMaskPointer.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    private void FixedUpdate()
    {
        if (dyinganim)
        {
            canvasGroup.alpha += 0.005f;
            if (canvasGroup.alpha >= .95)
            {
                dyinganim = false;
                Invoke("ResetDeath", delayBeforeDeathReset);
            }
        }
    }

    private void TriggerDeath()
    {

        EquipmentManager.current.rightHandEquipped = false;

        CandlePivotPointer.transform.localScale = new Vector3(0f, 0f, 0f);

        //trigger audio que for pre-death

        Invoke("DeathAnimationAfterDelay", delayBeforeDeathAnim);

    }

    private void DeathAnimationAfterDelay()
    {
        dyinganim = true;
    }

    private void ResetDeath()
    {
        canvasGroup.alpha = 0f;
        dyinganim = false;
        DeathReset?.Invoke();


        gameObject.transform.position = RespawnPoint;
    }

    private void OnCandleBurnedOut()
    {
            TriggerDeath();
             DeathCount++;
    }

    private void OnEnable()
    {
        CandleBurnDown.CandleBurnedOut += OnCandleBurnedOut;
    }

    private void OnDisable()
    {
        CandleBurnDown.CandleBurnedOut -= OnCandleBurnedOut;
    }
}
