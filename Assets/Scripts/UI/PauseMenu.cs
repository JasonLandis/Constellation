using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject sureMenu;
    public GameObject stats;
    public GameObject sizeInfo;
    public GameObject spreadInfo;
    public GameObject speedInfo;
    public GameObject livesInfo;
    public GameObject zoneInfo;

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

    // Menu buttons
    public void Resume()
    {
        if (GameManager.instance.finished == false)
        {
            GameManager.instance.player.SetActive(true);
        }
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        stats.SetActive(false);
        sizeInfo.SetActive(false);
        spreadInfo.SetActive(false);
        speedInfo.SetActive(false);
        livesInfo.SetActive(false);
        zoneInfo.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        GameManager.instance.player.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Stats()
    {
        stats.SetActive(true);
        Time.timeScale = 0f;
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

    public void Menu()
    {
        GameManager.instance.SaveScores();
        GameManager.instance.SaveGameScores();
        SceneManager.LoadScene("Menu");
    }
    public void MenuFromEnd()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        Application.Quit();
    }
}