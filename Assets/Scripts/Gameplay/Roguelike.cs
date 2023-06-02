using System.Collections.Generic;
using UnityEngine;

public class Roguelike : MonoBehaviour
{
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
    public GameObject heart;
    public GameObject shield;
    public GameObject shrink;
    public GameObject invisibility;
    public GameObject speed;

    // Ability functions
    public void Heart()
    {
        Debug.Log("Heart");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void Shield()
    {
        Debug.Log("Shield");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }
    public void Speed()
    {
        Debug.Log("Speed");
        roguelike.SetActive(false);
        arrows.SetActive(true);
    }

    // Show roguelike feature
    public void ShowRoguelike()
    {
        Instantiate(heart, item1.transform.position, Quaternion.identity, item1.transform);
        Instantiate(shield, item2.transform.position, Quaternion.identity, item2.transform);
        Instantiate(speed, item3.transform.position, Quaternion.identity, item3.transform);
        arrows.SetActive(false);
        roguelike.SetActive(true);        
    }
}
