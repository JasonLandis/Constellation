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
        GameManager.instance.setFullCamera += SetFullCamera;
        GameManager.instance.showFullConstellation += FullCameraTransition;
    }

    public void SetFullCamera()
    {
        ShowFullConstellation();
        constellationStars.SetActive(false);
        fullCamera.transform.position = new(0, 0, -10);
        fullCamera.orthographicSize = 20;
    }
    public void FullCameraTransition()
    {
        if (fullCamera.orthographicSize < 500)
        {
            fullCamera.orthographicSize += (Time.deltaTime * 85);
        }
    }

    // Generates stars on the constellation map
    public void GenerateConstellation()
    {
        int rand;
        for (int i = -300; i < 300; i += 10)
        {
            for (int j = -300; j < 300; j += 10)
            {
                if (i > -35 && i < 35 && j > -35 && j < 35)
                {
                    rand = Random.Range(0, 5);
                    if (rand == 0)
                    {
                        if (i != 0 && j != 0)
                        {
                            Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                            GameManager.instance.constellationVectors.Add(new(i, j, 0));
                        }
                    }
                }
                else if (i > -65 && i < 65 && j > -65 && j < 65)
                {
                    rand = Random.Range(0, 7);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -95 && i < 95 && j > -95 && j < 95)
                {
                    rand = Random.Range(0, 9);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -125 && i < 125 && j > -125 && j < 125)
                {
                    rand = Random.Range(0, 11);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -155 && i < 155 && j > -155 && j < 155)
                {
                    rand = Random.Range(0, 13);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -185 && i < 185 && j > -185 && j < 185)
                {
                    rand = Random.Range(0, 15);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -215 && i < 215 && j > -215 && j < 215)
                {
                    rand = Random.Range(0, 17);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -245 && i < 245 && j > -245 && j < 245)
                {
                    rand = Random.Range(0, 19);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -275 && i < 275 && j > -275 && j < 275)
                {
                    rand = Random.Range(0, 21);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -300 && i < 300 && j > -300 && j < 300)
                {
                    rand = Random.Range(0, 23);
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
    }

    // Button function that hides the full constellation view
    public void HideFullConstellation()
    {
        fullConstellation.SetActive(false);
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