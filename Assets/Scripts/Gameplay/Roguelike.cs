using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Roguelike : MonoBehaviour
{
    public GameManager gameManager;

    // UI component
    [Header("Objects")]
    public GameObject roguelike;
    public GameObject arrows;

    // Parent objects
    [Header("Containers")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    // Abilities
    [Header("Abilities")]
    public List<GameObject> abilities;
    public List<GameObject> rarityList;

    // Text
    [Header("Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI speedText;

    // Passive ability functions
    public void HeartOne()
    {
        gameManager.lives += 1;
        livesText.text = gameManager.lives.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void HeartTwo()
    {
        gameManager.lives += 2;
        livesText.text = gameManager.lives.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void HeartThree()
    {
        gameManager.lives += 3;
        livesText.text = gameManager.lives.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void SizeOne()
    {
        gameManager.size -= 0.125f;
        if (gameManager.size < 0)
        {
            gameManager.size = 0;
        }
        sizeText.text = gameManager.size.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SizeTwo()
    {
        gameManager.size -= 0.25f;
        if (gameManager.size < 0)
        {
            gameManager.size = 0;
        }
        sizeText.text = gameManager.size.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SizeThree()
    {
        gameManager.size -= 0.5f;
        if (gameManager.size < 0)
        {
            gameManager.size = 0;
        }
        sizeText.text = gameManager.size.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void DistanceOne()
    {
        gameManager.distance += 0.2f;
        if (gameManager.distance > 10)
        {
            gameManager.distance = 10;
        }
        distanceText.text = gameManager.distance.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void DistanceTwo()
    {
        gameManager.distance += 0.4f;
        if (gameManager.distance > 10)
        {
            gameManager.distance = 10;
        }
        distanceText.text = gameManager.distance.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void DistanceThree()
    {
        gameManager.distance += 0.8f;
        if (gameManager.distance > 10)
        {
            gameManager.distance = 10;
        }
        distanceText.text = gameManager.distance.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void SpeedOne()
    {
        gameManager.speed -= 0.5f;
        if (gameManager.speed < 1)
        {
            gameManager.speed = 1;
        }
        speedText.text = gameManager.speed.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SpeedTwo()
    {
        gameManager.speed -= 1;
        if (gameManager.speed < 1)
        {
            gameManager.speed = 1;
        }
        speedText.text = gameManager.speed.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SpeedThree()
    {
        gameManager.speed -= 2f;
        if (gameManager.speed < 1)
        {
            gameManager.speed = 1;
        }
        speedText.text = gameManager.speed.ToString();
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    
    // Activated ability functions
    public void ShieldOne()
    {
        DestroyRoguelike();
        Debug.Log("Shield 1");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void ShieldTwo()
    {
        DestroyRoguelike();
        Debug.Log("Shield 2");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void ShieldThree()
    {
        DestroyRoguelike();
        Debug.Log("Shield 3");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void InstantOne()
    {
        DestroyRoguelike();
        Debug.Log("Instant 1");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void InstantTwo()
    {
        DestroyRoguelike();
        Debug.Log("Instant 2");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void InstantThree()
    {
        DestroyRoguelike();
        Debug.Log("Instant 3");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void ShrinkOne()
    {
        DestroyRoguelike();
        Debug.Log("Shrink 1");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void ShrinkTwo()
    {
        DestroyRoguelike();
        Debug.Log("Shrink 2");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void ShrinkThree()
    {
        DestroyRoguelike();
        Debug.Log("Shrink 3");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void SlowOne()
    {
        DestroyRoguelike();
        Debug.Log("Slow 1");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SlowTwo()
    {
        DestroyRoguelike();
        Debug.Log("Slow 2");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SlowThree()
    {
        DestroyRoguelike();
        Debug.Log("Slow 3");
        roguelike.SetActive(false);
        arrows.SetActive(true);
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

        arrows.SetActive(false);
        roguelike.SetActive(true);
    }
    public void DestroyRoguelike()
    {
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

    private void Start()
    {
        for (int i = 0; i < 5;  i++)
        {
            rarityList.Add(abilities[0]);
            rarityList.Add(abilities[1]);
            rarityList.Add(abilities[2]);
            rarityList.Add(abilities[3]);
            rarityList.Add(abilities[4]);
            rarityList.Add(abilities[5]);
            rarityList.Add(abilities[6]);
            rarityList.Add(abilities[7]);
        }

        for (int i = 0; i < 3; i++)
        {
            rarityList.Add(abilities[8]);
            rarityList.Add(abilities[9]);
            rarityList.Add(abilities[10]);
            rarityList.Add(abilities[11]);
            rarityList.Add(abilities[12]);
            rarityList.Add(abilities[13]);
            rarityList.Add(abilities[14]);
            rarityList.Add(abilities[15]);
        }

        rarityList.Add(abilities[16]);
        rarityList.Add(abilities[17]);
        rarityList.Add(abilities[18]);
        rarityList.Add(abilities[19]);
        rarityList.Add(abilities[20]);
        rarityList.Add(abilities[21]);
        rarityList.Add(abilities[22]);
        rarityList.Add(abilities[23]);
    }
}
