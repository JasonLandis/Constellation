using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public Color color;
    public ShopMenu shopMenu;

    void Start()
    {
        color = gameObject.GetComponent<Image>().color;
    }

    public void SetSkin()
    {
        PlayerPrefs.SetFloat("Red", color.r);
        PlayerPrefs.SetFloat("Green", color.g);
        PlayerPrefs.SetFloat("Blue", color.b);

        shopMenu.playerIcon.GetComponent<Image>().color = new(color.r, color.g, color.b, 1);
        shopMenu.playerPrefab.GetComponent<SpriteRenderer>().color = new(color.r, color.g, color.b, 1);
        shopMenu.starPrefab.GetComponent<SpriteRenderer>().color = new(color.r, color.g, color.b, 1);

        shopMenu.playerIcon.GetComponent<Light2D>().color = new(color.r, color.g, color.b, 1);
        shopMenu.playerPrefab.GetComponent<Light2D>().color = new(color.r, color.g, color.b, 1);
        shopMenu.starPrefab.GetComponent<Light2D>().color = new(color.r, color.g, color.b, 1);
    }
}
