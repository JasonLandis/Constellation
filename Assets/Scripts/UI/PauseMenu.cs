using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float countdown;
    private bool pressedResume;
    private float speed;

    private bool isGamePaused;
    public void Resume()
    {
        float count = countdown;
        countdown -= Time.deltaTime;
        int value = (int)Mathf.Ceil(countdown);
        countdownText.text = value.ToString();
        if (countdown <= 0)
        {
            countdownText.text = "";
            countdown = count;
            GameManager.instance.scrollSpeed = speed;
            GameManager.instance.immortal = false;
            isGamePaused = false;
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameOver)
        {
            if (isGamePaused)
            {
                speed = GameManager.instance.scrollSpeed;
                pauseMenuUI.SetActive(false);
                GameManager.instance.scrollSpeed = 0f;
                GameManager.instance.immortal = true;
                pressedResume = true;
                Time.timeScale = 1f;
            }
            else
            {
                Pause();
                isGamePaused = true;
            }
        }

        if (pressedResume)
        {
            Resume();
        }
    }
}
