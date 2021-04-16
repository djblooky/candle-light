using UnityEngine;

public class Key : InteractiveObject
{
    [SerializeField]
    private GameObject objectToUnlock;

    [SerializeField]
    private AudioClip pickupSound;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public override void Interact(InteractiveObject i)
    {
        audioSource.PlayOneShot(pickupSound);
        objectToUnlock.GetComponentInChildren<Openable>().isLocked = false;
        meshRenderer.enabled = false;
        Destroy(gameObject, pickupSound.length);
    }
}
