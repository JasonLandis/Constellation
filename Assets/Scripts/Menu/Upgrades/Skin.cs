using UnityEngine;

public class Skin : MonoBehaviour
{
    public int skinIndex;
    public ShopMenu shopMenu;

    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", skinIndex);
        shopMenu.player.sprite = shopMenu.icons[PlayerPrefs.GetInt("Skin", 0)];
        shopMenu.star.sprite = shopMenu.icons[PlayerPrefs.GetInt("Skin", 0)];
        shopMenu.playerIcon.sprite = shopMenu.icons[PlayerPrefs.GetInt("Skin", 0)];
    }
}
