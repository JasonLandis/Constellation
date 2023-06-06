using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Gameplay values
    [Header("Gameplay")]
    public int lives;
    public float distance;
    public float size;
    public float speed;
    public int mapLength;
    public bool immortal;

    // Gameplay objects
    [Header("Objects")]
    public GameObject player;
    public GameObject map;
    public GameObject star;
    public LineRenderer lineRenderer;
    public GameObject placeholderStar;
    public Camera constellationCamera;
    public Camera fullCamera;
    public GameObject mapTracker;

    // Text objects
    [Header("Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;

    // UI components
    [Header("UI")]
    public GameObject arrows;
    public GameObject Distance;
    public GameObject fullConstellationImage;
    public GameObject endScreen;

    // Scripts
    [Header("Scripts")]
    public Constellation constellation;
    public Roguelike roguelike;

    // Gameplay controllers
    private bool isGameOver;
    private int zone = 1;
    private float countdownTime = 3;
    private float score = 0;
    private string direction;
    private int limit = 0;
    private bool finished;
    private Vector3 vector;

    // Constellation components
    [HideInInspector] public List<Vector3> vectors;
    private float smallestX = 1000;
    private float largestX = 1000;
    private float smallestY = 1000;
    private float largestY = 1000;


    // Arrow buttons
    public void UpArrow()
    {
        vector = Vector3.zero;
        direction = "up";
        ShowDistance();
    }
    public void DownArrow()
    {
        vector = new (0, 0, 180);
        direction = "down";
        ShowDistance();
    }
    public void LeftArrow()
    {
        vector = new(0, 0, 90);
        direction = "left";
        ShowDistance();
    }
    public void RightArrow()
    {
        vector = new(0, 0, 270);
        direction = "right";
        ShowDistance();
    }
    public void UpRightArrow()
    {
        vector = new(0, 0, 315);
        direction = "upright";
        ShowDistance();
    }
    public void DownRightArrow()
    {
        vector = new(0, 0, 225);
        direction = "downright";
        ShowDistance();
    }
    public void UpLeftArrow()
    {
        vector = new(0, 0, 45);
        direction = "upleft";
        ShowDistance();
    }
    public void DownLeftArrow()
    {
        vector = new(0, 0, 135);
        direction = "downleft";
        ShowDistance();
    }

    // Map length function
    public void OneHundred()
    {
        mapLength = 100;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void TwoHundred()
    {
        mapLength = 200;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void ThreeHundred()
    {
        mapLength = 300;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void FourHundred()
    {
        mapLength = 400;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void FiveHundred()
    {
        mapLength = 500;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void SixHundred()
    {
        mapLength = 600;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void SevenHundred()
    {
        mapLength = 700;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void EightHundred()
    {
        mapLength = 800;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void NineHundred()
    {
        mapLength = 900;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void OneThousand()
    {
        mapLength = 1000;
        limit += mapLength;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }

    // Other functions
    public void EndGame()
    {
        // Stop time, resize camera, and end game
        isGameOver = true;
        endScreen.SetActive(true);
        MoveFullCamera(vectors);
        Time.timeScale = 0f;
        star.SetActive(false);
        map.SetActive(false);
    }
    private void GenerateNewMap(Vector3 vector)
    {
        // Remove old map
        foreach (Transform child in map.transform)
        {
            Destroy(child.gameObject);
        }

        // Generate new map
        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        map.GetComponent<MapGenerator>().GenerateMap(distance, mapLength);
        map.transform.rotation = Quaternion.Euler(vector);
        map.SetActive(true);
        finished = false;
    }
    private void ShowDistance()
    {
        arrows.SetActive(false);
        Distance.SetActive(true);
    }
    public void HideDistance()
    {
        arrows.SetActive(true);
        Distance.SetActive(false);
    }


    // Functions used for the constellation mechanic
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
    private void DetectDifficulty()
    {
        // Detects difficulty level based on location within constellation map
        if (star.transform.position.y > 975 && star.transform.position.y < 1025 && star.transform.position.x > 975 && star.transform.position.x < 1025)
        {
            zone = 1;
        }
        else if (star.transform.position.y > 945 && star.transform.position.y < 1055 && star.transform.position.x > 945 && star.transform.position.x < 1055)
        {
            zone = 2;
        }
        else if (star.transform.position.y > 915 && star.transform.position.y < 1085 && star.transform.position.x > 915 && star.transform.position.x < 1085)
        {
            zone = 3;
        }
        else if (star.transform.position.y > 885 && star.transform.position.y < 1115 && star.transform.position.x > 885 && star.transform.position.x < 1115)
        {
            zone = 4;
        }
        else if (star.transform.position.y > 855 && star.transform.position.y < 1145 && star.transform.position.x > 855 && star.transform.position.x < 1145)
        {
            zone = 5;
        }
        else if (star.transform.position.y > 825 && star.transform.position.y < 1175 && star.transform.position.x > 825 && star.transform.position.x < 1175)
        {
            zone = 6;
        }
        else if (star.transform.position.y > 795 && star.transform.position.y < 1205 && star.transform.position.x > 795 && star.transform.position.x < 1205)
        {
            zone = 7;
        }
        else if (star.transform.position.y > 765 && star.transform.position.y < 1235 && star.transform.position.x > 765 && star.transform.position.x < 1235)
        {
            zone = 8;
        }
        else if (star.transform.position.y > 735 && star.transform.position.y < 1265 && star.transform.position.x > 735 && star.transform.position.x < 1265)
        {
            zone = 9;
        }
        else
        {
            zone = 10;
        }


        // Set difficulty levels
        switch (zone)
        {
            case 1:
                speed = 100;
                distance = 5f;
                break;
            case 2:
                speed = 110;
                distance = 4.7f;
                break;
            case 3:
                speed = 120;
                distance = 4.4f;
                break;
            case 4:
                speed = 130;
                distance = 4.1f;
                break;
            case 5:
                speed = 140;
                distance = 3.8f;
                break;
            case 6:
                speed = 150;
                distance = 3.5f;
                break;
            case 7:
                speed = 160;
                distance = 3.2f;
                break;
            case 8:
                speed = 170;
                distance = 2.9f;
                break;
            case 9:
                speed = 180;
                distance = 2.6f;
                break;
            case 10:
                speed = 190;
                distance = 2.3f;
                break;
        }
    }
    private void CreateNewStar()
    {
        // Round the stars postion
        star.transform.position = new(Mathf.Round(star.transform.position.x), Mathf.Round(star.transform.position.y), 0);

        // Add star to list of vectors if the player has not already been to that location
        if (!vectors.Contains(star.transform.position))
        {
            Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
            vectors.Add(star.transform.position);
            MoveFullCamera(vectors);
        }

        // Render a line and alter UI components
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);
        map.SetActive(false);
        arrows.SetActive(true);
    }
    public void ShowFullConstellation()
    {
        fullConstellationImage.SetActive(true);
    }
    public void HideFullConstellation()
    {
        fullConstellationImage.SetActive(false);
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (mapTracker.transform.position.y >= limit && finished == false)
        {
            // Execute this code only once
            finished = true;

            // Change the difficulty if needed
            DetectDifficulty();

            // Set the text
            livesText.text = lives.ToString();
            distanceText.text = distance.ToString();
            sizeText.text = size.ToString();
            speedText.text = speed.ToString();

            // Reset scoretracker postion and store its y value as the score
            mapTracker.transform.position = new(0f, limit, 0f);

            // Create a new star
            CreateNewStar();

            // Show roguelike component if play has landed on a star
            if (constellation.constellationVectors.Contains(star.transform.position))
            {
                constellation.constellationVectors.Remove(star.transform.position);
                roguelike.ShowRoguelike();
            }
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Meteor")) && immortal == false && isGameOver == false)
        {
            if (lives == 0)
            {
                EndGame();
            }
            else
            {
                lives -= 1;
                livesText.text = lives.ToString();
                immortal = true;
            }
        }

        else if (finished == false)
        {
            // Countdown for extra life invincibility
            if (immortal == true)
            {                
                countdownTime -= Time.deltaTime;
                if (countdownTime <= 0)
                {
                    immortal = false;
                    countdownTime = 3;
                }
            }

            // Update the mapTracker
            mapTracker.transform.Translate(speed * Time.deltaTime * Vector3.up);
            score = (int)mapTracker.transform.position.y / 10;
            scoreText.text = score.ToString();

            // Make the constellation camera follow the star
            constellationCamera.transform.position = new(star.transform.position.x, star.transform.position.y, -10);

            // Move the map and the star
            map.transform.Translate(speed * Time.deltaTime * Vector3.down);

            if (direction == "up")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
            }
            else if (direction == "left")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }
            else if (direction == "right")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "down")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
            }
            else if (direction == "upright")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "upleft")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }
            else if (direction == "downright")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "downleft")
            {
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }
        }
    }
}
