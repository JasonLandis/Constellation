using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [Header("Objects")]
    public GameObject stats;
    public GameObject shop;

    [Header("Stats Text")]
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI statsHighScoreText;
    public TextMeshProUGUI largestConstellationText;
    public TextMeshProUGUI quickestUniverseText;
    public TextMeshProUGUI totalDistanceText;
    public TextMeshProUGUI totalUniversesText;
    public TextMeshProUGUI mostUniversesText;
    public TextMeshProUGUI EasyUniversesText;
    public TextMeshProUGUI NormalUniversesText;
    public TextMeshProUGUI HardUniversesText;
    public TextMeshProUGUI hitlessUniversesText;
    public TextMeshProUGUI hitlessEasyUniversesText;
    public TextMeshProUGUI hitlessNormalUniversesText;
    public TextMeshProUGUI hitlessHardUniversesText;
    public TextMeshProUGUI largestSizeText;
    public TextMeshProUGUI largestSpreadText;
    public TextMeshProUGUI largestSpeedText;
    public TextMeshProUGUI smallestSizeText;
    public TextMeshProUGUI smallestSpreadText;
    public TextMeshProUGUI smallestSpeedText;
    public TextMeshProUGUI mostLivesText;
    public TextMeshProUGUI unlockedIconsText;

    void Awake()
    {
        Application.targetFrameRate = 60;
        highScoreText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("High Score", 0).ToString() + "</color>";
        statsHighScoreText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("High Score", 0).ToString() + "</color>";
        largestConstellationText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Largest Constellation", 0).ToString() + "</color>";
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            quickestUniverseText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Quickest Universe").ToString() + "</color>";
        }
        else
        {
            quickestUniverseText.text = "<color=#11DC58>NA</color>";
        }
        totalDistanceText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Total Distance", 0).ToString() + "</color>";
        totalUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Total Universes", 0).ToString() + "</color>";
        mostUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Most Universes", 0).ToString() + "</color>";
        EasyUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Easy Universes", 0).ToString() + "</color>";
        NormalUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Normal Universes", 0).ToString() + "</color>";
        HardUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Hard Universes", 0).ToString() + "</color>";
        hitlessUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Hitless Universes", 0).ToString() + "</color>";
        hitlessEasyUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Hitless Easy Universes", 0).ToString() + "</color>";
        hitlessNormalUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Hitless Normal Universes", 0).ToString() + "</color>";
        hitlessHardUniversesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Hitless Hard Universes", 0).ToString() + "</color>";
        largestSizeText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Largest Size", 1).ToString() + "</color>";
        largestSpreadText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Largest Spread", 5).ToString() + "</color>";
        largestSpeedText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Largest Speed", 10).ToString() + "</color>";
        smallestSizeText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Smallest Size", 1).ToString() + "</color>";
        smallestSpreadText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Smallest Spread", 5).ToString() + "</color>";
        smallestSpeedText.text = "<color=#11DC58>" + PlayerPrefs.GetFloat("Smallest Speed", 10).ToString() + "</color>";
        mostLivesText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Most Lives", 0).ToString() + "</color>";
        unlockedIconsText.text = "<color=#11DC58>" + PlayerPrefs.GetInt("Unlocked Icons", 1).ToString() + "</color>";


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
}