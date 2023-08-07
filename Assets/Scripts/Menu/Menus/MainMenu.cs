using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Objects")]
    public GameObject main;
    public GameObject shop;
    public GameObject upgrades;
    public GameObject stats;
    public GameObject starsAnimation;

    [Header("Transition")]
    public Image panel;
    public float color;
    public float duration;

    [Header("Scripts")]
    public ShopMenu shopMenu;
    public UpgradeMenu upgradeMenu;
    public StatsMenu statsMenu;

    void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;

        // Load player data
        upgradeMenu.LoadUpgradeLocks();
        shopMenu.LoadSkinLocks();
        statsMenu.LoadStatsValues();

        // PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
        panel.color = new(0, 0, 0, 1);
        LeanTween.color(panel.rectTransform, new(0, 0, 0, 0), duration);
    }

    public void Play()
    {
        panel.raycastTarget = true;
        panel.color = new(0, 0, 0, 0);
        LeanTween.color(panel.rectTransform, new(0, 0, 0, 1), duration).setOnComplete(Load);
    }

    private void Load()
    {
        SceneManager.LoadScene("Main");
    }

    public void Shop()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(shop);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void Upgrades()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(upgrades);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void Stats()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(stats);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    private void FinishTransition(GameObject menu)
    {
        panel.raycastTarget = false;
        main.SetActive(false);
        menu.SetActive(true);
        LeanTween.color(panel.rectTransform, new(color, color, color, 0), duration);
    }

    public void MenuFromShop()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(shop);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void MenuFromUpgrades()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(upgrades);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void MenuFromStats()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(stats);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    private void FinishTransitionBack(GameObject menu)
    {
        panel.raycastTarget = false;
        menu.SetActive(false);
        main.SetActive(true);
        LeanTween.color(panel.rectTransform, new(color, color, color, 0), duration);
    }
}