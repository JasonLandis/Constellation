using System.Collections.Generic;
using UnityEngine;

public class Roguelike : MonoBehaviour
{
    [Header("Objects")]
    public GameObject roguelike;
    public GameObject direction;

    [Header("Containers")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    [Header("Abilities")]
    public List<GameObject> abilities;
    public List<GameObject> rarityList;

    [Header("Scripts")]
    public GameUI gameUI;

    private void Start()
    {
        GameManager.instance.showRoguelike += ShowRoguelike;

        for (int i = 0; i < 100; i++)
        {
            rarityList.Add(abilities[0]);
            rarityList.Add(abilities[4]);
            rarityList.Add(abilities[8]);
        }

        for (int i = 0; i < 60; i++)
        {
            rarityList.Add(abilities[1]);
            rarityList.Add(abilities[5]);
            rarityList.Add(abilities[9]);
        }

        for (int i = 0; i < 30; i++)
        {
            rarityList.Add(abilities[2]);
            rarityList.Add(abilities[6]);
            rarityList.Add(abilities[10]);

            rarityList.Add(abilities[12]);
        }

        for (int i = 0; i < 15; i++)
        {
            rarityList.Add(abilities[3]);
            rarityList.Add(abilities[7]);
            rarityList.Add(abilities[11]);

            rarityList.Add(abilities[13]);
        }

        for (int i = 0; i < 5; i++)
        {
            rarityList.Add(abilities[14]);
        }

        rarityList.Add(abilities[15]);
    }

    // Functions for the heart ability
    public void HeartOne()
    {
        GameManager.instance.lives += 1;
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void HeartTwo()
    {
        GameManager.instance.lives += 2;
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void HeartThree()
    {
        GameManager.instance.lives += 3;
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void HeartFour()
    {
        GameManager.instance.lives += 5;
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }

    // Functions for the size ability
    public void SizeOne()
    {
        GameManager.instance.size -= 0.1f;
        if (GameManager.instance.size < 0.1f)
        {
            GameManager.instance.size = 0.1f;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SizeTwo()
    {
        GameManager.instance.size -= 0.2f;
        if (GameManager.instance.size < 0.1f)
        {
            GameManager.instance.size = 0.1f;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SizeThree()
    {
        GameManager.instance.size -= 0.3f;
        if (GameManager.instance.size < 0.1f)
        {
            GameManager.instance.size = 0.1f;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SizeFour()
    {
        GameManager.instance.size -= 0.4f;
        if (GameManager.instance.size < 0.1f)
        {
            GameManager.instance.size = 0.1f;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }

    // Functions for the spread ability
    public void SpreadOne()
    {
        GameManager.instance.spread += 0.3f;
        if (GameManager.instance.spread > 20)
        {
            GameManager.instance.spread = 20;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpreadTwo()
    {
        GameManager.instance.spread += 0.6f;
        if (GameManager.instance.spread > 20)
        {
            GameManager.instance.spread = 20;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpreadThree()
    {
        GameManager.instance.spread += 1;
        if (GameManager.instance.spread > 20)
        {
            GameManager.instance.spread = 20;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpreadFour()
    {
        GameManager.instance.spread += 1.5f;
        if (GameManager.instance.spread > 20)
        {
            GameManager.instance.spread = 20;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }

    // Functions for the speed ability
    public void SpeedOne()
    {
        GameManager.instance.speed -= 0.5f;
        if (GameManager.instance.speed < 1)
        {
            GameManager.instance.speed = 1;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpeedTwo()
    {
        GameManager.instance.speed -= 1;
        if (GameManager.instance.speed < 1)
        {
            GameManager.instance.speed = 1;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpeedThree()
    {
        GameManager.instance.speed -= 1.5f;
        if (GameManager.instance.speed < 1)
        {
            GameManager.instance.speed = 1;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }
    public void SpeedFour()
    {
        GameManager.instance.speed -= 2;
        if (GameManager.instance.speed < 1)
        {
            GameManager.instance.speed = 1;
        }
        gameUI.ShowGameplayText();
        DestroyRoguelike();
        roguelike.SetActive(false);
        direction.SetActive(true);
    }

    // Show roguelike feature
    public void ShowRoguelike()
    {
        GameObject ability1;
        GameObject ability2;
        GameObject ability3;
        int rand;

        rand = Random.Range(0, rarityList.Count);
        ability1 = rarityList[rand];
        Instantiate(ability1, item1.transform.position, Quaternion.identity, item1.transform);

        rand = Random.Range(0, rarityList.Count);
        ability2 = rarityList[rand];

        while (true)
        {
            if (ability1 == ability2)
            {
                rand = Random.Range(0, rarityList.Count);
                ability2 = rarityList[rand];
            }
            else
            {
                Instantiate(ability2, item2.transform.position, Quaternion.identity, item2.transform);
                break;
            }
        }

        rand = Random.Range(0, rarityList.Count);
        ability3 = rarityList[rand];

        while (true)
        {
            if (ability1 == ability3 || ability2 == ability3)
            {
                rand = Random.Range(0, rarityList.Count);
                ability3 = rarityList[rand];
            }
            else
            {
                Instantiate(ability3, item3.transform.position, Quaternion.identity, item3.transform);
                break;
            }
        }

        direction.SetActive(false);
        roguelike.SetActive(true);
    }

    // Destroy old roguelike components
    public void DestroyRoguelike()
    {
        GameManager.instance.SaveGameScores();
        foreach (Transform child in item1.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in item2.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in item3.transform)
        {
            Destroy(child.gameObject);
        }
    }
}