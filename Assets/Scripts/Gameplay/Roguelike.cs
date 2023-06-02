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

    // Ability functions
    public void OneHeart()
    {
        DestroyRoguelike();
        gameManager.lives += 1;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void TwoHearts()
    {
        DestroyRoguelike();
        gameManager.lives += 2;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void ThreeHearts()
    {
        DestroyRoguelike();
        gameManager.lives += 3;
        livesText.text = gameManager.lives.ToString();
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    public void Shield()
    {
        DestroyRoguelike();
        Debug.Log("Shield");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void Speed()
    {
        DestroyRoguelike();
        Debug.Log("Speed");
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
