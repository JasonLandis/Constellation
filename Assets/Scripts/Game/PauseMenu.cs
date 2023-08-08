using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject pauseMenu;
    public GameObject sureMenu;
    public GameObject stats;
    public GameObject sizeInfo;
    public GameObject spreadInfo;
    public GameObject speedInfo;
    public GameObject livesInfo;
    public GameObject zoneInfo;

    [Header("Pause Mechanics")]
    private bool unPaused = false;
    public GameObject pauseText;
    public TextMeshProUGUI count;
    private float timer = 3;

    void Awake()
    {
        sureMenu.SetActive(false);
    }

    void OnApplicationFocus(bool focus)
    {
        if (!focus) 
        {
            Pause();
        }
    }

    private void Update()
    {
        if (unPaused)
        {
            Time.timeScale = 1f;
            timer -= Time.deltaTime;
            count.text = Math.Ceiling(timer).ToString();
            if (timer < 0)
            {
                ResumeFromPause();
                pauseText.SetActive(false);
                timer = 3;
                unPaused = false;
            }
        }
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        if (!GameManager.instance.finished)
        {
            pauseText.SetActive(true);
            unPaused = true;
        }
        else
        {
            ResumeFromPause();
        }
    }

    public void ResumeFromPause()
    {
        sureMenu.SetActive(false);
        GameManager.instance.isGamePaused = false;
        Time.timeScale = 1f;
    }

    // Menu buttons
    public void Resume()
    {
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        stats.SetActive(false);
        sizeInfo.SetActive(false);
        spreadInfo.SetActive(false);
        speedInfo.SetActive(false);
        livesInfo.SetActive(false);
        zoneInfo.SetActive(false);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameManager.instance.isGamePaused = true;
        Time.timeScale = 0f;
    }

    public void Stats()
    {
        stats.SetActive(true);
    }
    public void Sure()
    {
        sureMenu.SetActive(true);
    }

    // Buttons for size, spread, speed, and lives
    public void SizeInfo()
    {
        sizeInfo.SetActive(true);
    }
    public void SpreadInfo()
    {
        spreadInfo.SetActive(true);
    }
    public void SpeedInfo()
    {
        speedInfo.SetActive(true);
    }
    public void LivesInfo()
    {
        livesInfo.SetActive(true);
    }
    public void ZoneInfo()
    {
        zoneInfo.SetActive(true);
    }

    public void Continue()
    {
        GameManager.instance.resetUniverse = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        panel.SetActive(true);
        panel.GetComponent<Image>().raycastTarget = true;
        panel.GetComponent<Image>().color = new(0, 0, 0, 0);
        LeanTween.color(panel.GetComponent<Image>().rectTransform, new(0, 0, 0, 1), 0.3f).setOnComplete(Load);
    }

    private void Load()
    {
        GameManager.instance.SaveScores();
        SceneManager.LoadScene("Menu");
    }

    public void MenuFromEnd()
    {
        GameManager.instance.player.GetComponent<Light2D>().volumeIntensityEnabled = false;
        panel.SetActive(true);
        panel.GetComponent<Image>().raycastTarget = true;
        LeanTween.color(panel.GetComponent<Image>().rectTransform, new(0, 0, 0, 1), 0.3f).setOnComplete(Load2);
    }

    private void Load2()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        GameManager.instance.player.GetComponent<Light2D>().volumeIntensityEnabled = false;
        panel.SetActive(true);
        panel.GetComponent<Image>().raycastTarget = true;
        LeanTween.color(panel.GetComponent<Image>().rectTransform, new(0, 0, 0, 1), 0.3f).setOnComplete(LoadMain);
    }

    private void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}