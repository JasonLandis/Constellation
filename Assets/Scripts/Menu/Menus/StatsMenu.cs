using TMPro;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    [Header("Main Menu")]
    public TextMeshProUGUI highScoreText;

    [Header("Screen 1")]
    public TextMeshProUGUI statsHighScoreText;
    public TextMeshProUGUI totalDistanceText;

    [Header("Screen 2")]
    public TextMeshProUGUI highestUniverseScoreText;
    public TextMeshProUGUI mostUniversesText;
    public TextMeshProUGUI quickestUniverseText;

    [Header("Screen 3")]
    public TextMeshProUGUI totalUniversesText;
    public TextMeshProUGUI EasyUniversesText;
    public TextMeshProUGUI NormalUniversesText;
    public TextMeshProUGUI HardUniversesText;

    [Header("Screen 4")]
    public TextMeshProUGUI hitlessUniversesText;
    public TextMeshProUGUI hitlessEasyUniversesText;
    public TextMeshProUGUI hitlessNormalUniversesText;
    public TextMeshProUGUI hitlessHardUniversesText;

    [Header("Screen 5")]
    public TextMeshProUGUI largestSizeText;
    public TextMeshProUGUI largestSpreadText;
    public TextMeshProUGUI largestSpeedText;

    [Header("Screen 6")]
    public TextMeshProUGUI smallestSizeText;
    public TextMeshProUGUI smallestSpreadText;
    public TextMeshProUGUI smallestSpeedText;

    [Header("Screen 7")]
    public TextMeshProUGUI mostLivesText;
    public TextMeshProUGUI unlockedUpgradesText;
    public TextMeshProUGUI unlockedIconsText;

    [Header("Skin Screens")]
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject screen6;
    public GameObject screen7;

    private int activeScreen = 1;

    public void LoadStatsValues()
    {
        highScoreText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("High Score", 0).ToString() + "</color>";

        statsHighScoreText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("High Score", 0).ToString() + "</color>";
        totalDistanceText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Total Distance", 0).ToString() + "</color>";

        highestUniverseScoreText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Universe Score", 0).ToString() + "</color>";
        mostUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Most Universes", 0).ToString() + "</color>";
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            quickestUniverseText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Quickest Universe").ToString() + "</color>";
        }
        else
        {
            quickestUniverseText.text = "<color=#FFF97A>NA</color>";
        }
        
        totalUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Total Universes", 0).ToString() + "</color>";        
        EasyUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Easy Universes", 0).ToString() + "</color>";
        NormalUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Normal Universes", 0).ToString() + "</color>";
        HardUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Hard Universes", 0).ToString() + "</color>";

        hitlessUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Hitless Universes", 0).ToString() + "</color>";
        hitlessEasyUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Hitless Easy Universes", 0).ToString() + "</color>";
        hitlessNormalUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Hitless Normal Universes", 0).ToString() + "</color>";
        hitlessHardUniversesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Hitless Hard Universes", 0).ToString() + "</color>";

        largestSizeText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Largest Size", 1).ToString() + "</color>";
        largestSpreadText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Largest Spread", 5).ToString() + "</color>";       
        largestSpeedText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Largest Speed", 10).ToString() + "</color>";

        smallestSizeText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Smallest Size", 1).ToString() + "</color>";
        smallestSpreadText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Smallest Spread", 5).ToString() + "</color>";
        smallestSpeedText.text = "<color=#FFF97A>" + PlayerPrefs.GetFloat("Smallest Speed", 10).ToString() + "</color>";

        mostLivesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Most Lives", 0).ToString() + "</color>";
        unlockedUpgradesText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Unlocked Upgrades", 1).ToString() + "</color>";
        unlockedIconsText.text = "<color=#FFF97A>" + PlayerPrefs.GetInt("Unlocked Icons", 1).ToString() + "</color>";
    }

    public void SwapRight()
    {
        if (activeScreen == 1)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);
            activeScreen = 2;
        }
        else if (activeScreen == 2)
        {
            screen2.SetActive(false);
            screen3.SetActive(true);
            activeScreen = 3;
        }
        else if (activeScreen == 3)
        {
            screen3.SetActive(false);
            screen4.SetActive(true);
            activeScreen = 4;
        }
        else if (activeScreen == 4)
        {
            screen4.SetActive(false);
            screen5.SetActive(true);
            activeScreen = 5;
        }
        else if (activeScreen == 5)
        {
            screen5.SetActive(false);
            screen6.SetActive(true);
            activeScreen = 6;
        }
        else if (activeScreen == 6)
        {
            screen6.SetActive(false);
            screen7.SetActive(true);
            activeScreen = 7;
        }
        else
        {
            screen7.SetActive(false);
            screen1.SetActive(true);
            activeScreen = 1;
        }
    }

    public void SwapLeft()
    {
        if (activeScreen == 1)
        {
            screen1.SetActive(false);
            screen7.SetActive(true);
            activeScreen = 7;
        }
        else if (activeScreen == 2)
        {
            screen2.SetActive(false);
            screen1.SetActive(true);
            activeScreen = 1;
        }
        else if (activeScreen == 3)
        {
            screen3.SetActive(false);
            screen2.SetActive(true);
            activeScreen = 2;
        }
        else if (activeScreen == 4)
        {
            screen4.SetActive(false);
            screen3.SetActive(true);
            activeScreen = 3;
        }
        else if (activeScreen == 5)
        {
            screen5.SetActive(false);
            screen4.SetActive(true);
            activeScreen = 4;
        }
        else if (activeScreen == 6)
        {
            screen6.SetActive(false);
            screen5.SetActive(true);
            activeScreen = 5;
        }
        else
        {
            screen7.SetActive(false);
            screen6.SetActive(true);
            activeScreen = 6;
        }
    }
}
