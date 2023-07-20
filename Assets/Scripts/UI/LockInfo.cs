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
    public List<string> lockedText;

    void Awake()
    {
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>1000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>500</color>");
        lockedText.Add("<color=#E54B4B>Exit a universe</color> before reaching a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance</color> of <color=#11DC58>5000</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>2</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>2</color> <color=#00C9FF>Easy Universes</color>");
        lockedText.Add("Clear <color=#11DC58>2</color> <color=#00C9FF>Normal Universes</color>");
        lockedText.Add("Clear <color=#11DC58>2</color> <color=#00C9FF>Hard Universes</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> universe <color=#00C9FF>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> easy universe <color=#00C9FF>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> normal universe <color=#00C9FF>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> hard universe <color=#00C9FF>without being hit</color>");
        lockedText.Add("Reach a <color=#00C9FF>size</color> of <color=#11DC58>2</color>");
        lockedText.Add("Reach a <color=#00C9FF>spread</color> of <color=#11DC58>7</color>");
        lockedText.Add("Reach a <color=#00C9FF>speed</color> of <color=#11DC58>13</color>");
        lockedText.Add("Reach a <color=#00C9FF>size</color> of <color=#11DC58>0.5</color>");
        lockedText.Add("Reach a <color=#00C9FF>spread</color> of <color=#11DC58>3</color>");
        lockedText.Add("Reach a <color=#00C9FF>speed</color> of <color=#11DC58>8</color>");
        lockedText.Add("Carry a <color=#11DC58>10</color> <color=#00C9FF>extra lives</color> at once");

        if (PlayerPrefs.GetInt("High Score", 0) >= 1000)
        {
            locks[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Largest Constellation", 0) >= 500)
        {
            locks[1].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            if (PlayerPrefs.GetInt("Quickest Universe") < 500)
            {
                locks[2].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Total Distance", 0) >= 5000)
        {
            locks[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Total Universes", 0) >= 5)
        {
            locks[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Most Universes", 0) >= 2)
        {
            locks[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Easy Universes", 0) >= 2)
        {
            locks[6].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Normal Universes", 0) >= 2)
        {
            locks[7].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Hard Universes", 0) >= 2)
        {
            locks[8].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Hitless Universes", 0) >= 1)
        {
            locks[9].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Hitless Easy Universes", 0) >= 1)
        {
            locks[10].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Hitless Normal Universes", 0) >= 1)
        {
            locks[11].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Hitless Hard Universes", 0) >= 1)
        {
            locks[12].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Largest Size", 0) >= 2)
        {
            locks[13].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 7)
        {
            locks[14].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 13)
        {
            locks[15].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Smallest Size", 0) >= 0.5f)
        {
            locks[16].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Smallest Spread", 0) >= 3)
        {
            locks[17].SetActive(false);
        }
        if (PlayerPrefs.GetFloat("Smallest Speed", 0) >= 8)
        {
            locks[18].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Most Lives", 0) >= 10)
        {
            locks[19].SetActive(false);
        }
    }

    public void Back()
    {
        background.SetActive(false);
    }
}
