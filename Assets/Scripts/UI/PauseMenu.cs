using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject sureMenu;
    public GameObject stats;

    private void Awake()
    {
        sureMenu.SetActive(false);
    }

    // Menu buttons
    public void Resume()
    {
        GameManager.instance.player.SetActive(true);
        pauseMenu.SetActive(false);
        sureMenu.SetActive(false);
        stats.SetActive(false);
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

    public void Menu()
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