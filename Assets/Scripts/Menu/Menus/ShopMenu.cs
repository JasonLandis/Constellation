using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [Header("Locked Text")]
    public GameObject lockPopup;
    public TextMeshProUGUI description;

    [Header("Skin Objects")]
    public List<GameObject> icons;
    public GameObject playerIcon;
    public GameObject playerPrefab;
    public GameObject starPrefab;

    [Header("Lock Objects")]
    public List<GameObject> locks;
    [HideInInspector] public List<string> lockedText;

    [Header("Skin Screens")]
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;

    private int activeScreen = 1;

    public void LoadSkinLocks()
    {
        lockedText.Add(" ");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>1,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>2,500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>High Score</color> of <color=#11DC58>5,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Universe Score</color> of <color=#11DC58>500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Universe Score</color> of <color=#11DC58>1,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Universe Score</color> of <color=#11DC58>1,500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance Traveled</color> of <color=#11DC58>2,500</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance Traveled</color> of <color=#11DC58>5,000</color>");
        lockedText.Add("Achieve a <color=#00C9FF>Total Distance Traveled</color> of <color=#11DC58>10,000</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Universe Score</color> of <color=#11DC58>300</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Universe Score</color> of <color=#11DC58>240</color>");
        lockedText.Add("Clear a universe <color=#E54B4B>before</color> reaching a <color=#00C9FF>Universe Score</color> of <color=#11DC58>180</color>");
        lockedText.Add("Clear <color=#11DC58>3</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>6</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>10</color> universes <color=#00C9FF>in one run</color>");
        lockedText.Add("Clear <color=#11DC58>10</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>25</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>50</color> <color=#00C9FF>Total Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Easy Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Easy Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Normal Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Normal Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Hard Universes</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>Hard Universes</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>15</color> <color=#00C9FF>universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Easy Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Easy Universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Normal Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Normal Universes</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>1</color> <color=#00C9FF>Hard Universe</color> <color=#E54B4B>without being hit</color>");
        lockedText.Add("Clear <color=#11DC58>5</color> <color=#00C9FF>Hard Universes</color> <color=#E54B4B>without being hit</color>");  
        lockedText.Add("Unlock <color=#11DC58>10</color> <color=#00C9FF>Upgrades</color>");
        lockedText.Add("Unlock <color=#11DC58>20</color> <color=#00C9FF>Upgrades</color>");
        lockedText.Add("Unlock <color=#11DC58>All</color> <color=#00C9FF>Upgrades</color>");
        lockedText.Add("Unlock <color=#11DC58>5</color> <color=#00C9FF>Stars</color>");
        lockedText.Add("Unlock <color=#11DC58>10</color> <color=#00C9FF>Stars</color>");
        lockedText.Add("Unlock <color=#11DC58>20</color> <color=#00C9FF>Stars</color>");
        lockedText.Add("Unlock <color=#11DC58>30</color> <color=#00C9FF>Stars</color>");
        lockedText.Add("Unlock <color=#11DC58>All</color> <color=#00C9FF>Stars</color>");

        int unlockCount = 2;
        if (PlayerPrefs.GetInt("High Score", 0) >= 1000)
        {
            unlockCount += 1;
            locks[1].SetActive(false);
            if (PlayerPrefs.GetInt("High Score", 0) >= 2500)
            {
                unlockCount += 1;
                locks[2].SetActive(false);
                if (PlayerPrefs.GetInt("High Score", 0) >= 5000)
                {
                    unlockCount += 1;
                    locks[3].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt("Universe Score", 0) >= 500)
        {
            unlockCount += 1;
            locks[4].SetActive(false);
            if (PlayerPrefs.GetInt("Universe Score", 0) >= 1000)
            {
                unlockCount += 1;
                locks[5].SetActive(false);
                if (PlayerPrefs.GetInt("Universe Score", 0) >= 1500)
                {
                    unlockCount += 1;
                    locks[6].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt("Total Distance", 0) >= 2500)
        {
            unlockCount += 1;
            locks[7].SetActive(false);
            if (PlayerPrefs.GetInt("Total Distance", 0) >= 5000)
            {
                unlockCount += 1;
                locks[8].SetActive(false);
                if (PlayerPrefs.GetInt("Total Distance", 0) >= 10000)
                {
                    unlockCount += 1;
                    locks[9].SetActive(false);
                }
            }
        }
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            if (PlayerPrefs.GetInt("Quickest Universe") < 300)
            {
                unlockCount += 1;
                locks[10].SetActive(false);
                if (PlayerPrefs.GetInt("Quickest Universe") < 240)
                {
                    unlockCount += 1;
                    locks[11].SetActive(false);
                    if (PlayerPrefs.GetInt("Quickest Universe") < 180)
                    {
                        unlockCount += 1;
                        locks[12].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetInt("Most Universes", 0) >= 3)
        {
            unlockCount += 1;
            locks[13].SetActive(false);
            if (PlayerPrefs.GetInt("Most Universes", 0) >= 6)
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
        if (PlayerPrefs.GetInt("Total Universes", 0) >= 10)
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
            if (PlayerPrefs.GetInt("Normal Universes", 0) >= 15)
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
        if (PlayerPrefs.GetInt("Unlocked Upgrades", 0) >= 10)
        {
            unlockCount += 1;
            locks[33].SetActive(false);
            if (PlayerPrefs.GetInt("Unlocked Upgrades", 0) >= 20)
            {
                unlockCount += 1;
                locks[34].SetActive(false);
                if (PlayerPrefs.GetInt("Unlocked Upgrades", 0) >= 32)
                {
                    unlockCount += 1;
                    locks[35].SetActive(false);
                }
            }
        }
        if (unlockCount >= 5)
        {
            unlockCount += 1;
            locks[36].SetActive(false);
            if (unlockCount >= 10)
            {
                unlockCount += 1;
                locks[37].SetActive(false);
                if (unlockCount >= 20)
                {
                    unlockCount += 1;
                    locks[38].SetActive(false);
                    if (unlockCount >= 30)
                    {
                        unlockCount += 1;
                        locks[39].SetActive(false);
                        if (unlockCount >= 39)
                        {
                            locks[40].SetActive(false);
                        }
                    }
                }
            }
        }
        if (unlockCount >= PlayerPrefs.GetInt("Unlocked Icons", 1))
        {
            PlayerPrefs.SetInt("Unlocked Icons", unlockCount);
        }

        if (PlayerPrefs.HasKey("Red"))
        {
            playerIcon.GetComponent<Image>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);
            playerPrefab.GetComponent<SpriteRenderer>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);
            starPrefab.GetComponent<SpriteRenderer>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);

            playerIcon.GetComponent<Light2D>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);
            playerPrefab.GetComponent<Light2D>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);
            starPrefab.GetComponent<Light2D>().color = new(PlayerPrefs.GetFloat("Red"), PlayerPrefs.GetFloat("Green"), PlayerPrefs.GetFloat("Blue"), 1);
        }
        else
        {
            playerIcon.GetComponent<Image>().color = new(1, 1, 1, 1);
            playerPrefab.GetComponent<SpriteRenderer>().color = new(1, 1, 1, 1);
            starPrefab.GetComponent<SpriteRenderer>().color = new(1, 1, 1, 1);

            playerIcon.GetComponent<Light2D>().color = new(1, 1, 1, 1);
            playerPrefab.GetComponent<Light2D>().color = new(1, 1, 1, 1);
            starPrefab.GetComponent<Light2D>().color = new(1, 1, 1, 1);
        }
    }

    public void SwapRight()
    {
        if (activeScreen == 1)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);
            activeScreen = 2;
        }
        else if (activeScreen == 2)
        {
            screen2.SetActive(false);
            screen3.SetActive(true);
            activeScreen = 3;
        }
        else if (activeScreen == 3)
        {
            screen3.SetActive(false);
            screen4.SetActive(true);
            activeScreen = 4;
        }
        else
        {
            screen4.SetActive(false);
            screen1.SetActive(true);
            activeScreen = 1;
        }
    }

    public void SwapLeft()
    {
        if (activeScreen == 1)
        {
            screen1.SetActive(false);
            screen4.SetActive(true);
            activeScreen = 4;
        }
        else if (activeScreen == 2)
        {
            screen2.SetActive(false);
            screen1.SetActive(true);
            activeScreen = 1;
        }
        else if (activeScreen == 3)
        {
            screen3.SetActive(false);
            screen2.SetActive(true);
            activeScreen = 2;
        }
        else
        {
            screen4.SetActive(false);
            screen3.SetActive(true);
            activeScreen = 3;
        }
    }

    public void BackToShop()
    {
        lockPopup.SetActive(false);
    }
}
