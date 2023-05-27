using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Customizable components
    [Header("Options")]
    public int difficulty;
    public int mapLength;
    public float scrollSpeed;
    public bool immortal;

    // Gameplay components
    [Header("Gameplay")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;
    public bool finished = false;
    private int limit;

    // UI components
    [Header("UI")]
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTracker;
    [SerializeField] private GameObject arrows;
    private bool diagonal = false;
    public bool isGameOver;

    // Constellation components
    [Header("Constellation")]
    [SerializeField] private GameObject star;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject placeholderStar;
    [SerializeField] private Camera constellationCamera;
    [SerializeField] private List<Vector3> vectors;
    private float smallestX = 1000; 
    private float largestX = 1000;
    private float smallestY = 1000;
    private float largestY = 1000;

    // Arrow functions used for buttons
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

    // Function for when the game ends
    public void EndGame()
    {
        // Create final line and end game
        Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
        vectors.Add(star.transform.position);
        MoveConstellationCamera(vectors);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);
        isGameOver = true;
        Time.timeScale = 0f;
        endScreen.SetActive(true);
    }

    // Function for generating a new map
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
        map.GetComponent<MapGenerator>().GenerateMap();
        map.transform.rotation = Quaternion.Euler(vector);
        scrollSpeed = 10;
    }

    // Function for resizing the constellation camera
    private void MoveConstellationCamera(List<Vector3> vectors)
    {
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

        if (constellationCamera.orthographicSize < completeWidth || constellationCamera.orthographicSize < completeHeight)
        {
            constellationCamera.orthographicSize += 5;
        }

        if (up == true && right == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x + (addedWidth / 2), constellationCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (right == true && down == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x + (addedWidth / 2), constellationCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (down == true && left == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (left == true && up == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (up == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x, constellationCamera.transform.position.y + (addedHeight / 2), -10);
        }

        else if (right == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x + (addedWidth / 2), constellationCamera.transform.position.y, -10);
        }

        else if (down == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x, constellationCamera.transform.position.y - (addedHeight / 2), -10);
        }

        else if (left == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y, -10);
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        limit = 0;
    }

    void Update()
    {
        if (scoreTracker.transform.position.y >= limit && finished == false)
        {
            // Only execute this code once
            finished = true;

            // Reset scoretracker postion and store its y value as the score
            scoreTracker.transform.position = new(0f, limit, 0f);
            int value = (int)scoreTracker.transform.position.y;
            scoreText.text = value.ToString();
            limit += mapLength;

            // Round the stars postion, instantiate placeholder star, add vector to constellation, move the camera, create new line
            star.transform.position = new(Mathf.Round(star.transform.position.x), Mathf.Round(star.transform.position.y), 0);
            Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
            vectors.Add(star.transform.position);
            MoveConstellationCamera(vectors);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);

            arrows.SetActive(true);
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Meteor")) && immortal == false)
        {
            EndGame();
        }

        else if (finished == false)
        {
            // Move the score tracker upwards and record its y position
            scoreTracker.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
            int value = (int)scoreTracker.transform.position.y;
            scoreText.text = value.ToString();

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
