using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFOV : MonoBehaviour
{

    Camera thisCamera;

    [SerializeField]
    [Tooltip ("This is the camera whose FOV you want to match")]
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        thisCamera.fieldOfView = mainCamera.fieldOfView;
    }
}
