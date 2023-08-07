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
        highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();

        statsHighScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
        totalDistanceText.text = PlayerPrefs.GetInt("Total Distance", 0).ToString();

        highestUniverseScoreText.text = PlayerPrefs.GetInt("Universe Score", 0).ToString();
        mostUniversesText.text = PlayerPrefs.GetInt("Most Universes", 0).ToString();
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            quickestUniverseText.text = PlayerPrefs.GetInt("Quickest Universe").ToString();
        }
        else
        {
            quickestUniverseText.text = "-";
        }
        
        totalUniversesText.text = PlayerPrefs.GetInt("Total Universes", 0).ToString();
        EasyUniversesText.text = PlayerPrefs.GetInt("Easy Universes", 0).ToString();
        NormalUniversesText.text = PlayerPrefs.GetInt("Normal Universes", 0).ToString();
        HardUniversesText.text = PlayerPrefs.GetInt("Hard Universes", 0).ToString();

        hitlessUniversesText.text = PlayerPrefs.GetInt("Hitless Universes", 0).ToString();
        hitlessEasyUniversesText.text = PlayerPrefs.GetInt("Hitless Easy Universes", 0).ToString();
        hitlessNormalUniversesText.text = PlayerPrefs.GetInt("Hitless Normal Universes", 0).ToString();
        hitlessHardUniversesText.text = PlayerPrefs.GetInt("Hitless Hard Universes", 0).ToString();

        if (PlayerPrefs.HasKey("Largest Size"))
        {
            largestSizeText.text = PlayerPrefs.GetFloat("Largest Size").ToString();
        }
        else
        {
            largestSizeText.text = "-";
        }
        if (PlayerPrefs.HasKey("Largest Spread"))
        {
            largestSpreadText.text = PlayerPrefs.GetFloat("Largest Spread").ToString();
        }
        else
        {
            largestSpreadText.text = "-";
        }
        if (PlayerPrefs.HasKey("Largest Speed"))
        {
            largestSpeedText.text = PlayerPrefs.GetFloat("Largest Speed").ToString();
        }
        else
        {
            largestSpeedText.text = "-";
        }

        if (PlayerPrefs.HasKey("Smallest Size"))
        {
            smallestSizeText.text = PlayerPrefs.GetFloat("Smallest Size").ToString();
        }
        else
        {
            smallestSizeText.text = "-";
        }
        if (PlayerPrefs.HasKey("Smallest Spread"))
        {
            smallestSpreadText.text = PlayerPrefs.GetFloat("Smallest Spread").ToString();
        }
        else
        {
            smallestSpreadText.text = "-";
        }
        if (PlayerPrefs.HasKey("Smallest Speed"))
        {
            smallestSpeedText.text = PlayerPrefs.GetFloat("Smallest Speed").ToString();
        }
        else
        {
            smallestSpeedText.text = "-";
        }

        mostLivesText.text = PlayerPrefs.GetInt("Most Lives", 0).ToString();
        unlockedUpgradesText.text = PlayerPrefs.GetInt("Unlocked Upgrades", 1).ToString() + "/32";
        unlockedIconsText.text = PlayerPrefs.GetInt("Unlocked Icons", 1).ToString() + "/42";
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
