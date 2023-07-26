using TMPro;
using UnityEngine;

public class SizeUpgrade : MonoBehaviour
{
    public float size;
    public TextMeshProUGUI sizeText;
    public UpgradeMenu upgradeMenu;

    public void SetStartSize()
    {
        PlayerPrefs.SetFloat("Start Size", size);
        sizeText.text = size.ToString();
        upgradeMenu.sizeText.text = size.ToString();
    }
}
