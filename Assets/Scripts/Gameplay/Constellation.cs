using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    public GameObject constellationStar;
    public List<Vector3> constellationVectors;
    public GameObject constellationMap;

    public void GenerateConstellation()
    {
        int rand;
        for (int i = -450; i < 450; i += 10)
        {
            for (int j = -450; j < 450; j += 10)
            {
                if (i > -55 && i < 55 && j > -55 && j < 55)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        if (i != 0 && j != 0)
                        {
                            Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                            constellationVectors.Add(new(i, j, 0));
                        }
                    }
                }
                else if (i > -105 && i < 105 && j > -105 && j < 105)
                {
                    rand = Random.Range(0, 16);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -155 && i < 155 && j > -155 && j < 155)
                {
                    rand = Random.Range(0, 24);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -205 && i < 205 && j > -205 && j < 205)
                {
                    rand = Random.Range(0, 32);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -255 && i < 255 && j > -255 && j < 255)
                {
                    rand = Random.Range(0, 40);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -305 && i < 305 && j > -305 && j < 305)
                {
                    rand = Random.Range(0, 48);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -355 && i < 355 && j > -355 && j < 355)
                {
                    rand = Random.Range(0, 56);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -405 && i < 405 && j > -405 && j < 405)
                {
                    rand = Random.Range(0, 64);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -455 && i < 455 && j > -455 && j < 455)
                {
                    rand = Random.Range(0, 72);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -505 && i < 505 && j > -505 && j < 505)
                {
                    rand = Random.Range(0, 80);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
            }
        }
    }

    void Start()
    {
        GenerateConstellation();
    }
}
