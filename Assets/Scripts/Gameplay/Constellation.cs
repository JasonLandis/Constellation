using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Constellation : MonoBehaviour
{
    public GameObject constellationStar;
    public List<Vector3> constellationVectors;

    public void GenerateConstellation()
    {
        for (int i = 650; i < 1350; i += 10)
        {
            for (int j = 650; j < 1350; j += 10)
            {
                int rand = Random.Range(0, 15);
                if (rand == 0 && (i != 1000 && j != 1000))
                {
                    // Selects a random scale
                    float randScale = Random.Range(2.5f, 5f);
                    constellationStar.transform.localScale = new Vector3(randScale, randScale, 1);

                    // Selects a random bright color
                    int red = Random.Range(0, 256);
                    int green = Random.Range(0, 256);
                    int blue = Random.Range(0, 256);

                    // Instantiates the star and adds it to the list of constellation vectors
                    constellationStar.GetComponent<SpriteRenderer>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                    Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, transform);
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
