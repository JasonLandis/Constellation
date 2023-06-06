using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    public GameObject constellationStar;
    public List<Vector3> constellationVectors;

    public void GenerateConstellation()
    {
        for (int i = -1350; i < 1350; i += 10)
        {
            for (int j = -1350; j < 1350; j += 10)
            {
                int rand = Random.Range(0, 10);
                if (rand == 0 && (i != 0 && j != 0))
                {                    
                    Instantiate(constellationStar, new(10000 + i, 10000 + j, 0), Quaternion.identity, transform);
                    constellationVectors.Add(new(10000 + i, 10000 + j, 0));
                }
            }
        }
    }

    void Start()
    {
        GenerateConstellation();
    }
}
