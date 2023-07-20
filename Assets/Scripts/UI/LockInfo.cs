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

    void Awake()
    {
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>1,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>2,500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>5,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>10,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>1,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>2,500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance</color> of <color=#11DC58>10,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance</color> of <color=#11DC58>25,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance</color> of <color=#11DC58>50,000</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>600</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>500</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Constellation Score</color> score of <color=#11DC58>400</color>");
        lockedText.Add("Clear <color=#11DC58>2</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>10</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>25</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>50</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Easy Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Easy Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Normal Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Normal Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Hard Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Hard Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Easy Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Easy Universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Normal Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Normal Universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Hard Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Hard Universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Reach a <color=#00C9FF>Size</color> of <color=#11DC58>0.5</color>");
        lockedText.Add("Reach a <color=#00C9FF>Size</color> of <color=#11DC58>0.1</color>");
        lockedText.Add("Reach a <color=#00C9FF>Size</color> of <color=#11DC58>4</color>");
        lockedText.Add("Reach a <color=#00C9FF>Size</color> of <color=#11DC58>7</color>");
        lockedText.Add("Reach a <color=#00C9FF>Spread</color> of <color=#11DC58>8</color>");
        lockedText.Add("Reach a <color=#00C9FF>Spread</color> of <color=#11DC58>10</color>");
        lockedText.Add("Reach a <color=#00C9FF>Spread</color> of <color=#11DC58>4</color>");
        lockedText.Add("Reach a <color=#00C9FF>Spread</color> of <color=#11DC58>2</color>");
        lockedText.Add("Reach a <color=#00C9FF>Speed</color> of <color=#11DC58>7</color>");
        lockedText.Add("Reach a <color=#00C9FF>Speed</color> of <color=#11DC58>5</color>");
        lockedText.Add("Reach a <color=#00C9FF>Speed</color> of <color=#11DC58>15</color>");
        lockedText.Add("Reach a <color=#00C9FF>Speed</color> of <color=#11DC58>20</color>");
        lockedText.Add("Carry <color=#11DC58>10</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>25</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>50</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("<color=#00C9FF>Unlock</color> <color=#11DC58>5</color> icons");
        lockedText.Add("<color=#00C9FF>Unlock</color> <color=#11DC58>15</color> icons");
        lockedText.Add("<color=#00C9FF>Unlock</color> <color=#11DC58>30</color> icons");
        lockedText.Add("<color=#00C9FF>Unlock</color> <color=#11DC58>45</color> icons");
        lockedText.Add("<color=#00C9FF>Unlock</color> <color=#11DC58>All</color> icons");


        int unlockCount = 1;

        if (PlayerPrefs.GetInt("High Score", 0) >= 1000)
        {
            unlockCount += 1;
            locks[0].SetActive(false);
            if (PlayerPrefs.GetInt("High Score", 0) >= 2500)
            {
                unlockCount += 1;
                locks[1].SetActive(false);
                if (PlayerPrefs.GetInt("High Score", 0) >= 5000)
                {
                    unlockCount += 1;
                    locks[2].SetActive(false);
                    if (PlayerPrefs.GetInt("High Score", 0) >= 10000)
                    {
                        unlockCount += 1;
                        locks[3].SetActive(false);
                    }
                }
            }

        }
        if (PlayerPrefs.GetInt("Largest Constellation", 0) >= 500)
        {
            unlockCount += 1;
            locks[4].SetActive(false);
            if (PlayerPrefs.GetInt("Largest Constellation", 0) >= 1000)
            {
                unlockCount += 1;
                locks[5].SetActive(false);
                if (PlayerPrefs.GetInt("Largest Constellation", 0) >= 2500)
                {
                    unlockCount += 1;
                    locks[6].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt("Total Distance", 0) >= 10000)
        {
            unlockCount += 1;
            locks[7].SetActive(false);
            if (PlayerPrefs.GetInt("Total Distance", 0) >= 25000)
            {
                unlockCount += 1;
                locks[8].SetActive(false);
                if (PlayerPrefs.GetInt("Total Distance", 0) >= 50000)
                {
                    unlockCount += 1;
                    locks[9].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            if (PlayerPrefs.GetInt("Quickest Universe") < 600)
            {
                unlockCount += 1;
                locks[10].SetActive(false);
                if (PlayerPrefs.GetInt("Quickest Universe") < 500)
                {
                    unlockCount += 1;
                    locks[11].SetActive(false);
                    if (PlayerPrefs.GetInt("Quickest Universe") < 400)
                    {
                        unlockCount += 1;
                        locks[12].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("Most Universes", 0) >= 2)
        {
            unlockCount += 1;
            locks[13].SetActive(false);
            if (PlayerPrefs.GetInt("Most Universes", 0) >= 5)
            {
                unlockCount += 1;
                locks[14].SetActive(false);
                if (PlayerPrefs.GetInt("Most Universes", 0) >= 10)
                {
                    unlockCount += 1;
                    locks[15].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt("Total Universes", 0) >= 5)
        {
            unlockCount += 1;
            locks[16].SetActive(false);
            if (PlayerPrefs.GetInt("Total Universes", 0) >= 25)
            {
                unlockCount += 1;
                locks[17].SetActive(false);
                if (PlayerPrefs.GetInt("Total Universes", 0) >= 50)
                {
                    unlockCount += 1;
                    locks[18].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt("Easy Universes", 0) >= 5)
        {
            unlockCount += 1;
            locks[19].SetActive(false);
            if (PlayerPrefs.GetInt("Easy Universes", 0) >= 15)
            {
                unlockCount += 1;
                locks[20].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Normal Universes", 0) >= 5)
        {
            unlockCount += 1;
            locks[21].SetActive(false);
            if (PlayerPrefs.GetInt("Easy Universes", 0) >= 15)
            {
                unlockCount += 1;
                locks[22].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Hard Universes", 0) >= 5)
        {
            unlockCount += 1;
            locks[23].SetActive(false);
            if (PlayerPrefs.GetInt("Hard Universes", 0) >= 15)
            {
                unlockCount += 1;
                locks[24].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Hitless Universes", 0) >= 5)
        {
            unlockCount += 1;
            locks[25].SetActive(false);
            if (PlayerPrefs.GetInt("Hitless Universes", 0) >= 15)
            {
                unlockCount += 1;
                locks[26].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Hitless Easy Universes", 0) >= 1)
        {
            unlockCount += 1;
            locks[27].SetActive(false);
            if (PlayerPrefs.GetInt("Hitless Easy Universes", 0) >= 5)
            {
                unlockCount += 1;
                locks[28].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Hitless Normal Universes", 0) >= 1)
        {
            unlockCount += 1;
            locks[29].SetActive(false);
            if (PlayerPrefs.GetInt("Hitless Normal Universes", 0) >= 5)
            {
                unlockCount += 1;
                locks[30].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Hitless Hard Universes", 0) >= 1)
        {
            unlockCount += 1;
            locks[31].SetActive(false);
            if (PlayerPrefs.GetInt("Hitless Hard Universes", 0) >= 5)
            {
                unlockCount += 1;
                locks[32].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Smallest Size", 1) <= 0.5f)
        {
            unlockCount += 1;
            locks[33].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Size", 1) <= 0.1f)
            {
                unlockCount += 1;
                locks[34].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Largest Size", 1) >= 4)
        {
            unlockCount += 1;
            locks[35].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Size", 1) >= 7)
            {
                unlockCount += 1;
                locks[36].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Largest Spread", 5) >= 8)
        {
            unlockCount += 1;
            locks[37].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Spread", 5) >= 10)
            {
                unlockCount += 1;
                locks[38].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Smallest Spread", 5) <= 4)
        {
            unlockCount += 1;
            locks[39].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Spread", 5) <= 2)
            {
                unlockCount += 1;
                locks[40].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Smallest Speed", 10) <= 7)
        {
            unlockCount += 1;
            locks[41].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Speed", 10) <= 5)
            {
                unlockCount += 1;
                locks[42].SetActive(false);
            }
        }
        if (PlayerPrefs.GetFloat("Largest Speed", 10) >= 15)
        {
            unlockCount += 1;
            locks[43].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Speed", 10) >= 20)
            {
                unlockCount += 1;
                locks[44].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("Most Lives", 0) >= 10)
        {
            unlockCount += 1;
            locks[45].SetActive(false);
            if (PlayerPrefs.GetInt("Most Lives", 0) >= 25)
            {
                unlockCount += 1;
                locks[46].SetActive(false);
                if (PlayerPrefs.GetInt("Most Lives", 0) >= 50)
                {
                    unlockCount += 1;
                    locks[47].SetActive(false);
                }
            }
        }
        if (unlockCount >= 5)
        {
            unlockCount += 1;
            locks[48].SetActive(false);
            if (unlockCount >= 15)
            {
                unlockCount += 1;
                locks[49].SetActive(false);
                if (unlockCount >= 30)
                {
                    unlockCount += 1;
                    locks[50].SetActive(false);
                    if (unlockCount >= 45)
                    {
                        unlockCount += 1;
                        locks[51].SetActive(false);
                        if (unlockCount >= 51)
                        {
                            locks[52].SetActive(false);
                        }
                    }
                }
            }
        }
        if (unlockCount >= PlayerPrefs.GetInt("Unlocked Icons", 1))
        {
            PlayerPrefs.SetInt("Unlocked Icons", unlockCount);
        }
    }

    public void Back()
    {
        background.SetActive(false);
    }
}
