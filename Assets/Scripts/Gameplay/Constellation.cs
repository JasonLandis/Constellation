using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Constellation : MonoBehaviour
{
    public GameObject constellationStar;
    public List<Vector3> constellationVectors;
    public GameObject constellationMap;

    public void GenerateConstellation()
    {
        for (int i = 9640; i < 10360; i += 10)
        {
            for (int j = 9640; j < 10360; j += 10)
            {
                int rand = Random.Range(0, 15);
                if (rand == 0 && (i != 10000 && j != 10000))
                {
                    // Selects a random scale
                    float randScale = Random.Range(2.5f, 5f);
                    constellationStar.transform.localScale = new Vector3(randScale, randScale, 1);

                    // Selects a random bright color
                    int red = Random.Range(50, 256);
                    int green = Random.Range(50, 256);
                    int blue = Random.Range(50, 256);

                    // Instantiates the star and adds it to the list of constellation vectors
                    constellationStar.GetComponent<SpriteRenderer>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                    Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                    constellationVectors.Add(new(i, j, 0));
                }
            }
        }
    }

    void Start()
    {
        GenerateConstellation();
    }
}
