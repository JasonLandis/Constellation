using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endScreen;
    public bool isGameOver = false;

    public GameObject player;

    public GameObject DownArrow;
    public GameObject UpArrow;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    public float scrollSpeed;
    public GameObject map;

    public float score;
    public TextMeshProUGUI scoreText;

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
        if (player.GetComponent<Player>().rb.IsTouchingLayers(LayerMask.GetMask("Barrier")))
        {
            scrollSpeed = 3f;
        }
        
        if (player.GetComponent<Player>().rb.IsTouchingLayers(LayerMask.GetMask("Blockade")))
        {
            EndGame();
        }
        
        if (player.GetComponent<Player>().rb.IsTouching(LeftArrow.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        else if (player.GetComponent<Player>().rb.IsTouching(RightArrow.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        else if (player.GetComponent<Player>().rb.IsTouching(UpArrow.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 0);
            Arrows(vector);
        }

        else if (player.GetComponent<Player>().rb.IsTouching(DownArrow.GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touching");
            Vector3 vector = new(0, 0, 90);
            Arrows(vector);
        }

        score += Time.deltaTime;
        scoreText.text = "Score: " + score;

        map.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.down);
    }

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        endScreen.SetActive(true);
    }

    public void Arrows(Vector3 vector)
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
}
