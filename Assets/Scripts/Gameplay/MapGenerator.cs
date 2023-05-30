using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject meteor1;
    [SerializeField] private GameObject meteor2;
    [SerializeField] private GameObject meteor3;
    [SerializeField] private GameObject meteor4;

    public void GenerateMap()
    {
        // Create meteors
        for (float i = -5; i < 5; i += GameManager.instance.difficulty)
        {
            for (float j = 8; j < GameManager.instance.mapLength - 8; j += GameManager.instance.difficulty)
            {
                float x = Random.Range(i, i + GameManager.instance.difficulty);
                float y = Random.Range(j, j + GameManager.instance.difficulty);
                int rand = Random.Range(1, 5);
                if (rand == 1)
                {
                    Instantiate(meteor1, new(x, y, 0), Quaternion.identity, transform);
                }
                else if (rand == 2)
                {
                    Instantiate(meteor2, new(x, y, 0), Quaternion.identity, transform);
                }
                else if (rand == 3)
                {
                    Instantiate(meteor3, new(x, y, 0), Quaternion.identity, transform);
                }
                else if (rand == 4)
                {
                    Instantiate(meteor4, new(x, y, 0), Quaternion.identity, transform);
                }
            }
        }
    }

    void Start()
    {
        GenerateMap();
    }
}
