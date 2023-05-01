using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endScreen;
    public bool isGameOver = false;

    public GameObject player;

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
        if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("Barrier")))
        {
            scrollSpeed = 3f;
        }
        
        if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("Blockade")))
        {
            EndGame();
        }
        
        if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("ArrowLeft")))
        {
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }
            map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            map.GetComponent<MapGenerator>().GenerateMap();
            map.transform.rotation = Quaternion.Euler(0, 0, 90);
            scrollSpeed = 10;
        }

        else if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("ArrowRight")))
        {
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }
            map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            map.GetComponent<MapGenerator>().GenerateMap();
            map.transform.rotation = Quaternion.Euler(0, 0, 270);
            scrollSpeed = 10;
        }

        else if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("ArrowUp")))
        {
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }
            map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            map.GetComponent<MapGenerator>().GenerateMap();
            map.transform.rotation = Quaternion.Euler(0, 0, 0);
            scrollSpeed = 10;
        }

        else if (player.GetComponent<PlayerController>().rb.IsTouchingLayers(LayerMask.GetMask("ArrowDown")))
        {
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }
            map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            map.GetComponent<MapGenerator>().GenerateMap();
            map.transform.rotation = Quaternion.Euler(0, 0, 90);
            scrollSpeed = 10;
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
}
