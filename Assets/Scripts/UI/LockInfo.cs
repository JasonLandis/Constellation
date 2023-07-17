using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockInfo : MonoBehaviour
{
    [Header("Locked Text")]
    public GameObject background;
    public TextMeshProUGUI description;

    [Header("Lock Objects")]
    public List<GameObject> locks;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("High Score", 0) >= 100)
        {
            locks[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Single Score", 0) >= 50)
        {
            locks[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Total Distance", 0) >= 1000)
        {
            locks[2].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Universes Cleared", 0) >= 1)
        {
            locks[3].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Max Size", 0) >= 2)
        {
            locks[4].SetActive(false);
        }
    }

    public void IconTwo()
    {
        background.SetActive(true);
        description.text = "Achieve a high score of 100";
    }

    public void IconThree()
    {
        background.SetActive(true);
        description.text = "Achieve a single universe score of 50";
    }

    public void IconFour()
    {
        background.SetActive(true);
        description.text = "Achieve a total distance traveled of 1000";
    }

    public void IconFive()
    {
        background.SetActive(true);
        description.text = "Clear one universe";
    }

    public void IconSix()
    {
        background.SetActive(true);
        description.text = "Reach a size of 2";
    }

    public void Back()
    {
        background.SetActive(false);
    }
}
