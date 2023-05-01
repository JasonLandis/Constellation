using System;
using System.Collections.Generic;
using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{    
    public GameObject blockade;

    public GameObject barrier;

    public List<GameObject> Arrows;

    public int difficulty;


    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        // generate the map
        for (int i = -10; i < 10; i += difficulty)
        {
            for (int j = 10; j < 80; j += difficulty)
            {
                int x = UnityEngine.Random.Range(i, i + difficulty);
                int y = UnityEngine.Random.Range(j, j + difficulty);
                // instantiate the blocks as children of the map
                Instantiate(blockade, new Vector3(x, y, 0), Quaternion.identity, transform);
            }
        }

        // generate the barriers
        Instantiate(barrier, new Vector3(0, 85, 0), Quaternion.identity, transform);
        
        // randomly pick 4 arrows from the list
        for (float i = -6.75f; i <= 6.75f; i += 4.5f)
        {
            int index = UnityEngine.Random.Range(0, Arrows.Count);
            Instantiate(Arrows[index], new Vector3(i, 92, 0), Quaternion.identity, transform);
        }
    }
}
