using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [Header("Locked Text")]
    public GameObject lockPopup;
    public TextMeshProUGUI description;

    [Header("Objects")]
    public GameObject upgradesMenu;
    public GameObject sizeMenu;
    public GameObject spreadMenu;
    public GameObject speedMenu;
    public GameObject livesMenu;

    [Header("Transition")]
    public Image panel;
    public float color;
    public float duration;

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
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>3</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>2.5</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>2</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>1.5</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>0.8</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>0.6</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>0.4</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Size</color> of <color=#11DC58>0.2</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>2.6</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>3.2</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>3.8</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>4.4</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>7</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>8</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>9</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Spread</color> of <color=#11DC58>10</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>16</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>15</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>14</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>13</color> or greater");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>9</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>8</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>7</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with a <color=#00C9FF>Speed</color> of <color=#11DC58>6</color> or lower");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>2</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>5</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>8</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>10</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>12</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>15</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>18</color> or more <color=#00C9FF>Extra Lives</color>");
        lockedText.Add("<color=#E54B4B>Exit</color> a universe with <color=#11DC58>20</color> or more <color=#00C9FF>Extra Lives</color>");

        int unlockedUpgradesCount = 0;

        if (PlayerPrefs.GetFloat("Largest Size", 1) >= 1.5)
        {
            unlockedUpgradesCount += 1;
            locks[3].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Size", 0) >= 2)
            {
                unlockedUpgradesCount += 1;
                locks[2].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Size", 0) >= 2.5)
                {
                    unlockedUpgradesCount += 1;
                    locks[1].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Size", 0) >= 3)
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
        if (PlayerPrefs.GetFloat("Smallest Spread", 5) <= 4.4)
        {
            unlockedUpgradesCount += 1;
            locks[11].SetActive(false);
            if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 3.8)
            {
                unlockedUpgradesCount += 1;
                locks[10].SetActive(false);
                if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 3.2)
                {
                    unlockedUpgradesCount += 1;
                    locks[9].SetActive(false);
                    if (PlayerPrefs.GetFloat("Smallest Spread", 0) <= 2.6)
                    {
                        unlockedUpgradesCount += 1;
                        locks[8].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetFloat("Largest Spread", 5) >= 7)
        {
            unlockedUpgradesCount += 1;
            locks[12].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 8)
            {
                unlockedUpgradesCount += 1;
                locks[13].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 9)
                {
                    unlockedUpgradesCount += 1;
                    locks[14].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Spread", 0) >= 10)
                    {
                        unlockedUpgradesCount += 1;
                        locks[15].SetActive(false);
                    }
                }
            }
        }
        if (PlayerPrefs.GetFloat("Largest Speed", 10) >= 13)
        {
            unlockedUpgradesCount += 1;
            locks[19].SetActive(false);
            if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 14)
            {
                unlockedUpgradesCount += 1;
                locks[18].SetActive(false);
                if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 15)
                {
                    unlockedUpgradesCount += 1;
                    locks[17].SetActive(false);
                    if (PlayerPrefs.GetFloat("Largest Speed", 0) >= 16)
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
        if (PlayerPrefs.GetInt("Most Lives", 0) >= 2)
        {
            unlockedUpgradesCount += 1;
            locks[24].SetActive(false);
            if (PlayerPrefs.GetInt("Most Lives", 0) >= 5)
            {
                unlockedUpgradesCount += 1;
                locks[25].SetActive(false);
                if (PlayerPrefs.GetInt("Most Lives", 0) >= 8)
                {
                    unlockedUpgradesCount += 1;
                    locks[26].SetActive(false);
                    if (PlayerPrefs.GetInt("Most Lives", 0) >= 10)
                    {
                        unlockedUpgradesCount += 1;
                        locks[27].SetActive(false);
                        if (PlayerPrefs.GetInt("Most Lives", 0) >= 12)
                        {
                            unlockedUpgradesCount += 1;
                            locks[28].SetActive(false);
                            if (PlayerPrefs.GetInt("Most Lives", 0) >= 15)
                            {
                                unlockedUpgradesCount += 1;
                                locks[29].SetActive(false);
                                if (PlayerPrefs.GetInt("Most Lives", 0) >= 18)
                                {
                                    unlockedUpgradesCount += 1;
                                    locks[30].SetActive(false);
                                    if (PlayerPrefs.GetInt("Most Lives", 0) >= 20)
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
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(sizeMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void SpreadMenu()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(spreadMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void SpeedMenu()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(speedMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void LivesMenu()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransition(livesMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void BackToUpgrades()
    {
        lockPopup.SetActive(false);
    }

    private void FinishTransition(GameObject menu)
    {
        panel.raycastTarget = false;
        upgradesMenu.SetActive(false);
        menu.SetActive(true);
        LeanTween.color(panel.rectTransform, new(color, color, color, 0), duration);
    }

    public void MenuFromSize()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(sizeMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void MenuFromSpread()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(spreadMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void MenuFromSpeed()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(speedMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    public void MenuFromLives()
    {
        panel.raycastTarget = true;
        panel.color = new(color, color, color, 0);
        void action() => FinishTransitionBack(livesMenu);
        LeanTween.color(panel.rectTransform, new(color, color, color, 1), duration).setOnComplete(action);
    }

    private void FinishTransitionBack(GameObject menu)
    {
        panel.raycastTarget = false;
        menu.SetActive(false);
        upgradesMenu.SetActive(true);
        LeanTween.color(panel.rectTransform, new(color, color, color, 0), duration);
    }
}