using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Customizable components
    [Header("Options")]
    public float difficulty;
    public int mapLength;
    public float scrollSpeed;
    public bool immortal;
    public float countdownTime = 0;

    // Roguelike
    [Header("Roguelike")]
    public TextMeshProUGUI livesText;
    public int lives;
    public bool invincible;

    // Gameplay components
    [Header("Gameplay")]
    public GameObject player;
    public GameObject map;
    public GameObject mapTracker;
    public bool finished = false;
    public bool isGameOver;
    private bool diagonal;
    private int limit = 0;
    private int zone = 0;

    // UI components
    [Header("UI")]
    public GameObject background;
    public GameObject endScreen;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI areaText;
    public GameObject fullConstellationImage;
    public GameObject arrows;
    private int stars;

    // Constellation components
    [Header("Constellation")]
    public GameObject star;
    public LineRenderer lineRenderer;
    public GameObject placeholderStar;
    public Camera constellationCamera;
    public Camera fullCamera;
    public List<Vector3> vectors;
    private float smallestX = 10000;
    private float largestX = 10000;
    private float smallestY = 10000;
    private float largestY = 10000;

    // Scripts
    [Header("Scripts")]
    public Constellation constellation;
    public Roguelike roguelike;

    private string Direction;


    // Arrow buttons
    public void UpArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = Vector3.zero;
        GenerateNewMap(vector);
        diagonal = false;
        Direction = "up";
    }
    public void DownArrow()
    {       
        arrows.SetActive(false);
        Vector3 vector = new (0, 0, 180);
        GenerateNewMap(vector);
        diagonal = false;
        Direction = "down";
    }
    public void LeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 90);
        GenerateNewMap(vector);
        diagonal = false;
        Direction = "left";
    }
    public void RightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 270);
        GenerateNewMap(vector);
        diagonal = false;
        Direction = "right";
    }
    public void UpRightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 315);
        GenerateNewMap(vector);
        diagonal = true;
        Direction = "upright";
    }
    public void DownRightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 225);
        GenerateNewMap(vector);
        diagonal = true;
        Direction = "downright";
    }
    public void UpLeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 45);
        GenerateNewMap(vector);
        diagonal = true;
        Direction = "upleft";
    }
    public void DownLeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 135);
        GenerateNewMap(vector);
        diagonal = true;
        Direction = "downleft";
    }


    // Other functions
    public void EndGame()
    {
        // Stop time, resize camera, and end game
        isGameOver = true;
        Time.timeScale = 0f;
        star.GetComponent<SpriteRenderer>().sortingOrder = -1;
        MoveFullCamera(vectors);
        map.SetActive(false);
        endScreen.SetActive(true);
    }
    private void GenerateNewMap(Vector3 vector)
    {        
        foreach (Transform child in map.transform)
        {
            Destroy(child.gameObject);
        }

        // Reset constellation mechanics
        finished = false;
        star.transform.rotation = Quaternion.Euler(vector);

        // Generate new map
        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        map.GetComponent<MapGenerator>().GenerateMap(difficulty, mapLength);
        map.transform.rotation = Quaternion.Euler(vector);
        map.SetActive(true);
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

        if (fullCamera.orthographicSize < completeWidth / 1.75 || fullCamera.orthographicSize < completeHeight / 1.75)
        {
            fullCamera.orthographicSize += 10;
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
        if (star.transform.position.y > 9965 && star.transform.position.y < 10035 && star.transform.position.x > 9965 && star.transform.position.x < 10035)
        {
            zone = 0;
        }
        else if (star.transform.position.y > 9925 && star.transform.position.y < 10075 && star.transform.position.x > 9925 && star.transform.position.x < 10075)
        {
            zone = 1;
        }
        else if (star.transform.position.y > 9885 && star.transform.position.y < 10115 && star.transform.position.x > 9885 && star.transform.position.x < 10115)
        {
            zone = 2;
        }
        else if (star.transform.position.y > 9845 && star.transform.position.y < 10155 && star.transform.position.x > 9845 && star.transform.position.x < 10155)
        {
            zone = 3;
        }
        else if (star.transform.position.y > 9815 && star.transform.position.y < 10195 && star.transform.position.x > 9815 && star.transform.position.x < 10195)
        {
            zone = 4;
        }
        else if (star.transform.position.y > 9775 && star.transform.position.y < 10235 && star.transform.position.x > 9775 && star.transform.position.x < 10235)
        {
            zone = 5;
        }
        else if (star.transform.position.y > 9735 && star.transform.position.y < 10275 && star.transform.position.x > 9735 && star.transform.position.x < 10275)
        {
            zone = 6;
        }
        else if (star.transform.position.y > 9695 && star.transform.position.y < 10315 && star.transform.position.x > 9695 && star.transform.position.x < 10315)
        {
            zone = 7;
        }
        else if (star.transform.position.y > 9655 && star.transform.position.y < 10355 && star.transform.position.x > 9655 && star.transform.position.x < 10355)
        {
            zone = 8;
        }
        else if (star.transform.position.y > 9615 && star.transform.position.y < 10395 && star.transform.position.x > 9615 && star.transform.position.x < 10395)
        {
            zone = 9;
        }
        else if (star.transform.position.y > 9575 && star.transform.position.y < 10435 && star.transform.position.x > 9575 && star.transform.position.x < 10435)
        {
            zone = 10;
        }
        else if (star.transform.position.y > 9535 && star.transform.position.y < 10475 && star.transform.position.x > 9535 && star.transform.position.x < 10475)
        {
            zone = 11;
        }
        else if (star.transform.position.y > 9495 && star.transform.position.y < 10505 && star.transform.position.x > 9495 && star.transform.position.x < 10505)
        {
            zone = 12;
        }
        else if (star.transform.position.y > 9455 && star.transform.position.y < 10545 && star.transform.position.x > 9455 && star.transform.position.x < 10545)
        {
            zone = 13;
        }
        else if (star.transform.position.y > 9415 && star.transform.position.y < 10585 && star.transform.position.x > 9415 && star.transform.position.x < 10585)
        {
            zone = 14;
        }
        else if (star.transform.position.y > 9375 && star.transform.position.y < 10625 && star.transform.position.x > 9375 && star.transform.position.x < 10625)
        {
            zone = 15;
        }
        else if (star.transform.position.y > 9335 && star.transform.position.y < 10665 && star.transform.position.x > 9335 && star.transform.position.x < 10665)
        {
            zone = 16;
        }
        else if (star.transform.position.y > 9295 && star.transform.position.y < 10705 && star.transform.position.x > 9295 && star.transform.position.x < 10705)
        {
            zone = 17;
        }
        else if (star.transform.position.y > 9255 && star.transform.position.y < 10745 && star.transform.position.x > 9255 && star.transform.position.x < 10745)
        {
            zone = 18;
        }
        else if (star.transform.position.y > 9215 && star.transform.position.y < 10785 && star.transform.position.x > 9215 && star.transform.position.x < 10785)
        {
            zone = 19;
        }
        else if (star.transform.position.y > 9175 && star.transform.position.y < 10825 && star.transform.position.x > 9175 && star.transform.position.x < 10825)
        {
            zone = 20;
        }
        else if (star.transform.position.y > 9135 && star.transform.position.y < 10865 && star.transform.position.x > 9135 && star.transform.position.x < 10865)
        {
            zone = 21;
        }
        else if (star.transform.position.y > 9095 && star.transform.position.y < 10905 && star.transform.position.x > 9095 && star.transform.position.x < 10905)
        {
            zone = 22;
        }
        else if (star.transform.position.y > 9055 && star.transform.position.y < 10945 && star.transform.position.x > 9055 && star.transform.position.x < 10945)
        {
            zone = 23;
        }
        else if (star.transform.position.y > 9015 && star.transform.position.y < 10985 && star.transform.position.x > 9015 && star.transform.position.x < 10985)
        {
            zone = 24;
        }
        else if (star.transform.position.y > 8975 && star.transform.position.y < 11025 && star.transform.position.x > 8975 && star.transform.position.x < 11025)
        {
            zone = 25;
        }
        else if (star.transform.position.y > 8935 && star.transform.position.y < 11065 && star.transform.position.x > 8935 && star.transform.position.x < 11065)
        {
            zone = 26;
        }
        else if (star.transform.position.y > 8895 && star.transform.position.y < 11105 && star.transform.position.x > 8895 && star.transform.position.x < 11105)
        {
            zone = 27;
        }
        else if (star.transform.position.y > 8855 && star.transform.position.y < 11145 && star.transform.position.x > 8855 && star.transform.position.x < 11145)
        {
            zone = 28;
        }
        else if (star.transform.position.y > 8815 && star.transform.position.y < 11185 && star.transform.position.x > 8815 && star.transform.position.x < 11185)
        {
            zone = 29;
        }
        else if (star.transform.position.y > 8775 && star.transform.position.y < 11225 && star.transform.position.x > 8775 && star.transform.position.x < 11225)
        {
            zone = 30;
        }

        // Set difficulty levels
        switch (zone)
        {
            case 1:
                scrollSpeed = 10;
                difficulty = 5f;
                break;
            case 2:
                scrollSpeed = 11;
                difficulty = 4.7f;
                break;
            case 3:
                scrollSpeed = 12;
                difficulty = 4.4f;
                break;
            case 4:
                scrollSpeed = 13;
                difficulty = 4.1f;
                break;
            case 5:
                scrollSpeed = 14;
                difficulty = 3.8f;
                break;
            case 6:
                scrollSpeed = 15;
                difficulty = 3.5f;
                break;
            case 7:
                scrollSpeed = 16;
                difficulty = 3.2f;
                break;
            case 8:
                scrollSpeed = 17;
                difficulty = 2.9f;
                break;
            case 9:
                scrollSpeed = 18;
                difficulty = 2.6f;
                break;
            case 10:
                scrollSpeed = 19;
                difficulty = 2.3f;
                break;
        }

        // Set area text
        areaText.text = zone.ToString();
    }
    private void CreateNewStar()
    {
        // Round the stars postion
        star.transform.position = new(Mathf.Round(star.transform.position.x), Mathf.Round(star.transform.position.y), 0);

        // Add star to list of vectors if the player has not already been to that location
        if (!vectors.Contains(star.transform.position))
        {
            Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
            stars += 1;
            starText.text = stars.ToString();
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
        if (isGameOver)
        {
            endScreen.SetActive(false);
        }
        else
        {
            arrows.SetActive(false);
        }
        fullConstellationImage.SetActive(true);
    }
    public void HideFullConstellation()
    {
        if (isGameOver)
        {
            endScreen.SetActive(true);
        }
        else
        {
            arrows.SetActive(true);
        }
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
            // Only execute this code once
            finished = true;

            // Change the difficulty if needed
            DetectDifficulty();

            // Reset scoretracker postion and store its y value as the score
            mapTracker.transform.position = new(0f, limit, 0f);
            limit += mapLength;

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
                countdownTime += Time.deltaTime;
                if (countdownTime >= 3)
                {
                    immortal = false;
                    countdownTime = 0;
                }
            }

            // Move the score tracker upwards and record its y position
            mapTracker.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
            map.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.down);

            // Make the constellation camera follow the star
            constellationCamera.transform.position = new(star.transform.position.x, star.transform.position.y, -10);

            if (Direction == "up")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.down));
            }

            else if (Direction == "left")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.right));
            }

            else if (Direction == "right")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.left));
            }

            else if (Direction == "down")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.up));
            }

            else if (Direction == "upright")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 7));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.down / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.left / 10));
            }

            else if (Direction == "upleft")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 7));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.down / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.right / 10));
            }

            else if (Direction == "downright")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 7));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.left / 10));
            }

            else if (Direction == "downleft")
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 7));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(scrollSpeed / 10 * Time.deltaTime * (Vector3.right / 10));
            }
        }
    }
}
