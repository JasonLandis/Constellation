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

                // Generates a random scale
                float rand = Random.Range(0.5f, 2f);
                meteor.transform.localScale = new Vector3(rand, rand, 1);

                // Generates a random bright color
                int red = Random.Range(100, 256);
                int green = Random.Range(100, 256);
                int blue = Random.Range(100, 256);

                // Instantiates the meteor
                meteor.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255, 1);
                meteor.GetComponent<Light2D>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);
            }
        }
    }
}
