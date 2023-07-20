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

    [Header("Objects")]
    public GameObject playerPrefab;
    public GameObject meteor;
    public GameObject map;
    public GameObject starPrefab;
    public GameObject background;
    public GameObject mapTracker;
    public GameObject endScreen;
    public GameObject cover;
    public GameObject createdStars;
    public GameObject yourConstellation;

    [Header("Other")]
    public TextMeshProUGUI endScore;
    public Animator hit;
    public Animator complete;

    [Header("Player Prefs")]
    [HideInInspector] public float score;
    [HideInInspector] public float universeScore = 0;
    private int universesCleared;
    [HideInInspector] public string universeDifficulty;
    private bool hitless = true;

    [Header("Other")]
    [HideInInspector] public int mapLength;
    [HideInInspector] public string direction;
    [HideInInspector] public bool immortal;
    [HideInInspector] public Vector3 directionVector;
    [HideInInspector] public int limit = 0;
    [HideInInspector] public bool destroyMeteors;
    [HideInInspector] public bool finishedUniverse;
    [HideInInspector] public bool resetUniverse;
    [HideInInspector] public List<Vector3> constellationVectors;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject star;
    [HideInInspector] public bool finished;
    [HideInInspector] public float distanceLeft;
    private BoxCollider2D playerBoxCollider;
    private Animator deathAnimation;
    private float countdownTime = 3;
    private float endTime = 2;

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
        // Instantiate the player
        player = Instantiate(playerPrefab, new(0, -0.432f, 0), Quaternion.identity, transform);
        playerBoxCollider = player.GetComponent<BoxCollider2D>();
        deathAnimation = player.GetComponent<Animator>();

        // Instantiate the star
        star = Instantiate(starPrefab, new(0, 0, 0), Quaternion.identity, yourConstellation.transform);

        // Create the universe stats and show the text
        CreateUniverseStats();
        showStatText.Invoke();

        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (mapTracker.transform.position.y >= limit && finished == false) // Run this code only once when the destination is reached
        {
            finished = true;
            mapTracker.transform.position = new(0f, 0f, 0f);

            // Round and save the scores
            score = Mathf.Round(score);
            universeScore = Mathf.Round(universeScore);
            distanceLeft = 0;
            SaveGameScores();

            // Setup the UI
            player.SetActive(false);
            player.transform.position = new(0, -0.432f, 0);
            cover.SetActive(false);
            createNewStar.Invoke();
            showText.Invoke();
            showDistanceUI.Invoke();

            // Show roguelike if player landed on a star
            if (constellationVectors.Contains(star.transform.position))
            {
                constellationVectors.Remove(star.transform.position);
                showRoguelike.Invoke();
            }            
        }

        else if (playerBoxCollider.IsTouchingLayers(LayerMask.GetMask("Meteor")) && immortal == false)
        {
            if (lives == 0)
            {
                isGameOver = true;
                hitless = false;

                // Player animation
                player.isStatic = true;
                deathAnimation.Play("End");
                hit.Play("Hit");
                endTime -= Time.deltaTime;
                if (endTime <= 0)
                {
                    EndGame();
                }
            }
            else
            {
                // Temporarily immortal
                hitless = false;
                immortal = true;
                lives -= 1;
                hit.Play("Hit");
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
        sizeChange = UnityEngine.Random.Range(2, 7) / 10f;
        spreadChange = UnityEngine.Random.Range(3, 9) / 10f;
        speedChange = UnityEngine.Random.Range(7, 14) / 10f;
        
        if (sizeChange + spreadChange + speedChange < 1.9)
        {
            universeDifficulty = "<color=#11DC58>Easy</color>";
        }

        else if (sizeChange + spreadChange + speedChange < 2.1)
        {
            universeDifficulty = "<color=#E0E0E0>Normal</color>";
        }

        else
        {
            universeDifficulty = "<color=#E54B4B>Hard</color>";
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

        // Move the map tracker and keep score
        mapTracker.transform.Translate(speed * Time.deltaTime * Vector3.up / 10);
        score += speed * Time.deltaTime / 10;
        universeScore += speed * Time.deltaTime / 10;
        distanceLeft -= speed * Time.deltaTime / 10;
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

    // Saves Player Prefs score data
    public void SaveScores()
    {
        if (score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", (int)score);
        }

        if (universeScore > PlayerPrefs.GetInt("Largest Constellation", 0))
        {
            PlayerPrefs.SetInt("Largest Constellation", (int)universeScore);
        }

        PlayerPrefs.SetInt("Total Distance", PlayerPrefs.GetInt("Total Distance", 0) + (int)score);
    }

    // Saves Player Prefs universe data
    public void SaveUniverseScores()
    {
        if (PlayerPrefs.HasKey("Quickest Universe"))
        {
            if (universeScore < PlayerPrefs.GetInt("Quickest Universe"))
            {
                PlayerPrefs.SetInt("Quickest Universe", (int)universeScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Quickest Universe", (int)universeScore);
        }

        if (universeScore > PlayerPrefs.GetInt("Largest Constellation", 0))
        {
            PlayerPrefs.SetInt("Largest Constellation", (int)universeScore);
        }

        PlayerPrefs.SetInt("Total Universes", PlayerPrefs.GetInt("Total Universes", 0) + 1);

        if (hitless == true)
        {
            PlayerPrefs.SetInt("Hitless Universes", PlayerPrefs.GetInt("Hitless Universes", 0) + 1);
        }

        if (universeDifficulty == "<color=#11DC58>Easy</color>")
        {
            PlayerPrefs.SetInt("Easy Universes", PlayerPrefs.GetInt("Easy Universes", 0) + 1);
            if (hitless == true)
            {
                PlayerPrefs.SetInt("Hitless Easy Universes", PlayerPrefs.GetInt("Hitless Easy Universes", 0) + 1);
            }
        }
        else if (universeDifficulty == "<color=#E0E0E0>Normal</color>")
        {
            PlayerPrefs.SetInt("Normal Universes", PlayerPrefs.GetInt("Normal Universes", 0) + 1);
            if (hitless == true)
            {
                PlayerPrefs.SetInt("Hitless Normal Universes", PlayerPrefs.GetInt("Hitless Normal Universes", 0) + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Hard Universes", PlayerPrefs.GetInt("Hard Universes", 0) + 1);
            if (hitless == true)
            {
                PlayerPrefs.SetInt("Hitless Hard Universes", PlayerPrefs.GetInt("Hitless Hard Universes", 0) + 1);
            }
        }

        if (universesCleared > PlayerPrefs.GetInt("Most Universes", 0))
        {
            PlayerPrefs.SetInt("Most Universes", universesCleared);
        }
    }

    //  Saves Player Prefs gameplay data
    public void SaveGameScores()
    {
        if (size > PlayerPrefs.GetFloat("Largest Size", 1))
        {
            PlayerPrefs.SetFloat("Largest Size", (float)Math.Round(size, 1));
        }

        if (spread > PlayerPrefs.GetFloat("Largest Spread", 5))
        {
            PlayerPrefs.SetFloat("Largest Spread", (float)Math.Round(spread, 1));
        }

        if (speed > PlayerPrefs.GetFloat("Largest Speed", 10))
        {
            PlayerPrefs.SetFloat("Largest Speed", (float)Math.Round(speed, 1));
        }

        if (size < PlayerPrefs.GetFloat("Smallest Size", 1))
        {
            PlayerPrefs.SetFloat("Smallest Size", (float)Math.Round(size, 1));
        }

        if (spread < PlayerPrefs.GetFloat("Smallest Spread", 5))
        {
            PlayerPrefs.SetFloat("Smallest Spread", (float)Math.Round(spread, 1));
        }

        if (speed < PlayerPrefs.GetFloat("Smallest Speed", 5))
        {
            PlayerPrefs.SetFloat("Smallest Speed", (float)Math.Round(speed, 1));
        }

        if (lives > PlayerPrefs.GetInt("Most Lives", 0))
        {
            PlayerPrefs.SetInt("Most Lives", lives);
        }
    }

    // Creates the last star and ends the game
    public void EndGame()
    {
        SaveScores();
        SaveGameScores();
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
            complete.Play("Complete");
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
                universesCleared += 1;
                SaveUniverseScores();
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
        universeScore = 0;
        finished = false;
        finishedUniverse = false;
        destroyMeteors = false;
        resetUniverse = false;
        showStatText.Invoke();
        showDistanceUI.Invoke();
    }
}