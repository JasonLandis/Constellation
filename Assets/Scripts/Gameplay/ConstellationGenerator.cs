using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ConstellationGenerator : MonoBehaviour
{
    public GameObject constellationStar;
    public List<Vector3> constellationVectors;

    void Start()
    {
        for (int i = 760; i < 1270; i += 10)
        {
            for (int j = 760; j < 1270;  j += 10)
            {
                int rand = Random.Range(0, 10);
                if (rand == 0 && (i != 1000 && j != 1000))
                {
                    // Selects a random scale
                    float randScale = Random.Range(2.5f, 5f);
                    constellationStar.transform.localScale = new Vector3(randScale, randScale, 1);

                    // Selects a random bright color
                    int red = Random.Range(100, 256);
                    int green = Random.Range(100, 256);
                    int blue = Random.Range(100, 256);

                    // Instantiates the star and adds it to the list of constellation vectors
                    constellationStar.GetComponent<SpriteRenderer>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                    constellationStar.GetComponent<Light2D>().color = new Color((float)red / 255, (float)green / 255, (float)blue / 255, 1);
                    Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, transform);
                    constellationVectors.Add(new(i, j, 0));
                }
            }
        }
    }
}
