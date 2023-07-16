using System;
using System.Collections.Generic;
using TMPro;
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

    [Header("Universe Stats")]
    public float sizeChange;
    public float spreadChange;
    public float speedChange;
    public int universeTokens;

    [Header("Objects")]
    public GameObject player;
    public GameObject meteor;
    public GameObject map;
    public GameObject star;
    public GameObject background;
    public GameObject mapTracker;
    public GameObject endScreen;
    public GameObject cover;
    public GameObject createdStars;

    [Header("Other")]
    public BoxCollider2D boxCollider;
    public TextMeshProUGUI endScore;
    public Animator Hit;
    public Animator End;

    [HideInInspector] public int mapLength;
    [HideInInspector] public string direction;
    [HideInInspector] public bool immortal;
    [HideInInspector] public Vector3 directionVector;
    [HideInInspector] public float score;
    [HideInInspector] public int limit = 0;
    [HideInInspector] public bool destroyMeteors;
    [HideInInspector] public bool finishedUniverse;
    [HideInInspector] public bool resetUniverse;
    [HideInInspector] public List<Vector3> constellationVectors;
    [HideInInspector] public bool isGameOver;
    private float countdownTime = 3;
    private float endTime = 2;
    private bool finished;

    // Functions from ZoneController
    public Action zoneDetection;
    public Action resetZones;

    // Functions from GameUI
    public Action showText;
    public Action showStatText;
    public Action showUniverseTokensText;

    // Functions from Constellation
    public Action createNewStar;
    public Action moveConstellationCamera;
    public Action fullCameraTransition;
    public Action setFullCamera;
    public Action resetConstellation;

    // Functions from Roguelike
    public Action showRoguelike;
    public Action showDistanceUI;

    // Functions from CreateUniverse
    public Action createUniverseStats;

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
        Application.targetFrameRate = 60;
        CreateUniverseStats();
        showStatText.Invoke();
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
            cover.SetActive(false);
            showText.Invoke();
            showDistanceUI.Invoke();
            createNewStar.Invoke();

            if (constellationVectors.Contains(star.transform.position))
            {
                constellationVectors.Remove(star.transform.position);
                showRoguelike.Invoke();
            }
        }

        else if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Meteor")) && immortal == false)
        {
            if (lives == 0)
            {
                isGameOver = true;
                End.Play("End");
                Hit.Play("Hit");
                player.isStatic = true;
                endTime -= Time.deltaTime;
                if (endTime <= 0)
                {
                    EndGame();
                }
            }
            else
            {
                immortal = true;
                lives -= 1;
                Hit.Play("Hit");
            }
        }        

        else if (finished == false)
        {
            ImmortalCheck();
            zoneDetection.Invoke();
            showText.Invoke();
            moveConstellationCamera.Invoke();
            DetectMeteors();
            MoveObjects();
            DestroyMeteors();
        }

        else if (finishedUniverse == true)
        {
            fullCameraTransition.Invoke();
            if (resetUniverse == true)
            {
                ResetUniverse();
            }
        }
    }

    // Creates the zone change values for the universe
    public void CreateUniverseStats()
    {
        sizeChange = UnityEngine.Random.Range(2, 6) / 10f;
        spreadChange = UnityEngine.Random.Range(3, 8) / 10f;
        speedChange = UnityEngine.Random.Range(7, 13) / 10f;
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

    // Detects which meteors are out of view and sets them inactive
    public void DetectMeteors()
    {
        foreach (Transform child in map.transform)
        {
            child.transform.Translate(speed * Time.deltaTime * Vector3.down / 10);
            if (child.transform.position.x < -1 || child.transform.position.x > 1 ||
                child.transform.position.y < -1.4 || child.transform.position.y > 0.4)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    // Moves the star, background, and map tracker
    public void MoveObjects()
    {
        if (direction == "up")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
        }
        else if (direction == "left")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
        }
        else if (direction == "right")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
        }
        else if (direction == "down")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
        }
        else if (direction == "upright")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
        }
        else if (direction == "upleft")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
        }
        else if (direction == "downright")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
        }
        else if (direction == "downleft")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
        }

        // Move the map tracker
        mapTracker.transform.Translate(speed * Time.deltaTime * Vector3.up / 10);
        score += speed * Time.deltaTime / 10;
    }

    // Generates a map of meteors
    public void GenerateMap(int mapLength)
    {
        // Create meteors
        for (float i = -1; i < 1; i += spread / 10)
        {
            for (float j = 1; j < mapLength - 1; j += spread / 10)
            {
                float x = UnityEngine.Random.Range(i, i + spread / 10);
                float y = UnityEngine.Random.Range(j, j + spread / 10);

                meteor.transform.localScale = new Vector3(size / 10, size / 10, 1);

                float color = UnityEngine.Random.Range(20, 50) / 255f;

                meteor.GetComponent<SpriteRenderer>().color = new(color, color, color, 1);
                Instantiate(meteor, new(x, y, 0), Quaternion.identity, map.transform);
            }
        }
    }

    // Destroys the old map and generates a new one
    public void GenerateNewMap(Vector3 vector)
    {
        foreach (Transform child in map.transform)
        {
            if (child.transform.position.x < -1 || child.transform.position.x > 1 || child.transform.position.y < -1.4 || child.transform.position.y > 0.4)
            {
                Destroy(child.gameObject);
            }
        }

        map.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        GenerateMap(limit - (int)mapTracker.transform.position.y - 1);
        map.transform.rotation = Quaternion.Euler(vector);
        finished = false;
    }

    // Creates the last star and ends the game
    public void EndGame()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }
        player.SetActive(false);
        endScore.text = ((int)score).ToString();
        showText.Invoke();
        isGameOver = true;
        createNewStar.Invoke();
        endScreen.SetActive(true);
        createdStars.SetActive(false);
        Time.timeScale = 0f;
    }

    // Destroys remaining meteors and detects if the universe is finished
    public void DestroyMeteors()
    {
        if (destroyMeteors == true)
        {
            limit = 110;
            foreach (Transform child in map.transform)
            {
                if (child.transform.position.x < -1 || child.transform.position.x > 1 || child.transform.position.y < -1.4 || child.transform.position.y > 0.3)
                {
                    Destroy(child.gameObject);
                }
            }
            if (finishedUniverse == true)
            {
                player.SetActive(false);
                createUniverseStats.Invoke();
                createNewStar();
                setFullCamera.Invoke();
                universeTokens += 1;
                showUniverseTokensText.Invoke();
                finished = true;
            }
        }
    }

    // Reset the universe
    public void ResetUniverse()
    {
        resetZones.Invoke();
        resetConstellation.Invoke();
        star.GetComponent<LineRenderer>().positionCount = 0;
        star.transform.position = Vector3.zero;
        background.transform.position = Vector3.zero;
        mapTracker.transform.position = new(0f, 0f, 0f);
        limit = 0;
        size = 1;
        spread = 5;
        speed = 10;
        zone = 1;
        finished = false;
        finishedUniverse = false;
        destroyMeteors = false;
        resetUniverse = false;
        showStatText.Invoke();
        showDistanceUI.Invoke();
    }
}