using TMPro;
using UnityEngine;

public class LivesUpgrade : MonoBehaviour
{
    public int lives;
    public TextMeshProUGUI livesText;
    public UpgradeMenu upgradeMenu;

    public void SetStartLives()
    {
        PlayerPrefs.SetInt("Start Lives", lives);
        livesText.text = lives.ToString();
        upgradeMenu.livesText.text = lives.ToString();
    }
}
