using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Gameplay Variables")]
    public int lives = 0;
    public float spread = 5;
    public float size = 1;
    public float speed = 10;
    public int zone = 1;

    [Header("Universe Variables")]
    public float sizeChange;
    public float spreadChange;
    public float speedChange;

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
    [HideInInspector] public float score;
    [HideInInspector] public int limit = 0;
    [HideInInspector] public bool finishedUniverse;
    [HideInInspector] public bool destroyMeteors;
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
    public Action fullCameraTransition;
    public Action setFullCamera;

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
        CreateUniverseStats();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (mapTracker.transform.position.y >= limit && finished == false)
        {
            finished = true;
            mapTracker.transform.position = new(0f, 0f, 0f);
            score = Mathf.Round(score);

            player.SetActive(false);
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
            DestroyMeteors();
            showText.Invoke();
            moveCamera.Invoke();
            DetectMeteors();
            MoveObjects();
        }

        else if (finishedUniverse == true)
        {
            fullCameraTransition.Invoke();
        }
    }

    public void CreateUniverseStats()
    {
        sizeChange = UnityEngine.Random.Range(2, 6) / 10f;
        spreadChange = UnityEngine.Random.Range(3, 8) / 10f;
        speedChange = UnityEngine.Random.Range(7, 13) / 10f;
    }

    public void DestroyMeteors()
    {
        if (destroyMeteors == true)
        {
            foreach (Transform child in map.transform)
            {
                if (child.transform.position.x < -10 || child.transform.position.x > 10 || child.transform.position.y < -10 || child.transform.position.y > 10)
                {
                    Destroy(child.gameObject);
                }
            }
            if (finishedUniverse == true)
            {
                player.SetActive(false);
                createStar();
                setFullCamera.Invoke();
                finished = true;
            }
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
        for (float i = -5; i < 5; i += spread)
        {
            for (float j = 12; j < mapLength - 12; j += spread)
            {
                float x = UnityEngine.Random.Range(i, i + spread);
                float y = UnityEngine.Random.Range(j, j + spread);

                meteor.transform.localScale = new Vector3(size, size, 1);

                float red = UnityEngine.Random.Range(100, 255) / 255f;
                float green = UnityEngine.Random.Range(100, 255) / 255f;
                float blue = UnityEngine.Random.Range(100, 255) / 255f;

                meteor.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
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
        score += speed * Time.deltaTime / 10;
    }
}