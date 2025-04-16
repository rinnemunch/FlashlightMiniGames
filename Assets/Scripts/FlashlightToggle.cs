using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;
    public Image flashlightIcon;

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

            UpdateIcon();
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

    void UpdateIcon()
    {
        if (flashlightIcon != null)
        {
            flashlightIcon.color = isOn
                ? Color.white
                : new Color(0.5f, 0.5f, 0.5f, 0.4f); // gray and slightly transparent when off
        }
    }
}
