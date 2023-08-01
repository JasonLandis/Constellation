using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public Light2D globalLight;
    public GameObject lightsOffButton;

    void Awake()
    {
        GameManager.instance.initializeLights += InitializeLights;
    }

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
        GameManager.instance.player.GetComponent<Light2D>().enabled = false;
        GameManager.instance.star.GetComponent<Light2D>().enabled = false;
        globalLight.color = new(0.78f, 0.78f, 0.78f, 1);
        lightsOffButton.SetActive(true);
        PlayerPrefs.SetInt("Lights", 0);
    }

    public void LightsOn()
    {
        GameManager.instance.player.GetComponent<Light2D>().enabled = true;
        GameManager.instance.star.GetComponent<Light2D>().enabled = true;
        globalLight.color = new(0.57f, 0.57f, 0.57f, 1);
        lightsOffButton.SetActive(false);
        PlayerPrefs.SetInt("Lights", 1);
    }

}
