using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        // load the Main scene
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        // quit the game
        Application.Quit();
    }
}
