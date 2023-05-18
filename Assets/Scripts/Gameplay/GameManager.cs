using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Customizable")]
    [SerializeField] private float scrollSpeed;

    [Header("Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject map;

    [Header("UI")]
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isGameOver;
    private readonly bool isGamePaused;
    private float score;

    private void Arrows(Vector3 vector)
    {
        foreach (Transform child in map.transform)
        {
            Destroy(child.gameObject);
        }
        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        map.GetComponent<MapGenerator>().GenerateMap();
        map.transform.rotation = Quaternion.Euler(vector);
        scrollSpeed = 10;
    }
    private void EndGame()
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

        if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Barrier")))
        {
            scrollSpeed = 3f;
        }
        
        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Meteor")))
        {
            EndGame();
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("UpArrow")))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 0);
            Arrows(vector);
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("DownArrow")))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("LeftArrow")))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        else if (player.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("RightArrow")))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        score += Time.deltaTime;
        scoreText.text = "Score: " + score;
        map.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.down);
    }
}
