using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInfo : MonoBehaviour
{
    [Header("Skin Objects")]
    public List<Sprite> icons;
    public SpriteRenderer player;
    public Image playerIcon;

    private void Awake()
    {
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }
}
