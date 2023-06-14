using System;
using System.Collections.Generic;
using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Gameplay Variables")]
    public int lives;
    public float distance;
    public float size;
    public float speed;

    [Header("Objects")]
    public GameObject player;
    public GameObject meteor;
    public GameObject map;
    public GameObject star;
    public GameObject background;
    public GameObject mapTracker;
    public GameObject endScreen;

    [HideInInspector] public int mapLength;
    [HideInInspector] public string direction;
    [HideInInspector] public bool immortal;
    [HideInInspector] public Vector3 directionVector;
    [HideInInspector] public int score;
    [HideInInspector] public int limit = 0;
    [HideInInspector] public List<Vector3> constellationVectors;
    private bool isGameOver;
    private float countdownTime = 3;
    private bool finished;

    // Functions from other scripts
    public Action zoneDetection;
    public Action showText;
    public Action createStar;
    public Action moveCamera;
    public Action showRoguelike;
    public Action showDistanceUI;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
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
            finished = true;
            mapTracker.transform.position = new(0f, 0f, 0f);

            showText.Invoke();
            showDistanceUI.Invoke();
            createStar.Invoke();

            if (constellationVectors.Contains(star.transform.position))
            {
                constellationVectors.Remove(star.transform.position);
                showRoguelike.Invoke();
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
                immortal = true;
                lives -= 1;
            }
        }

        else if (finished == false)
        {
            ImmortalCheck();
            zoneDetection.Invoke();
            showText.Invoke();
            moveCamera.Invoke();
            DetectMeteors();
            MoveObjects();
        }
    }

    // Creates the last star and ends the game
    public void EndGame()
    {
        showText.Invoke();
        createStar.Invoke();
        isGameOver = true;
        endScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    // Generates a map of meteors
    public void GenerateMap(int mapLength)
    {
        mapLength *= 10;
        // Create meteors
        for (float i = -5; i < 5; i += distance)
        {
            for (float j = 12; j < mapLength - 12; j += distance)
            {
                float x = UnityEngine.Random.Range(i, i + distance);
                float y = UnityEngine.Random.Range(j, j + distance);

                meteor.transform.localScale = new Vector3(size, size, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, map.transform);
            }
        }
    }

    // Destroys the old map and generates a new one
    public void GenerateNewMap(Vector3 vector)
    {
        foreach (Transform child in map.transform)
        {
            if (child.transform.position.x < -10 || child.transform.position.x > 10 || child.transform.position.y < -10 || child.transform.position.y > 10)
            {
                Destroy(child.gameObject);
            }
        }

        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        GenerateMap(limit - (int)mapTracker.transform.position.y);
        map.transform.rotation = Quaternion.Euler(vector);
        finished = false;
    }

    // Detects which meteors are out of view and sets them inactive
    public void DetectMeteors()
    {
        foreach (Transform child in map.transform)
        {
            child.transform.Translate(speed * Time.deltaTime * Vector3.down);
            if (child.transform.position.x < -12 || child.transform.position.x > 12 ||
                child.transform.position.y < -8 || child.transform.position.y > 8)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Checks if the player is immortal
    public void ImmortalCheck()
    {
        if (immortal == true)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0)
            {
                immortal = false;
                countdownTime = 3;
            }
        }
    }

    // Moves the star, background, and map tracker
    public void MoveObjects()
    {
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
