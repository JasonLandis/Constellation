using System;
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
    public GameObject background;
    public GameObject mapTracker;

    // Text objects
    [Header("Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI zoneText;

    // UI components
    [Header("UI")]
    public GameObject arrows;
    public GameObject Distance;
    public GameObject fullConstellationImage;
    public GameObject fullBackground;
    public GameObject endScreen;

    // Zones
    [Header("Zones")]
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject zone5;
    public GameObject zone6;
    public GameObject zone7;
    public GameObject zone8;
    public GameObject zone9;
    public GameObject zone10;
    public GameObject zone11;
    public GameObject zone12;        
    public GameObject zone13;
    public GameObject zone14;
    public GameObject zone15;
    public GameObject zone16;
    public GameObject zone17;
    public GameObject zone18;
    public GameObject zone19;
    public GameObject zone20;

    // Scripts
    [Header("Scripts")]
    public Constellation constellation;
    public Roguelike roguelike;

    // Gameplay controllers
    private bool isGameOver;
    private int zone = 1;
    private float countdownTime = 3;
    private string direction;
    private bool finished;
    private int limit = 0;
    private Vector3 vector;
    private int value = 0;
    private int minSpeedZone = 1;
    private int minSizeZone = 1;
    private int maxDistanceZone = 1;

    // Constellation components
    [HideInInspector] public List<Vector3> vectors;
    private float smallestX = 0;
    private float largestX = 0;
    private float smallestY = 0;
    private float largestY = 0;

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

    // Moving between direction and distance screens
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

    // Map length function
    public void Ten()
    {
        mapLength = 10;
        limit = 10;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Twenty()
    {
        mapLength = 20;
        limit = 20;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Thirty()
    {
        mapLength = 30;
        limit = 30;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Forty()
    {
        mapLength = 40;
        limit = 40;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Fifty()
    {
        mapLength = 50;
        limit = 50;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Sixty()
    {
        mapLength = 60;
        limit = 60;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Seventy()
    {
        mapLength = 70;
        limit = 70;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Eighty()
    {
        mapLength = 80;
        limit = 80;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Ninety()
    {
        mapLength = 90;
        limit = 90;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }
    public void Hundred()
    {
        mapLength = 100;
        limit = 100;
        GenerateNewMap(vector);
        Distance.SetActive(false);
    }

    // View full constellation buttons
    public void ShowFullConstellation()
    {
        fullConstellationImage.SetActive(true);
        fullBackground.SetActive(true);
    }
    public void HideFullConstellation()
    {
        fullConstellationImage.SetActive(false);
        fullBackground.SetActive(false);
    }

    // Other functions
    public void EndGame()
    {
        // Stop time, resize camera, and end game
        CreateNewStar();
        isGameOver = true;
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        map.SetActive(false);
    }
    private void GenerateNewMap(Vector3 vector)
    {
        // Remove old map
        foreach (Transform child in map.transform)
        {
            if (child.transform.position.x < -10 || child.transform.position.x > 10 || child.transform.position.y < -10 || child.transform.position.y > 10)
            {
                Destroy(child.gameObject);
            }
        }

        // Generate new map
        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        map.GetComponent<MapGenerator>().GenerateMap(distance, limit - (int)mapTracker.transform.position.y, size);
        map.transform.rotation = Quaternion.Euler(vector);
        map.SetActive(true);
        finished = false;
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

        scoreText.text = (Mathf.Abs(smallestX) + Mathf.Abs(smallestY) + largestX + largestY).ToString();

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
    private void CreateNewStar()
    {
        // Round the stars postion
        star.transform.position = new(Mathf.Round(star.transform.position.x), Mathf.Round(star.transform.position.y), 0);
        background.transform.position = new(Mathf.Round(background.transform.position.x), Mathf.Round(background.transform.position.y), 0);

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

    // Functions for zone detection
    private void DetectDifficulty()
    {
        // Detects difficulty level based on location within constellation map
        if (star.transform.position.y > -55 && star.transform.position.y < 55 && star.transform.position.x > -55 && star.transform.position.x < 55)
        {
            zone = 1;
        }
        else if (star.transform.position.y > -105 && star.transform.position.y < 105 && star.transform.position.x > -105 && star.transform.position.x < 105)
        {
            zone = 2;
        }
        else if (star.transform.position.y > -155 && star.transform.position.y < 155 && star.transform.position.x > -155 && star.transform.position.x < 155)
        {
            zone = 3;
        }
        else if (star.transform.position.y > -205 && star.transform.position.y < 205 && star.transform.position.x > -205 && star.transform.position.x < 205)
        {
            zone = 4;
        }
        else if (star.transform.position.y > -255 && star.transform.position.y < 255 && star.transform.position.x > -255 && star.transform.position.x < 255)
        {
            zone = 5;
        }
        else if (star.transform.position.y > -305 && star.transform.position.y < 305 && star.transform.position.x > -305 && star.transform.position.x < 305)
        {
            zone = 6;
        }
        else if (star.transform.position.y > -355 && star.transform.position.y < 355 && star.transform.position.x > -355 && star.transform.position.x < 355)
        {
            zone = 7;
        }
        else if (star.transform.position.y > -405 && star.transform.position.y < 405 && star.transform.position.x > -405 && star.transform.position.x < 405)
        {
            zone = 8;
        }
        else if (star.transform.position.y > -455 && star.transform.position.y < 455 && star.transform.position.x > -455 && star.transform.position.x < 455)
        {
            zone = 9;
        }
        else if (star.transform.position.y > -505 && star.transform.position.y < 505 && star.transform.position.x > -505 && star.transform.position.x < 505)
        {
            zone = 10;
        }
        else if (star.transform.position.y > -555 && star.transform.position.y < 555 && star.transform.position.x > -555 && star.transform.position.x < 555)
        {
            zone = 11;
        }
        else if (star.transform.position.y > -605 && star.transform.position.y < 605 && star.transform.position.x > -605 && star.transform.position.x < 605)
        {
            zone = 12;
        }
        else if (star.transform.position.y > -655 && star.transform.position.y < 655 && star.transform.position.x > -655 && star.transform.position.x < 655)
        {
            zone = 13;
        }
        else if (star.transform.position.y > -705 && star.transform.position.y < 705 && star.transform.position.x > -705 && star.transform.position.x < 705)
        {
            zone = 14;
        }
        else if (star.transform.position.y > -755 && star.transform.position.y < 755 && star.transform.position.x > -755 && star.transform.position.x < 755)
        {
            zone = 15;
        }
        else if (star.transform.position.y > -805 && star.transform.position.y < 805 && star.transform.position.x > -805 && star.transform.position.x < 805)
        {
            zone = 16;
        }
        else if (star.transform.position.y > -855 && star.transform.position.y < 855 && star.transform.position.x > -855 && star.transform.position.x < 855)
        {
            zone = 17;
        }
        else if (star.transform.position.y > -905 && star.transform.position.y < 905 && star.transform.position.x > -905 && star.transform.position.x < 905)
        {
            zone = 18;
        }
        else if (star.transform.position.y > -955 && star.transform.position.y < 955 && star.transform.position.x > -955 && star.transform.position.x < 955)
        {
            zone = 19;
        }
        else
        {
            zone = 20;
        }

        zoneText.text = zone.ToString();
    }
    private void SetDifficulty()
    {
        // Set difficulty levels
        switch (zone)
        {
            case 1:
                if (value > 1)
                {
                    zone3.SetActive(false);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                value = 1;
                break;
            case 2:
                if (value > 2)
                {
                    zone4.SetActive(false);
                    zone1.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 2)
                {
                    zone3.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 2;
                break;
            case 3:
                if (value > 3)
                {
                    zone5.SetActive(false);
                    zone2.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 3)
                {
                    zone1.SetActive(false);
                    zone4.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 3;
                break;
            case 4:
                if (value > 4)
                {
                    zone6.SetActive(false);
                    zone3.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 4)
                {
                    zone2.SetActive(false);
                    zone5.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 4;
                break;
            case 5:
                if (value > 5)
                {
                    zone7.SetActive(false);
                    zone4.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 5)
                {
                    zone3.SetActive(false);
                    zone6.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 5;
                break;
            case 6:
                if (value > 6)
                {
                    zone8.SetActive(false);
                    zone5.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 6)
                {
                    zone4.SetActive(false);
                    zone7.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 6;
                break;
            case 7:
                if (value > 7)
                {
                    zone9.SetActive(false);
                    zone6.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 7)
                {
                    zone5.SetActive(false);
                    zone8.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 7;
                break;
            case 8:
                if (value > 8)
                {
                    zone10.SetActive(false);
                    zone7.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 8)
                {
                    zone6.SetActive(false);
                    zone9.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 8;
                break;
            case 9:
                if (value > 9)
                {
                    zone11.SetActive(false);
                    zone8.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 9)
                {
                    zone7.SetActive(false);
                    zone10.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 9;
                break;
            case 10:
                if (value > 10)
                {
                    zone12.SetActive(false);
                    zone9.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 10)
                {
                    zone8.SetActive(false);
                    zone11.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 10;
                break;
            case 11:
                if (value > 11)
                {
                    zone13.SetActive(false);
                    zone10.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 11)
                {
                    zone9.SetActive(false);
                    zone12.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 11;
                break;
            case 12:
                if (value > 12)
                {
                    zone14.SetActive(false);
                    zone11.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 12)
                {
                    zone10.SetActive(false);
                    zone13.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 12;
                break;
            case 13:
                if (value > 13)
                {
                    zone15.SetActive(false);
                    zone12.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 13)
                {
                    zone11.SetActive(false);
                    zone14.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 13;
                break;
            case 14:
                if (value > 14)
                {
                    zone16.SetActive(false);
                    zone13.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 14)
                {
                    zone12.SetActive(false);
                    zone15.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 14;
                break;
            case 15:
                if (value > 15)
                {
                    zone17.SetActive(false);
                    zone14.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 15)
                {
                    zone13.SetActive(false);
                    zone16.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 15;
                break;
            case 16:
                if (value > 16)
                {
                    zone18.SetActive(false);
                    zone15.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 16)
                {
                    zone14.SetActive(false);
                    zone17.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 16;
                break;
            case 17:
                if (value > 17)
                {
                    zone19.SetActive(false);
                    zone16.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 17)
                {
                    zone15.SetActive(false);
                    zone18.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 17;
                break;
            case 18:
                if (value > 18)
                {
                    zone20.SetActive(false);
                    zone17.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 18)
                {
                    zone16.SetActive(false);
                    zone19.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 18;
                break;
            case 19:
                if (value > 19)
                {
                    zone18.SetActive(true);
                    DecreaseZone();
                    GenerateNewMap(vector);
                }
                else if (value < 19)
                {
                    zone17.SetActive(false);
                    zone20.SetActive(true);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 19;
                break;
            case 20:
                if (value < 20)
                {
                    zone18.SetActive(false);
                    IncreaseZone();
                    GenerateNewMap(vector);
                }
                value = 20;
                break;
        }
    }
    private void DecreaseZone()
    {
        if (speed > 1)
        {
            speed -= 1;
            if (speed < 1)
            {
                speed = 1;
            }
        }
        else
        {
            if (zone >= minSpeedZone)
            {
                minSpeedZone = zone + 1;
            }
        }
        if (distance < 10)
        {
            distance += 0.4f;
            if (distance > 10)
            {
                distance = 10;
            }
        }
        else
        {
            if (zone >= maxDistanceZone)
            {
                maxDistanceZone = zone + 1;
            }
        }
        if (size > 0.125f)
        {
            size -= 0.25f;
            if (size < 0)
            {
                size = 0.25f;
            }
        }
        else
        {
            if (zone >= minSizeZone)
            {
                minSizeZone = zone + 1;
            }
        }
    }
    private void IncreaseZone()
    {
        if (minSpeedZone < zone)
        {
            speed += 1;
        }
        if (distance > 0 && maxDistanceZone < zone)
        {
            distance -= 0.4f;
        }
        if (minSizeZone < zone)
        {
            size += 0.25f;
        }
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

            // Display text
            livesText.text = lives.ToString();
            distanceText.text = Math.Round(distance, 1).ToString();
            sizeText.text = size.ToString();
            speedText.text = speed.ToString();

            mapTracker.transform.position = new(0f, 0f, 0f);

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
                livesText.text = lives.ToString();
                EndGame();
            }
            else
            {
                livesText.text = lives.ToString();
                immortal = true;
                lives -= 1;
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

            // Detect and set difficulty
            DetectDifficulty();
            SetDifficulty();

            // Display text
            livesText.text = lives.ToString();
            distanceText.text = Math.Round(distance, 1).ToString();
            sizeText.text = size.ToString();
            speedText.text = speed.ToString();

            // Make the constellation camera follow the star
            constellationCamera.transform.position = new(star.transform.position.x, star.transform.position.y, -10);

            // Deactivate meteors that are out of view
            foreach (Transform child in map.transform)
            {
                child.transform.Translate(speed * Time.deltaTime * Vector3.down);
                if (child.transform.position.x < -12 || child.transform.position.x > 12 || 
                    child.transform.position.y < - 8 || child.transform.position.y > 8)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }

            // Move the map and the star
            if (direction == "up")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
            }
            else if (direction == "left")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }
            else if (direction == "right")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "down")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
            }
            else if (direction == "upright")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "upleft")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }
            else if (direction == "downright")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
            }
            else if (direction == "downleft")
            {
                background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 10));
                background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 10));
                star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 10));
            }

            // Move the map tracker
            mapTracker.transform.Translate(speed * Time.deltaTime * Vector3.up / 10);
        }
    }
}
