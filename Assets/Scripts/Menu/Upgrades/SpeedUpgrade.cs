using TMPro;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour
{
    public int speed;
    public TextMeshProUGUI speedText;
    public UpgradeMenu upgradeMenu; 

    public void SetStartSpeed()
    {
        PlayerPrefs.SetInt("Start Speed", speed);
        speedText.text = speed.ToString();
        upgradeMenu.speedText.text = speed.ToString();
    }
}