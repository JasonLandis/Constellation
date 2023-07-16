using TMPro;
using UnityEngine;

public class LockInfo : MonoBehaviour
{
    public GameObject background;
    public TextMeshProUGUI description;

    public void IconOne()
    {
        background.SetActive(true);
        description.text = "Achieve a high score of 30,000";
    }

    public void IconTwo()
    {
        background.SetActive(true);
        description.text = "Achieve a score of 1,000 in one universe";
    }

    public void IconThree()
    {
        background.SetActive(true);
        description.text = "Clear 5 universes in one run";
    }

    public void Back()
    {
        background.SetActive(false);
    }
}
