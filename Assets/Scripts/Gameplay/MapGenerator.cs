using UnityEngine;
using UnityEngine.Rendering.Universal;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    public GameObject meteor;

    public void GenerateMap(float distance, int mapLength, float size)
    {
        // Create meteors
        for (float i = -5; i < 5; i += distance)
        {
            for (float j = 12; j < mapLength - 16; j += distance)
            {
                float x = Random.Range(i, i + distance);
                float y = Random.Range(j, j + distance);

                // Generates a random bright color
                int red = Random.Range(50, 256);
                int green = Random.Range(50, 256);
                int blue = Random.Range(50, 256);

                // Instantiates the meteor
                meteor.transform.localScale = new Vector3(size, size, 1);
                meteor.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);
            }
        }
    }
}
