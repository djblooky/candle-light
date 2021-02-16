using UnityEngine;

public class AnimateCandleFlame : MonoBehaviour
{
    private bool isMoving = false;
    public Animator AnimController;

    private void Start()
    {
        AnimController = GetComponent<Animator>();
        AnimController.SetBool("Is_Moving", false);
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            AnimController.SetBool("Is_Moving", true);
        }
        else
        {
            AnimController.SetBool("Is_Moving", false);
        }

    }
}
