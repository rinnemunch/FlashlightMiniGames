using UnityEngine;
using System.Collections;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;
    private bool isOn = false;
    private bool isFlickering = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isFlickering)
        {
            isOn = !isOn;

            if (isOn)
                StartCoroutine(FlickerOn());
            else
                flashlight.enabled = false;
        }
    }

    IEnumerator FlickerOn()
    {
        isFlickering = true;

        for (int i = 0; i < 3; i++)
        {
            flashlight.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            flashlight.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
        }

        isFlickering = false;
    }
}
