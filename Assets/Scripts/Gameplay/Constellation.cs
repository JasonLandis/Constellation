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
        for (int i = 550; i < 1450; i += 10)
        {
            for (int j = 550; j < 1450; j += 10)
            {
                if (i > 945 && i < 1055 && j > 945 && j < 1055)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        if (i != 1000 && j != 1000)
                        {
                            Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                            constellationVectors.Add(new(i, j, 0));
                        }
                    }
                }
                else if (i > 895 && i < 1105 && j > 895 && j < 1105)
                {
                    rand = Random.Range(0, 16);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 845 && i < 1155 && j > 845 && j < 1155)
                {
                    rand = Random.Range(0, 24);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 795 && i < 1205 && j > 795 && j < 1205)
                {
                    rand = Random.Range(0, 32);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 745 && i < 1255 && j > 745 && j < 1255)
                {
                    rand = Random.Range(0, 40);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 695 && i < 1305 && j > 695 && j < 1305)
                {
                    rand = Random.Range(0, 48);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 645 && i < 1355 && j > 645 && j < 1355)
                {
                    rand = Random.Range(0, 56);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 595 && i < 1405 && j > 595 && j < 1405)
                {
                    rand = Random.Range(0, 64);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 545 && i < 1455 && j > 545 && j < 1455)
                {
                    rand = Random.Range(0, 72);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationMap.transform);
                        constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > 495 && i < 1505 && j > 495 && j < 1505)
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
