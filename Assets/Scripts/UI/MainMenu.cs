using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Customizable")]
    public List<Sprite> icons;
    public SpriteRenderer player;
    public Image playerIcon;

    [Header("Objects")]
    public GameObject stats;
    public GameObject shop;

    [Header("Stats Text")]
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI singleScoreText;
    public TextMeshProUGUI universesClearedText;
    public TextMeshProUGUI totalDistanceText;
    public TextMeshProUGUI maxSizeText;
    public TextMeshProUGUI maxSpreadText;
    public TextMeshProUGUI maxSpeedText;
    public TextMeshProUGUI minSizeText;
    public TextMeshProUGUI minSpreadText;
    public TextMeshProUGUI minSpeedText;

    private void Start()
    {
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];

        highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
        singleScoreText.text = PlayerPrefs.GetInt("Single Score", 0).ToString();
        universesClearedText.text = PlayerPrefs.GetInt("Universes Cleared", 0).ToString();
        totalDistanceText.text = PlayerPrefs.GetInt("Total Distance", 0).ToString();
        maxSizeText.text = PlayerPrefs.GetFloat("Max Size", 1).ToString();
        maxSpreadText.text = PlayerPrefs.GetFloat("Max Spread", 5).ToString();
        maxSpeedText.text = PlayerPrefs.GetFloat("Max Speed", 10).ToString();
        minSizeText.text = PlayerPrefs.GetFloat("Min Size", 1).ToString();
        minSpreadText.text = PlayerPrefs.GetFloat("Min Spread", 5).ToString();
        minSpeedText.text = PlayerPrefs.GetFloat("Min Speed", 10).ToString();

        // PlayerPrefs.DeleteAll();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Shop()
    {
        shop.SetActive(true);
    }

    public void Stats()
    {
        stats.SetActive(true);
    }

    public void Menu()
    {
        shop.SetActive(false);
        stats.SetActive(false);
    }

    public void SetSkinOne()
    {
        PlayerPrefs.SetInt("Skin", 0);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }

    public void SetSkinTwo()
    {
        PlayerPrefs.SetInt("Skin", 1);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }

    public void SetSkinThree()
    {
        PlayerPrefs.SetInt("Skin", 2);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }

    public void SetSkinFour()
    {
        PlayerPrefs.SetInt("Skin", 3);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }

    public void SetSkinFive()
    {
        PlayerPrefs.SetInt("Skin", 4);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }

    public void SetSkinSix()
    {
        PlayerPrefs.SetInt("Skin", 5);
        player.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
        playerIcon.sprite = icons[PlayerPrefs.GetInt("Skin", 0)];
    }


}