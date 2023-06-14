using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    public GameObject meteor;
    public GameObject coin;

    public void GenerateMap(float distance, int mapLength, float size)
    {
        mapLength *= 10;
        // Create meteors
        for (float i = -5; i < 5; i += distance)
        {
            for (float j = 12; j < mapLength - 12; j += distance)
            {
                float x = Random.Range(i, i + distance);
                float y = Random.Range(j, j + distance);

                meteor.transform.localScale = new Vector3(size, size, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);
            }
        }
    }
}
