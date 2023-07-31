using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Objects")]
    public GameObject shop;
    public GameObject upgrades;
    public GameObject stats;
    public GameObject starsAnimation;

    [Header("Scripts")]
    public ShopMenu shopMenu;
    public UpgradeMenu upgradeMenu;
    public StatsMenu statsMenu;

    void Awake()
    {
        Application.targetFrameRate = 60;

        // Load player data
        upgradeMenu.LoadUpgradeLocks();
        shopMenu.LoadSkinLocks();
        statsMenu.LoadStatsValues();

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

    public void Upgrades()
    {
        upgrades.SetActive(true);
    }

    public void Stats()
    {
        stats.SetActive(true);
    }

    public void Menu()
    {
        shop.SetActive(false);
        stats.SetActive(false);
        upgrades.SetActive(false);
    }
}