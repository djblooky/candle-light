using System;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static event Action RespawnTriggered;

    public static int DeathCount = 0;

    [SerializeField] private GameObject playerCamera;

    [SerializeField] private float delayBeforeDeathAnim = 10f;
    [SerializeField] private float delayBeforeRespawn = 10f;

    [SerializeField] private Vector3 RespawnPosition = new Vector3(4.86f, 0.25f, -13.58f);
    [SerializeField] private Vector3 RespawnRotation = new Vector3(0f, 90f, 0f);

    [SerializeField] private GameObject CandlePivotPointer;

    private void Start()
    {
        AkSoundEngine.SetState("Music_Switch", "Game_Start");//set music state for start of game in Wwise
        AkSoundEngine.PostEvent("Music_Switch", gameObject);

        var camRB = playerCamera.GetComponent<Rigidbody>();
        camRB.isKinematic = true;
    }

    private void TriggerDeath()
    {
        //trigger audio que for pre-death
        AkSoundEngine.SetState("Music_Switch", "Death");
        AkSoundEngine.PostEvent("Music_Switch", gameObject);//Wwise Audio Trigger upon death

        //EquipmentManager.current.rightHandEquipped = false;
        Invoke("DeathAnimationAfterDelay", delayBeforeDeathAnim);
    }

    private void DeathAnimationAfterDelay()
    {
        playerCamera.GetComponent<SphereCollider>().enabled = true;
        var camRB = playerCamera.GetComponent<Rigidbody>();
        camRB.isKinematic = false;
        camRB.useGravity = true;
        camRB.AddForce(Vector3.forward * 10, ForceMode.Impulse);

        playerCamera.GetComponent<PlayerRaycast>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<RushCharacterController>().enabled = false;
        Invoke("Respawn", delayBeforeRespawn);
    }

    private void Respawn()
    {
        AkSoundEngine.SetState("Music_Switch", "Game_Start");//reset music state when respawning
        AkSoundEngine.PostEvent("Music_Switch", gameObject);

        playerCamera.transform.position = new Vector3(0, 1.41f, 0);
        playerCamera.transform.localEulerAngles = Vector3.zero;
        Debug.Log("Camera position reset");

        CandlePivotPointer.transform.localScale = new Vector3(0f, 0f, 0f);
        gameObject.transform.position = RespawnPosition;
        gameObject.transform.localEulerAngles = RespawnRotation;

        GetComponent<CharacterController>().enabled = true;
        GetComponent<RushCharacterController>().enabled = true;
        playerCamera.GetComponent<SphereCollider>().enabled = false;
        playerCamera.GetComponent<Rigidbody>().useGravity = false;
        playerCamera.GetComponent<Rigidbody>().isKinematic = true;
        playerCamera.GetComponent<PlayerRaycast>().enabled = true;

        RespawnTriggered?.Invoke();
        //set camera back to correct spot
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
