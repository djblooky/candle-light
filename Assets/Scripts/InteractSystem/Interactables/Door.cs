using UnityEngine;

public class Door : Openable
{
    private void Start()
    {
        InteractObjInit();
        animator = GetComponentInParent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
}
