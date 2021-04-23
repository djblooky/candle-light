using UnityEngine;

public class HoverIcon : MonoBehaviour
{
    private GameObject playerHead;

    private void Start()
    {
        playerHead = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        transform.LookAt(playerHead.transform);
    }
}
