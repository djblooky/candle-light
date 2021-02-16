using UnityEngine;

public class Door : Openable
{
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
}
