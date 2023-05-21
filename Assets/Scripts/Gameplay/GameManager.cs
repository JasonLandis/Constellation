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

    [Header("UI")]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject scoreTracker;

    [Header("Arrows")]
    [SerializeField] private GameObject Up;
    [SerializeField] private GameObject Down;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject UpRight;
    [SerializeField] private GameObject DownLeft;
    [SerializeField] private GameObject UpLeft;
    [SerializeField] private GameObject DownRight;

    [Header("Constellation")]
    [SerializeField] private GameObject star;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject placeholderStar;
 
    private bool isGameOver;
    private readonly bool isGamePaused;
    private int limit;

    private void GenerateNewMap(Vector3 vector)
    {
        foreach (Transform child in map.transform)
        {
            Destroy(child.gameObject);
        }
        limit += mapLength;

        // Create another star in the constellation
        Instantiate(placeholderStar, star.transform.position, Quaternion.identity, transform);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, star.transform.position);
        star.transform.rotation = Quaternion.Euler(vector);

        // Create the new map
        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        map.GetComponent<MapGenerator>().GenerateMap();
        map.transform.rotation = Quaternion.Euler(vector);
        scrollSpeed = 10;
    }
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
    }
    public void DownArrow()
    {
        ClearArrows();
        Vector3 vector = new (0, 0, 180);
        GenerateNewMap(vector);
    }
    public void LeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 90);
        GenerateNewMap(vector);
    }
    public void RightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 270);
        GenerateNewMap(vector);
    }
    public void UpRightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 315);
        GenerateNewMap(vector);
    }
    public void DownRightArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 225);
        GenerateNewMap(vector);
    }
    public void UpLeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 45);
        GenerateNewMap(vector);
    }
    public void DownLeftArrow()
    {
        ClearArrows();
        Vector3 vector = new(0, 0, 135);
        GenerateNewMap(vector);
    }
    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        endScreen.SetActive(true);
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

        if (scoreTracker.transform.position.y >= limit)
        {
            scoreTracker.transform.position = new (0f, limit, 0f);
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

        else
        {
            scoreTracker.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
            scoreText.text = "Score\n" + (int)scoreTracker.transform.position.y;
            map.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.down);
            star.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.up);
        }
    }
}
