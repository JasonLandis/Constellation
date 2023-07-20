using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInfo : MonoBehaviour
{
    [Header("Skin Objects")]
    public List<Sprite> icons;
    public SpriteRenderer player;
    public SpriteRenderer star;
    public Image playerIcon;

    void Awake()
    {
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        star.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }
}
