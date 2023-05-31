using UnityEngine;
using UnityEngine.Rendering.Universal;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject meteor;

    public void GenerateMap()
    {
        // Create meteors
        for (float i = -5; i < 5; i += GameManager.instance.difficulty)
        {
            for (float j = 12; j < GameManager.instance.mapLength - 16; j += GameManager.instance.difficulty)
            {
                float x = Random.Range(i, i + GameManager.instance.difficulty);
                float y = Random.Range(j, j + GameManager.instance.difficulty);

                float rand = Random.Range(0.5f, 2f);
                meteor.transform.localScale = new Vector3(rand, rand, 1);

                // Generate random RGB values
                int red = Random.Range(100, 256);
                int green = Random.Range(100, 256);
                int blue = Random.Range(100, 256);

                meteor.GetComponent<SpriteRenderer>().color = new Color((float)red/255, (float)green/255, (float)blue/255, 1);
                meteor.GetComponent<Light2D>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);

            }
        }
    }

    void Start()
    {
        GenerateMap();
    }
}
