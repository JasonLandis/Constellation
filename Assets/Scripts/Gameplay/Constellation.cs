using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    [Header("Objects")]
    public GameObject constellationStar;
    public GameObject placeholderStar;
    public GameObject constellationStars;
    public GameObject createdStars;
    public GameObject fullConstellation;
    public GameObject fullBackground;

    [Header("Cameras")]
    public Camera constellationCamera;
    public Camera fullCamera;

    [HideInInspector] public List<Vector3> vectors;
    private float smallestX = 0;
    private float largestX = 0;
    private float smallestY = 0;
    private float largestY = 0;

    void Start()
    {
        GenerateConstellation();
        GameManager.instance.createStar += CreateNewStar;
        GameManager.instance.moveCamera += MoveConstellationCamera;
    }

    // Generates stars on the constellation map
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
                            Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                            GameManager.instance.constellationVectors.Add(new(i, j, 0));
                        }
                    }
                }
                else if (i > -105 && i < 105 && j > -105 && j < 105)
                {
                    rand = Random.Range(0, 16);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -155 && i < 155 && j > -155 && j < 155)
                {
                    rand = Random.Range(0, 24);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -205 && i < 205 && j > -205 && j < 205)
                {
                    rand = Random.Range(0, 32);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -255 && i < 255 && j > -255 && j < 255)
                {
                    rand = Random.Range(0, 40);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -305 && i < 305 && j > -305 && j < 305)
                {
                    rand = Random.Range(0, 48);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -355 && i < 355 && j > -355 && j < 355)
                {
                    rand = Random.Range(0, 56);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -405 && i < 405 && j > -405 && j < 405)
                {
                    rand = Random.Range(0, 64);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -455 && i < 455 && j > -455 && j < 455)
                {
                    rand = Random.Range(0, 72);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -505 && i < 505 && j > -505 && j < 505)
                {
                    rand = Random.Range(0, 80);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
            }
        }
    }

    // Button function that shows the full constellation view
    public void ShowFullConstellation()
    {
        fullConstellation.SetActive(true);
        fullBackground.SetActive(true);
    }

    // Button function that hides the full constellation view
    public void HideFullConstellation()
    {
        fullConstellation.SetActive(false);
        fullBackground.SetActive(false);
    }

    // Moves the full camera to view the full constellation
    private void MoveFullCamera(List<Vector3> vectors)
    {
        // Resizes the full constellation camera
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        float addedWidth = 0;
        float addedHeight = 0;

        foreach (Vector3 vector in vectors)
        {
            if (vector.x < smallestX)
            {
                addedWidth = smallestX - vector.x;
                smallestX = vector.x;
                left = true;
            }

            if (vector.y < smallestY)
            {
                addedHeight = smallestY - vector.y;
                smallestY = vector.y;
                down = true;
            }

            if (vector.x > largestX)
            {
                addedWidth = vector.x - largestX;
                largestX = vector.x;
                right = true;
            }

            if (vector.y > largestY)
            {
                addedHeight = vector.y - largestY;
                largestY = vector.y;
                up = true;
            }
        }

        GameManager.instance.score = (int)(Mathf.Abs(smallestX) + Mathf.Abs(smallestY) + largestX + largestY);

        float completeWidth = largestX - smallestX;
        float completeHeight = largestY - smallestY;

        if (completeHeight > completeWidth)
        {
            fullCamera.orthographicSize = completeHeight / 2 + 10;
        }
        else if (completeWidth > completeHeight)
        {
            fullCamera.orthographicSize = completeWidth / 2 + 10;
        }

        if (up == true && right == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (right == true && down == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (down == true && left == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (left == true && up == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (up == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x, fullCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (right == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y, -10);
        }

        else if (down == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x, fullCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (left == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y, -10);
        }
    }

    // Adds a new star to the constellation
    private void CreateNewStar()
    {
        // Round the stars postion
        GameManager.instance.star.transform.position = new(Mathf.Round(GameManager.instance.star.transform.position.x), Mathf.Round(GameManager.instance.star.transform.position.y), 0);
        GameManager.instance.background.transform.position = new(Mathf.Round(GameManager.instance.background.transform.position.x), Mathf.Round(GameManager.instance.background.transform.position.y), 0);

        // Add star to list of vectors if the player has not already been to that location
        if (!vectors.Contains(GameManager.instance.star.transform.position))
        {
            Instantiate(placeholderStar, GameManager.instance.star.transform.position, Quaternion.identity, createdStars.transform);
            vectors.Add(GameManager.instance.star.transform.position);
            MoveFullCamera(vectors);
        }

        // Render a line and alter UI components
        GameManager.instance.star.GetComponent<LineRenderer>().positionCount++;
        GameManager.instance.star.GetComponent<LineRenderer>().SetPosition(GameManager.instance.star.GetComponent<LineRenderer>().positionCount - 1, GameManager.instance.star.transform.position);
    }

    // Moves the constellation camera with the star
    private void MoveConstellationCamera()
    {
        constellationCamera.transform.position = new(GameManager.instance.star.transform.position.x, GameManager.instance.star.transform.position.y, -10);
    }
}