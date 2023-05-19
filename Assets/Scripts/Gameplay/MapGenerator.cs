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
    [SerializeField] private List<GameObject> Arrows;

    public void GenerateMap()
    {
        // Create meteors
        for (int i = -10; i < 10; i += difficulty)
        {
            for (int j = 10; j < 80; j += difficulty)
            {
                int x = Random.Range(i, i + difficulty);
                int y = Random.Range(j, j + difficulty);
                Instantiate(meteor, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }

        // Create slow barrier
        Instantiate(barrier, new Vector3(0, 85, 0), Quaternion.identity, transform);

        /* Create arrows
        for (float i = -6.75f; i <= 6.75f; i += 4.5f)
        {
            int index = Random.Range(0, Arrows.Count);
            Instantiate(Arrows[index], new Vector3(i, 92, 0), Quaternion.identity, transform);
        }
        */
    }

    void Start()
    {
        GenerateMap();
    }
}
