using UnityEngine;

public class Lamp : Toggleable
{
    private Light[] lights;

    private void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }

    public override void Interact()
    {
        base.Interact();
        ToggleLight();
    }

    private void ToggleLight()
    {
        if (isOn)
        {
            foreach(Light light in lights)
                light.enabled = true;
        }
        else
        {
            foreach (Light light in lights)
                light.enabled = false;
        }
    }
}
