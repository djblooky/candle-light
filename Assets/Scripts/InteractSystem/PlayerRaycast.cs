using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerRaycast : MonoBehaviour
{
    public static event Action<InteractiveObject> HoveredOver;
    public static event Action HoveredOff;

    public static GameObject lastObjectInteractedWith;
    public static InteractiveObject objectLookingAt;

    [SerializeField] private float distanceToSee = 3;
    [SerializeField] private LayerMask layerMask;

    //Dynamic depth of field vars

    [Range(5,12)]
    [SerializeField] private float focusSpeed = 8f;
    private PostProcessVolume volume;
    private float hitDistance;
    private DepthOfField depthOfField;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("PostProcessing").GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out depthOfField);
    }

    private void Update()
    {
        CastDepthOfFieldRay();
        CastRay();
    }

    private void CastDepthOfFieldRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask)) //if ray hit something
        {
            hitDistance = Vector3.Distance(hit.point, transform.position);
            SetFocus();
        }
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

    private void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, focusSpeed * Time.deltaTime);
        //Debug.Log("Set focus distance to: " + hitDistance);
    }
}
