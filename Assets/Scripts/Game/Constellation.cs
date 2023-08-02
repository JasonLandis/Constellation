using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Constellation : MonoBehaviour
{
    [Header("Objects")]
    public GameObject constellationStar;
    public GameObject placeholderStar;
    public GameObject constellationStars;
    public GameObject createdStars;
    public GameObject fullConstellation;
    public GameObject endConstellation;
    public GameObject fullCameraObject;

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
        GameManager.instance.createNewStar += CreateNewStar;
        GameManager.instance.moveConstellationCamera += MoveConstellationCamera;
        GameManager.instance.setFullCamera += SetFullCamera;
        GameManager.instance.fullCameraTransition += FullCameraTransition;
        GameManager.instance.resetConstellation += ResetConstellation;
    }

    // Generates stars on the constellation map
    public void GenerateConstellation()
    {
        int rand;
        for (int i = -30; i < 30; i += 1)
        {
            for (int j = -30; j < 30; j += 1)
            {
                float red = Random.Range(100, 255) / 255f;
                float green = Random.Range(100, 255) / 255f;
                float blue = Random.Range(100, 255) / 255f;

                constellationStar.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
                constellationStar.GetComponent<Light2D>().color = new(red, green, blue, 1);

                if (i > -3.5 && i < 3.5 && j > -3.5 && j < 3.5)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }
                        else
                        {
                            Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                            GameManager.instance.constellationVectors.Add(new(i, j, 0));
                        }
                    }
                }
                else if (i > -6.5 && i < 6.5 && j > -6.5 && j < 6.5)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -9.5 && i < 9.5 && j > -9.5 && j < 9.5)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -12.5 && i < 12.5 && j > -12.5 && j < 12.5)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
                else if (i > -15.5 && i < 15.5 && j > -15.5 && j < 15.5)
                {
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        Instantiate(constellationStar, new(i, j, 0), Quaternion.identity, constellationStars.transform);
                        GameManager.instance.constellationVectors.Add(new(i, j, 0));
                    }
                }
            }
        }
    }

    // Moves the constellation camera with the star
    private void MoveConstellationCamera()
    {
        constellationCamera.transform.position = new(GameManager.instance.star.transform.position.x, GameManager.instance.star.transform.position.y, -1);
        fullCameraObject.SetActive(false);
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
            fullCamera.orthographicSize = completeHeight / 2 + 1;
        }
        else if (completeWidth > completeHeight)
        {
            fullCamera.orthographicSize = completeWidth / 2 + 1;
        }

        if (up == true && right == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y + (addedHeight / 2), -1);
        }

        else if (right == true && down == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y - (addedHeight / 2), -1);
        }

        else if (down == true && left == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y - (addedHeight / 2), -1);
        }

        else if (left == true && up == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y + (addedHeight / 2), -1);
        }

        else if (up == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x, fullCamera.transform.position.y + (addedHeight / 2), -1);
        }

        else if (right == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x + (addedWidth / 2), fullCamera.transform.position.y, -1);
        }

        else if (down == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x, fullCamera.transform.position.y - (addedHeight / 2), -1);
        }

        else if (left == true)
        {
            fullCamera.transform.position = new(fullCamera.transform.position.x - (addedWidth / 2), fullCamera.transform.position.y, -1);
        }
    }

    // Adds a new star to the constellation
    private void CreateNewStar()
    {
        // Round the stars postion
        if (!GameManager.instance.isGameOver)
        {
            GameManager.instance.star.transform.position = new(Mathf.Round(GameManager.instance.star.transform.position.x), Mathf.Round(GameManager.instance.star.transform.position.y), 0);
        }
 
        // Add star to list of vectors if the player has not already been to that location
        if (!vectors.Contains(GameManager.instance.star.transform.position))
        {
            Instantiate(placeholderStar, GameManager.instance.star.transform.position, Quaternion.identity, createdStars.transform);
            vectors.Add(GameManager.instance.star.transform.position);
        }

        // Render a line and alter UI components
        GameManager.instance.star.GetComponent<LineRenderer>().positionCount += 3;
        GameManager.instance.star.GetComponent<LineRenderer>().SetPosition(GameManager.instance.star.GetComponent<LineRenderer>().positionCount - 3, GameManager.instance.star.transform.position);
        GameManager.instance.star.GetComponent<LineRenderer>().SetPosition(GameManager.instance.star.GetComponent<LineRenderer>().positionCount - 2, GameManager.instance.previousPosition);
        GameManager.instance.star.GetComponent<LineRenderer>().SetPosition(GameManager.instance.star.GetComponent<LineRenderer>().positionCount - 1, GameManager.instance.star.transform.position);
        GameManager.instance.previousPosition = GameManager.instance.star.transform.position;
        MoveFullCamera(vectors);
    }

    // Button functions for viewing the full constellation
    public void ShowFullConstellation()
    {
        fullCameraObject.SetActive(true);
        fullConstellation.SetActive(true);
    }
    public void HideFullConstellation()
    {
        fullCameraObject.SetActive(false);
        fullConstellation.SetActive(false);
    }

    // Functions for resizing the full camera for full constellation preview at end of game
    public void SetFullCamera()
    {
        endConstellation.SetActive(true);
        constellationStars.SetActive(false);
        fullCamera.transform.position = constellationCamera.transform.position;
        fullCamera.orthographicSize = 2;
    }

    public void FullCameraTransition()
    {
        fullCamera.transform.position = new(0, 0, -1);
        fullCamera.orthographicSize += Time.deltaTime * 4;
        if (fullCamera.orthographicSize >= 17)
        {
            GameManager.instance.transitionIsDone = true;
        }
    }

    // Resets the constellation components on universe reset
    public void ResetConstellation()
    {
        foreach (Transform star in constellationStars.transform)
        {
            Destroy(star.gameObject);
        }
        foreach (Transform star in createdStars.transform)
        {
            Destroy(star.gameObject);
        }
        vectors.Clear();
        smallestX = 0;
        largestX = 0;
        smallestY = 0;
        largestY = 0;
        constellationCamera.transform.position = new(0, 0, -1);
        fullCamera.transform.position = new(0, 0, -1);
        fullCamera.orthographicSize = 2;
        GenerateConstellation();
        constellationStars.SetActive(true);
        endConstellation.SetActive(false);
    }
}