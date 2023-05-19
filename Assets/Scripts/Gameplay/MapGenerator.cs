using System.Collections.Generic;
using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Customizable")]
    [SerializeField] private int difficulty;

    [Header("Objects")]
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject barrier;

    public void GenerateMap()
    {
        // Create meteors
        for (int i = -5; i < 5; i += difficulty)
        {
            for (int j = 5; j < 80; j += difficulty)
            {
                int x = Random.Range(i, i + difficulty);
                int y = Random.Range(j, j + difficulty);
                Instantiate(meteor, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }

        // Create end barrier
        Instantiate(barrier, new Vector3(0, 85, 0), Quaternion.identity, transform);
    }

    void Start()
    {
        GenerateMap();
    }
}
