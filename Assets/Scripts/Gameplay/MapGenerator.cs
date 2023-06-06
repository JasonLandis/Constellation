using UnityEngine;
using UnityEngine.Rendering.Universal;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    public GameObject meteor;

    public void GenerateMap(float difficulty, int mapLength)
    {
        // Create meteors
        for (float i = -5; i < 5; i += difficulty)
        {
            for (float j = 12; j < mapLength - 16; j += difficulty)
            {
                float x = Random.Range(i, i + difficulty);
                float y = Random.Range(j, j + difficulty);
          
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);
            }
        }
    }
}
