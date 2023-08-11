using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D globalLight;
    public GameObject lightsOffButton;
    public GameObject playerIconStar;

    void Start()
    {
        InitializeLights();
    }

    // See if the player has lights on or not
    private void InitializeLights()
    {
        if (PlayerPrefs.GetInt("Lights", 1) == 1)
        {
            LightsOn();
        }
        else
        {
            LightsOff();
        }
    }


    public void LightsOff()
    {
        foreach (Light2D light in FindObjectsOfType<Light2D>())
        {
            if (light != globalLight)
            {
                light.enabled = false;
            }
        }
        if (GameManager.instance == null) 
        {
            playerIconStar.GetComponent<Light2D>().enabled = false;
            globalLight.color = new(0.48f, 0.48f, 0.48f, 1);
        }
        else
        {
            globalLight.color = new(1, 1, 1, 1);
        }
        lightsOffButton.SetActive(true);
        PlayerPrefs.SetInt("Lights", 0);
    }
    public void LightsOn()
    {
        foreach (Light2D light in FindObjectsOfType<Light2D>())
        {
            if (light != globalLight)
            {
                light.enabled = true;
            }
        }
        if (GameManager.instance == null)
        {
            playerIconStar.GetComponent<Light2D>().enabled = true;
            globalLight.color = new(0.1f, 0.1f, 0.1f, 1);
        }
        else
        {
            globalLight.color = new(0.68f, 0.68f, 0.68f, 1);
        }
        lightsOffButton.SetActive(false);
        PlayerPrefs.SetInt("Lights", 1);
    }
}
