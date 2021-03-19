using UnityEngine;

public class CameraOnTop : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<Camera>().enabled = true;
    }

}
