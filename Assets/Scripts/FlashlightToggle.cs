using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
