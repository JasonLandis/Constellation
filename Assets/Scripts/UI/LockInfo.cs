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
    [HideInInspector] public List<string> lockedText;

    private void Awake()
    {
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>100</color>");
        lockedText.Add("Achieve a score of <color=#11DC58>50</color> in <color=#00C9FF>One Universe</color>");
        lockedText.Add("Achieve a total distance traveled of 1000");
        lockedText.Add("Clear one universe");
        lockedText.Add("Reach a size of 2");

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

    public void Back()
    {
        background.SetActive(false);
    }
}
