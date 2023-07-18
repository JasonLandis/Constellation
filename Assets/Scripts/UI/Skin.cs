using UnityEngine;

public class Skin : MonoBehaviour
{
    public int skinIndex;
    public SkinInfo skinInfo;

    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", skinIndex);
        skinInfo.player.sprite = skinInfo.icons[PlayerPrefs.GetInt("Skin", 0)];
        skinInfo.playerIcon.sprite = skinInfo.icons[PlayerPrefs.GetInt("Skin", 0)];
    }
}
