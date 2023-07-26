using TMPro;
using UnityEngine;

public class SpreadUpgrade : MonoBehaviour
{
    public int spread;
    public TextMeshProUGUI spreadText;
    public UpgradeMenu upgradeMenu;

    public void SetStartSpread()
    {
        PlayerPrefs.SetInt("Start Spread", spread);
        spreadText.text = spread.ToString();
        upgradeMenu.spreadText.text = spread.ToString();
    }
}