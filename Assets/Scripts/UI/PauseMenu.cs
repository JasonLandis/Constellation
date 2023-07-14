using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject stats;
    // Menu buttons
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        stats.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Stats()
    {
        stats.SetActive(true);
        Time.timeScale = 0f;
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