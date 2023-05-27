using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class MapGenerator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject powerup;

    public void GenerateMap()
    {
        // Create meteors
        for (int i = -5; i < 5; i += GameManager.instance.difficulty)
        {
            for (int j = 8; j < GameManager.instance.mapLength - 8; j += GameManager.instance.difficulty)
            {
                int x = Random.Range(i, i + GameManager.instance.difficulty);
                int y = Random.Range(j, j + GameManager.instance.difficulty);
                int val = Random.Range(0, 30);
                if (val == 1)
                {
                    Instantiate(powerup, new(x, y, 0), Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(meteor, new(x, y, 0), Quaternion.identity, transform);
                }
            }
        }
    }

    void Start()
    {
        GenerateMap();
    }
}
