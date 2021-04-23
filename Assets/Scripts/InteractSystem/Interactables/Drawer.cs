using UnityEngine;

public class Drawer : Openable
{
    private void Start()
    {
        InteractObjInit();
        animator = GetComponent<Animator>();
    }
}
