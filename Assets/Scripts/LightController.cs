using Aura2API;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("Candle On Lighting Settings")]
    [SerializeField] private float candleOnLightingDensity = 5f;
    [SerializeField] private float candleOnAmbientLightingStrength = 0f;

    [Header("Candle Off Lighting Settings")]
    [SerializeField] private float candleOffLightingDensity = 0.25f;
    [SerializeField] private float candleOffAmbientLightingStrength = 0.9f;

    [Header("Components")]
    [SerializeField] private GameObject candleSpotLight, shadowPointLight;
    [SerializeField] private AuraQualitySettings auraQualitySettings;
    [SerializeField] private AuraBaseSettings auraBaseSettings;

    private void Start()
    {
        OnSpawn();
    }

    void OnSpawn()
    {
        shadowPointLight.SetActive(false);
        candleSpotLight.SetActive(false);
        auraQualitySettings.displayVolumetricLightingBuffer = false;
        auraBaseSettings.density = 20f;
        auraBaseSettings.ambientLightingStrength = candleOnAmbientLightingStrength;
    }

    private void OnCandlePickedUp()
    {
        shadowPointLight.SetActive(true);
        candleSpotLight.SetActive(true);
        auraQualitySettings.displayVolumetricLightingBuffer = false;
        auraBaseSettings.density = candleOnLightingDensity;
        auraBaseSettings.ambientLightingStrength = candleOnAmbientLightingStrength;
    }

    private void OnCandleBurnedOut()
    {
        shadowPointLight.SetActive(false);
        candleSpotLight.SetActive(false);
        auraQualitySettings.displayVolumetricLightingBuffer = true;
        auraBaseSettings.density = candleOffLightingDensity;
        auraBaseSettings.ambientLightingStrength = candleOffAmbientLightingStrength;
    }

    private void OnCandleFlicker() //make this a coroutine?
    {

    }

    private void OnEnable()
    {
        EquipmentManager.CandlePickedUp += OnCandlePickedUp;
        CandleBurnDown.CandleBurnedOut += OnCandleBurnedOut;
        RespawnManager.RespawnTriggered += OnSpawn;
    }

    private void OnDisable()
    {
        EquipmentManager.CandlePickedUp -= OnCandlePickedUp;
        CandleBurnDown.CandleBurnedOut -= OnCandleBurnedOut;
        RespawnManager.RespawnTriggered -= OnSpawn;
    }
}
