using UnityEngine;

public class Skin : MonoBehaviour
{
    public int skinIndex;
    public ShopMenu shopMenu;

    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", skinIndex);
        foreach (Transform child in shopMenu.playerHolder.transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(shopMenu.icons[PlayerPrefs.GetInt("Skin")], shopMenu.playerHolder.transform.position, Quaternion.identity, shopMenu.playerHolder.transform);
    }
}
