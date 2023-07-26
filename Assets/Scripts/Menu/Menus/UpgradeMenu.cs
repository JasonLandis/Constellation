using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [Header("Locked Text")]
    public GameObject lockPopup;
    public TextMeshProUGUI description;

    [Header("Objects")]
    public GameObject sizeMenu;
    public GameObject spreadMenu;
    public GameObject speedMenu;
    public GameObject livesMenu;

    [Header("Start Values Text")]
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI spreadText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI sizeIconText;
    public TextMeshProUGUI spreadIconText;
    public TextMeshProUGUI speedIconText;
    public TextMeshProUGUI livesIconText;

    [Header("Lock Objects")]
    public List<GameObject> locks;
    [HideInInspector] public List<string> lockedText;

    public void LoadUpgradeLocks()
    {
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> greater than <color=#11DC58>8</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> greater than <color=#11DC58>6</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> greater than <color=#11DC58>4</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> greater than <color=#11DC58>2</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> lower than <color=#11DC58>0.8</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> lower than <color=#11DC58>0.6</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> lower than <color=#11DC58>0.4</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> lower than <color=#11DC58>0.2</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> lower than <color=#11DC58>1</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> lower than <color=#11DC58>2</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> lower than <color=#11DC58>3</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> lower than <color=#11DC58>4</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> greater than <color=#11DC58>6</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> greater than <color=#11DC58>7</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> greater than <color=#11DC58>8</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> greater than <color=#11DC58>9</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> greater than <color=#11DC58>30</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> greater than <color=#11DC58>25</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> greater than <color=#11DC58>20</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> greater than <color=#11DC58>15</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> lower than <color=#11DC58>9</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> lower than <color=#11DC58>8</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> lower than <color=#11DC58>7</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> lower than <color=#11DC58>6</color>");
        lockedText.Add("Carry <color=#11DC58>10</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>20</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>30</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>50</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>75</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>100</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>150</color> <color=#00C9FF>Extra Lives</color> at once");
        lockedText.Add("Carry <color=#11DC58>200</color> <color=#00C9FF>Extra Lives</color> at once");

        int unlockedUpgradesCount = 0;

        if (PlayerPrefs.GetFloat("Largest Size", 1) >= 2)
        {
            unlockedUpgradesCount += 1;
            locks[3].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Size", 0) >= 4)
            {
                unlockedUpgradesCount += 1;
                locks[2].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Size", 0) >= 6)
                {
                    unlockedUpgradesCount += 1;
                    locks[1].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Size", 0) >= 8)
                    {
                        unlockedUpgradesCount += 1;
                        locks[0].SetActive(false);
                    }
                }
            }

        }
        if (PlayerPrefs.GetFloat("Smallest Size", 1) <= 0.8)
        {
            unlockedUpgradesCount += 1;
            locks[4].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Size", 0) <= 0.6)
            {
                unlockedUpgradesCount += 1;
                locks[5].SetActive(false);
                if (PlayerPrefs.GetFloat("Smallest Size", 0) <= 0.4)
                {
                    unlockedUpgradesCount += 1;
                    locks[6].SetActive(false);
                    if (PlayerPrefs.GetFloat("Smallest Size", 0) <= 0.2)
                    {
                        unlockedUpgradesCount += 1;
                        locks[7].SetActive(false);
                    }
                }
            }

        }
        if (PlayerPrefs.GetFloat("Smallest Spread", 5) <= 4)
        {
            unlockedUpgradesCount += 1;
            locks[11].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 3)
            {
                unlockedUpgradesCount += 1;
                locks[10].SetActive(false);
                if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 2)
                {
                    unlockedUpgradesCount += 1;
                    locks[9].SetActive(false);
                    if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 1)
                    {
                        unlockedUpgradesCount += 1;
                        locks[8].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetFloat("Largest Spread", 5) >= 6)
        {
            unlockedUpgradesCount += 1;
            locks[12].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 7)
            {
                unlockedUpgradesCount += 1;
                locks[13].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 8)
                {
                    unlockedUpgradesCount += 1;
                    locks[14].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 9)
                    {
                        unlockedUpgradesCount += 1;
                        locks[15].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetFloat("Largest Speed", 10) >= 15)
        {
            unlockedUpgradesCount += 1;
            locks[19].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 20)
            {
                unlockedUpgradesCount += 1;
                locks[18].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 25)
                {
                    unlockedUpgradesCount += 1;
                    locks[17].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 30)
                    {
                        unlockedUpgradesCount += 1;
                        locks[16].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetFloat("Smallest Speed", 10) <= 9)
        {
            unlockedUpgradesCount += 1;
            locks[20].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Speed", 0) <= 8)
            {
                unlockedUpgradesCount += 1;
                locks[21].SetActive(false);
                if (PlayerPrefs.GetFloat("Smallest Speed", 0) <= 7)
                {
                    unlockedUpgradesCount += 1;
                    locks[22].SetActive(false);
                    if (PlayerPrefs.GetFloat("Smallest Speed", 0) <= 6)
                    {
                        unlockedUpgradesCount += 1;
                        locks[23].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("Most Lives", 0) >= 10)
        {
            unlockedUpgradesCount += 1;
            locks[24].SetActive(false);
            if (PlayerPrefs.GetInt("Most Lives", 0) >= 20)
            {
                unlockedUpgradesCount += 1;
                locks[25].SetActive(false);
                if (PlayerPrefs.GetInt("Most Lives", 0) >= 30)
                {
                    unlockedUpgradesCount += 1;
                    locks[26].SetActive(false);
                    if (PlayerPrefs.GetInt("Most Lives", 0) >= 50)
                    {
                        unlockedUpgradesCount += 1;
                        locks[27].SetActive(false);
                        if (PlayerPrefs.GetInt("Most Lives", 0) >= 75)
                        {
                            unlockedUpgradesCount += 1;
                            locks[28].SetActive(false);
                            if (PlayerPrefs.GetInt("Most Lives", 0) >= 100)
                            {
                                unlockedUpgradesCount += 1;
                                locks[29].SetActive(false);
                                if (PlayerPrefs.GetInt("Most Lives", 0) >= 150)
                                {
                                    unlockedUpgradesCount += 1;
                                    locks[30].SetActive(false);
                                    if (PlayerPrefs.GetInt("Most Lives", 0) >= 200)
                                    {
                                        unlockedUpgradesCount += 1;
                                        locks[31].SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        PlayerPrefs.SetInt("Unlocked Upgrades", unlockedUpgradesCount);

        sizeText.text = PlayerPrefs.GetFloat("Start Size", 1).ToString();
        spreadText.text = PlayerPrefs.GetInt("Start Spread", 5).ToString();
        speedText.text = PlayerPrefs.GetInt("Start Speed", 10).ToString();
        livesText.text = PlayerPrefs.GetInt("Start Lives", 0).ToString();

        sizeIconText.text = PlayerPrefs.GetFloat("Start Size", 1).ToString();
        spreadIconText.text = PlayerPrefs.GetInt("Start Spread", 5).ToString();
        speedIconText.text = PlayerPrefs.GetInt("Start Speed", 10).ToString();
        livesIconText.text = PlayerPrefs.GetInt("Start Lives", 0).ToString();
    }

    public void SizeMenu()
    {
        sizeMenu.SetActive(true);
    }

    public void SpreadMenu()
    {
        spreadMenu.SetActive(true);
    }

    public void SpeedMenu()
    {
        speedMenu.SetActive(true);
    }

    public void LivesMenu()
    {
        livesMenu.SetActive(true);
    }

    public void BackToUpgradeMenu()
    {
        sizeMenu.SetActive(false);
        spreadMenu.SetActive(false);
        speedMenu.SetActive(false);
        livesMenu.SetActive(false);
    }

    public void BackToUpgrades()
    {
        lockPopup.SetActive(false);
    }
}