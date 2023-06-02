using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    private int area = 1;

    // UI components
    [Header("UI")]
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
    private float smallestX = 1000;
    private float largestX = 1000;
    private float smallestY = 1000;
    private float largestY = 1000;

    // Scripts
    [Header("Scripts")]
    public Constellation constellation;
    public Roguelike roguelike;


    // Arrow buttons
    public void UpArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = Vector3.zero;
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void DownArrow()
    {       
        arrows.SetActive(false);
        Vector3 vector = new (0, 0, 180);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void LeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 90);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void RightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 270);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void UpRightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 315);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void DownRightArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 225);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void UpLeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 45);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void DownLeftArrow()
    {
        arrows.SetActive(false);
        Vector3 vector = new(0, 0, 135);
        GenerateNewMap(vector);
        diagonal = true;
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
        if (star.transform.position.y > 975 && star.transform.position.y < 1025 && star.transform.position.x > 975 && star.transform.position.x < 1025)
        {
            area = 1;
        }
        else if (star.transform.position.y > 945 && star.transform.position.y < 1055 && star.transform.position.x > 945 && star.transform.position.x < 1055)
        {
            area = 2;
        }
        else if (star.transform.position.y > 915 && star.transform.position.y < 1085 && star.transform.position.x > 915 && star.transform.position.x < 1085)
        {
            area = 3;
        }
        else if (star.transform.position.y > 885 && star.transform.position.y < 1115 && star.transform.position.x > 885 && star.transform.position.x < 1115)
        {
            area = 4;
        }
        else if (star.transform.position.y > 855 && star.transform.position.y < 1145 && star.transform.position.x > 855 && star.transform.position.x < 1145)
        {
            area = 5;
        }
        else if (star.transform.position.y > 825 && star.transform.position.y < 1175 && star.transform.position.x > 825 && star.transform.position.x < 1175)
        {
            area = 6;
        }
        else if (star.transform.position.y > 795 && star.transform.position.y < 1205 && star.transform.position.x > 795 && star.transform.position.x < 1205)
        {
            area = 7;
        }
        else if (star.transform.position.y > 765 && star.transform.position.y < 1235 && star.transform.position.x > 765 && star.transform.position.x < 1235)
        {
            area = 8;
        }
        else if (star.transform.position.y > 735 && star.transform.position.y < 1265 && star.transform.position.x > 735 && star.transform.position.x < 1265)
        {
            area = 9;
        }
        else if (star.transform.position.y > 705 && star.transform.position.y < 1295 && star.transform.position.x > 705 && star.transform.position.x < 1295)
        {
            area = 10;
        }

        // Set difficulty levels
        switch (area)
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
        areaText.text = area.ToString();
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

            // Make the constellation camera follow the star
            constellationCamera.transform.position = new(star.transform.position.x, star.transform.position.y, -10);

            // Move the map down and move the star at a speed depending on the selected arrow being diagonal or not
            map.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.down);
            if (diagonal)
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 7));
            }
            else
            {
                star.transform.Translate(scrollSpeed * Time.deltaTime * (Vector3.up / 10));
            }
        }
    }
}
