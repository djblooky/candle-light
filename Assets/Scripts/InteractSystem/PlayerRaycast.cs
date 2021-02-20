using System;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public static event Action<InteractiveObject> HoveredOver;
    public static event Action HoveredOff;

    public static GameObject lastObjectInteractedWith;
    public static InteractiveObject objectLookingAt;

    [SerializeField] private float distanceToSee = 3;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceToSee, layerMask)) //if ray hit something
        {
            if (hit.collider.CompareTag("InteractiveObject")) //if the thing it hit was interactable
            {
                objectLookingAt = hit.collider.gameObject.GetComponent<InteractiveObject>();
                HoveredOver?.Invoke(objectLookingAt);
                if (Input.GetMouseButtonDown(0))
                    objectLookingAt.Interact(); lastObjectInteractedWith = hit.transform.gameObject;
            }
            else //if hit something that's not interactable
            {
                HoveredOff?.Invoke();
            }
        }
        else //if didn't hit anything
        {
            HoveredOff?.Invoke();
        }
    }
}
