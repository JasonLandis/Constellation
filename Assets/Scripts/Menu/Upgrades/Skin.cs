using UnityEngine;

public class Skin : MonoBehaviour
{
    public int skinIndex;
    public ShopMenu shopMenu;

    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", skinIndex);
        Destroy(shopMenu.playerHolder.transform.GetChild(0).gameObject);
        Instantiate(shopMenu.icons[PlayerPrefs.GetInt("Skin")], shopMenu.playerHolder.transform.position, Quaternion.identity, shopMenu.playerHolder.transform);
    }
}
