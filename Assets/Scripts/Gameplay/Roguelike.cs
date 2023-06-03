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

    // Text
    [Header("Text")]
    public TextMeshProUGUI livesText;

    [Header("Customizable")]
    public float countdownTime;

    // Passive ability functions
    public void HeartOne()
    {
        DestroyRoguelike();
        gameManager.lives += 1;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void HeartTwo()
    {
        DestroyRoguelike();
        gameManager.lives += 2;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void HeartThree()
    {
        DestroyRoguelike();
        gameManager.lives += 3;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void SizeOne()
    {
        Debug.Log("Size 1");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SizeTwo()
    {
        Debug.Log("Size 2");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SizeThree()
    {
        Debug.Log("Size 3");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void DistanceOne()
    {
        Debug.Log("Distance 1");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void DistanceTwo()
    {
        Debug.Log("Distance 2");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void DistanceThree()
    {
        Debug.Log("Distance 3");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void SpeedOne()
    {
        Debug.Log("Speed 1");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SpeedTwo()
    {
        Debug.Log("Speed 2");
        DestroyRoguelike();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void SpeedThree()
    {
        Debug.Log("Speed 3");
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

        rand = Random.Range(0, abilities.Count);
        ability1 = abilities[rand];
        Instantiate(ability1, item1.transform.position, Quaternion.identity, item1.transform);

        rand = Random.Range(0, abilities.Count);
        ability2 = abilities[rand];

        while (true)
        {
            if (ability1 == ability2)
            {
                rand = Random.Range(0, abilities.Count);
                ability2 = abilities[rand];
            }
            else
            {
                Instantiate(ability2, item2.transform.position, Quaternion.identity, item2.transform);
                break;
            }
        }

        rand = Random.Range(0, abilities.Count);
        ability3 = abilities[rand];

        while (true)
        {
            if (ability1 == ability3 || ability2 == ability3)
            {
                rand = Random.Range(0, abilities.Count);
                ability3 = abilities[rand];
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
}
