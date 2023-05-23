using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Options")]
    public int difficulty;
    public int mapLength;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private bool immortal;

    [Header("Gameplay")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;
    private int limit;
    private bool finished = false;

    [Header("UI")]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTracker;
    private bool isGameOver;
    private readonly bool isGamePaused;

    [Header("Arrows")]
    [SerializeField] private GameObject Up;
    [SerializeField] private GameObject Down;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject UpRight;
    [SerializeField] private GameObject DownLeft;
    [SerializeField] private GameObject UpLeft;
    [SerializeField] private GameObject DownRight;
    private bool diagonal = false;

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

    public void ClearArrows()
    {
        Up.SetActive(false);
        Down.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
        UpLeft.SetActive(false);
        DownLeft.SetActive(false);
        DownRight.SetActive(false);
        UpRight.SetActive(false);
    }
    public void UpArrow()
    {
        ClearArrows();
        Vector3 vector = Vector3.zero;
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void DownArrow()
    {
        ClearArrows();
        Vector3 vector = new (0, 0, 180);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void LeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 90);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void RightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 270);
        GenerateNewMap(vector);
        diagonal = false;
    }
    public void UpRightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 315);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void DownRightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 225);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void UpLeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 45);
        GenerateNewMap(vector);
        diagonal = true;
    }
    public void DownLeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 135);
        GenerateNewMap(vector);
        diagonal = true;
    }

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;
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
        map.GetComponent<MapGenerator>().GenerateMap();
        map.transform.rotation = Quaternion.Euler(vector);
        scrollSpeed = 10;
    }
    public void moveConstellationCamera(List<Vector3> vectors)
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
            Debug.Log("up and right");
        }

        else if (right == true && down == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x + (addedWidth / 2), constellationCamera.transform.position.y - (addedHeight / 2), -10);
            Debug.Log("down and right");
        }

        else if (down == true && left == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y - (addedHeight / 2), -10);
            Debug.Log("down and left");
        }

        else if (left == true && up == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y + (addedHeight / 2), -10);
            Debug.Log("up and left");
        }

        else if (up == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x, constellationCamera.transform.position.y + (addedHeight / 2), -10);
            Debug.Log("up");
        }

        else if (right == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x + (addedWidth / 2), constellationCamera.transform.position.y, -10);
            Debug.Log("right");
        }

        else if (down == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x, constellationCamera.transform.position.y - (addedHeight / 2), -10);
            Debug.Log("down");
        }

        else if (left == true)
        {
            constellationCamera.transform.position = new(constellationCamera.transform.position.x - (addedWidth / 2), constellationCamera.transform.position.y, -10);
            Debug.Log("left");
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
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (isGamePaused)
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }

        if (scoreTracker.transform.position.y >= limit
            && finished == false)
        {
            finished = true;

            scoreTracker.transform.position = new(0f, limit, 0f);
            scoreText.text = "Score\n" + (int)scoreTracker.transform.position.y;
            limit += mapLength;

            star.transform.position = new(Mathf.Round(star.transform.position.x), Mathf.Round(star.transform.position.y), 0);
            Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
            vectors.Add(star.transform.position);
            moveConstellationCamera(vectors);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);

            Up.SetActive(true);
            Down.SetActive(true);
            Left.SetActive(true);
            Right.SetActive(true);
            UpRight.SetActive(true);
            DownLeft.SetActive(true);
            DownRight.SetActive(true);
            UpLeft.SetActive(true);
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Meteor")) && immortal == false)
        {
            EndGame();
        }

        else if (finished == false)
        {
            scoreTracker.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
            scoreText.text = "Score\n" + (int)scoreTracker.transform.position.y;
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
