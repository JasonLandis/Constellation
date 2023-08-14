using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// I am Matthew. I leave my easter egg here. I hope you enjoy it. :) 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Gameplay Variables")]
    public float size;
    public float spread;
    public float speed;
    public int lives;

    [Header("Transition")]
    public GameObject panel;
    public float duration;

    [Header("Universe Stats")]
    public float sizeChange;
    public float spreadChange;
    public float speedChange;
    public int zone = 1;

    [Header("Objects")]
    public GameObject playerPrefab;
    public GameObject starPrefab;
    public GameObject meteorPrefab;
    public GameObject map;
    public GameObject mapTracker;
    public GameObject background;
    public GameObject endMenu;
    public GameObject createdStars;
    public GameObject yourConstellation;
    public GameObject fullCameraObject;
    public GameObject constellationBackground;
    public Sprite endBackround;
    public GameObject lightObject;
    public GameObject infoScreen;
    public GameObject designBackground;
    public GameObject adsMenu;
    public GameObject readyMenu;
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject star;
    private BoxCollider2D playerBoxCollider;

    [Header("Gameplay")]
    public TextMeshProUGUI endScore;
    public TextMeshProUGUI endUniverseScore;
    public TextMeshProUGUI endCompletedScore;
    public TextMeshProUGUI completeScore;
    public TextMeshProUGUI completeUniverseScore;
    public TextMeshProUGUI completeCompletedScore;
    public Animator screen;
    public Camera mainCamera;
    public Image pauseButton;
    private Animator deathAnimation;
    private Vector2 bounds;
    private float negBoundsx;
    private float posBoundsx;
    private float negBoundsy;
    private float posBoundsy;
    private float yLimit;
    [HideInInspector] public int currentScore;
    [HideInInspector] public int currentUniverseScore;
    [HideInInspector] public bool isGameOver;
    [HideInInspector] public bool isGamePaused;
    [HideInInspector] public bool finished;
    [HideInInspector] public float distanceLeft;
    [HideInInspector] public bool immortal;
    private float countdownTime = 3;
    [HideInInspector] public float endTime = 2;
    [HideInInspector] public bool isPlayingAudio;
    [HideInInspector] public bool isPlayerPaused;
    [HideInInspector] public bool unPaused;
    [HideInInspector] public bool cannotPause;
    private bool canWatchAd = true;

    [Header("Meteors")]
    public List<Sprite> meteors;
    private SpriteRenderer meteorSprite;

    [Header("Player Prefs")]
    [HideInInspector] public float score;
    [HideInInspector] public float universeScore = 0;
    [HideInInspector] public int universesCleared;
    [HideInInspector] public string universeDifficulty;
    private bool hitless = true;

    [Header("Map Generation")]
    [HideInInspector] public int mapLength;
    [HideInInspector] public string direction;
    [HideInInspector] public Vector3 directionVector;
    [HideInInspector] public int limit = 0;

    [Header("Constellation")]
    [HideInInspector] public List<Vector3> constellationVectors;
    [HideInInspector] public Vector3 previousPosition = new(0, 0, 0);
    [HideInInspector] public bool transitionIsDone;

    [Header("End of Universe")]
    [HideInInspector] public bool destroyMeteors;
    [HideInInspector] public bool finishedUniverse;
    [HideInInspector] public bool resetUniverse;

    // Functions from ZoneController
    public Action zoneDetection;

    // Functions from GameUI
    public Action showScoreText;
    public Action showGameplayText;
    public Action showStatText;
    public Action openRaycast;

    // Functions from Constellation
    public Action createNewStar;
    public Action moveConstellationCamera;
    public Action fullCameraTransition;
    public Action setFullCamera;

    // Functions from Roguelike
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

        // Begin transition animation
        panel.GetComponent<Image>().color = new(0, 0, 0, 1);
        LeanTween.color(panel.GetComponent<Image>().rectTransform, new(0, 0, 0, 0), duration).setOnComplete(DeactivatePanel);

        // Detect the screen bounds
        bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        yLimit = bounds.x * 0.31695f;

        negBoundsx = bounds.x * -1 - 0.2f;
        posBoundsx = bounds.x + 0.2f;
        negBoundsy = bounds.y * -1 - 0.2f;
        posBoundsy = yLimit + 0.2f;
    }

    void Start()
    {
        // Load the info menu if its the users first time playing
        if (!PlayerPrefs.HasKey("First"))
        {
            infoScreen.SetActive(true);
        }
        PlayerPrefs.SetInt("First", 0);

        // Set the gameplay variables
        size = PlayerPrefs.GetFloat("Start Size", 1);
        spread = PlayerPrefs.GetInt("Start Spread", 5);
        speed = PlayerPrefs.GetInt("Start Speed", 10);
        lives = PlayerPrefs.GetInt("Start Lives", 0);

        // Get the score and universes cleared if its a saved game
        score = PlayerPrefs.GetInt("Current Score", 0);
        universesCleared = PlayerPrefs.GetInt("Current Universes", 0);

        // Create the universes difficulty
        CreateUniverseStats();

        // Instantiate the player and the star
        player = Instantiate(playerPrefab, new(0, -0.4197f, 0), Quaternion.identity, transform);
        player.GetComponent<TrailRenderer>().startColor = player.GetComponent<SpriteRenderer>().color;
        star = Instantiate(starPrefab, new(0, 0, 0), Quaternion.identity, yourConstellation.transform);

        // Get other objects
        playerBoxCollider = player.GetComponent<BoxCollider2D>();
        deathAnimation = player.GetComponent<Animator>();
        meteorSprite = meteorPrefab.GetComponent<SpriteRenderer>();
        lightObject.GetComponent<Light2D>().color = player.GetComponent<Light2D>().color;

        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (mapTracker.transform.position.y >= limit && finished == false) // Run this code only once when the destination is reached
        {
            finished = true;
            mapTracker.transform.position = new(0f, 0f, 0f); // Reset the maptracker

            // Destroy the old map
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }

            // Round the scores
            score = Mathf.Round(score);
            universeScore = Mathf.Round(universeScore);
            distanceLeft = 0;

            // Setup the UI
            createNewStar.Invoke();
            showScoreText.Invoke();
            showDistanceUI.Invoke();
            openRaycast.Invoke();

            // Show roguelike if player landed on a star
            if (constellationVectors.Contains(star.transform.position))
            {
                constellationVectors.Remove(star.transform.position);
                showRoguelike.Invoke();
            }
        }

        else if (playerBoxCollider.IsTouchingLayers(LayerMask.GetMask("Meteor")) && !immortal && !finished && !isGamePaused)
        {
            if (lives == 0)
            {
                cannotPause = true;

                // Play audio once
                if (!isPlayingAudio)
                {
                    FindAnyObjectByType<AudioManager>().Play("Hit");
                    currentScore = PlayerPrefs.GetInt("Current Score");
                    currentUniverseScore = PlayerPrefs.GetInt("Current Universes");

                    PlayerPrefs.DeleteKey("Current Score");
                    PlayerPrefs.DeleteKey("Current Universes");
                }
                isPlayingAudio = true;

                // Disable pause button and player movement
                pauseButton.raycastTarget = false;
                isPlayerPaused = true;
                hitless = false;

                // Start other animations
                deathAnimation.Play("End");
                screen.Play("Hit");

                // Time for animation to complete
                endTime -= Time.deltaTime;
                if (endTime <= 0)
                {
                    if (canWatchAd)
                    {
                        // Show ads menu
                        finished = true;
                        isGamePaused = true;
                        adsMenu.SetActive(true);
                        canWatchAd = false;
                    }
                    else
                    {
                        if (!finished)
                        {
                            EndGame();
                        }
                        finished = true;
                    }
                }
            }
            else
            {
                // Play hit animation and make player temporarily immortal
                FindAnyObjectByType<AudioManager>().Play("Hit");
                hitless = false;
                immortal = true;
                lives -= 1;
                showGameplayText.Invoke();
                screen.Play("Hit");
            }
        }

        else if (!finished && !isGamePaused)
        {
            ImmortalCheck();
            zoneDetection.Invoke();
            showScoreText.Invoke();
            moveConstellationCamera.Invoke();
            DetectMeteors();
            MoveObjects();
            DestroyMeteors();
        }

        else if (finishedUniverse && !isGamePaused)
        {
            if (!transitionIsDone)
            {
                fullCameraTransition.Invoke();
            }
            if (resetUniverse == true)
            {
                panel.SetActive(true);
                panel.GetComponent<Image>().raycastTarget = true;
                LeanTween.color(panel.GetComponent<Image>().rectTransform, new(0, 0, 0, 1), 0.3f).setOnComplete(Load);
            }
        }
    }

    // Button function for resuming after watching an ad
    public void Resume()
    {
        isGameOver = false;
        isPlayerPaused = false;
        isPlayingAudio = false;
        cannotPause = false;
        finished = false;
        unPaused = true;
        readyMenu.SetActive(false);
    }

    // Reset the main scene
    private void Load()
    {        
        SceneManager.LoadScene("Main");
    }

    // Deactivate the animation panel
    private void DeactivatePanel()
    {
        panel.SetActive(false);
    }

    // Creates the zone change values for the universe
    public void CreateUniverseStats()
    {
        sizeChange = UnityEngine.Random.Range(2, 7) / 10f;
        spreadChange = UnityEngine.Random.Range(7, 15) / 10f;
        speedChange = UnityEngine.Random.Range(13, 21) / 10f;
        
        if (sizeChange + spreadChange + speedChange < 3)
        {
            universeDifficulty = "<color=#11DC58>Easy</color>";
        }

        else if (sizeChange + spreadChange + speedChange < 3.3)
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
            if (child.transform.position.x < negBoundsx || child.transform.position.x > posBoundsx ||
                child.transform.position.y < negBoundsy || child.transform.position.y > posBoundsy)
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
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.down / 300));
        }
        else if (direction == "left")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.right / 300));
        }
        else if (direction == "right")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.left / 300));
        }
        else if (direction == "down")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.up / 300));
        }
        else if (direction == "upright")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.down / 300));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.left / 300));
        }
        else if (direction == "upleft")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.down / 300));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.right / 300));
        }
        else if (direction == "downright")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.up / 300));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.left / 300));
        }
        else if (direction == "downleft")
        {
            background.transform.Translate(speed * Time.deltaTime * (Vector3.up / 100));
            background.transform.Translate(speed * Time.deltaTime * (Vector3.right / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.down / 100));
            star.transform.Translate(speed * Time.deltaTime * (Vector3.left / 100));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.up / 300));
            designBackground.transform.Translate(speed * Time.deltaTime * (Vector3.right / 300));
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

                meteorPrefab.transform.localScale = new Vector3(size / 10, size / 10, 1);

                int rand = UnityEngine.Random.Range(0, 5);
                meteorSprite.sprite = meteors[rand];
                Instantiate(meteorPrefab, new(x, y, 0), Quaternion.identity, map.transform);
            }
        }
    }

    // Destroys the old map and generates a new one
    public void GenerateNewMap(Vector3 vector)
    {
        foreach (Transform child in map.transform)
        {
            if (child.transform.position.x < negBoundsx || child.transform.position.x > posBoundsx || child.transform.position.y < negBoundsy || child.transform.position.y > posBoundsy)
            {
                Destroy(child.gameObject);
            }
        }

        map.transform.SetPositionAndRotation(new Vector3(0, -0.4197f, 0), Quaternion.Euler(0, 0, 0));
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

        if (universeScore > PlayerPrefs.GetInt("Universe Score", 0))
        {
            PlayerPrefs.SetInt("Universe Score", (int)universeScore);
        }

        PlayerPrefs.SetInt("Total Distance", PlayerPrefs.GetInt("Total Distance", 0) + (int)universeScore);
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

        if (universeScore > PlayerPrefs.GetInt("Universe Score", 0))
        {
            PlayerPrefs.SetInt("Universe Score", (int)universeScore);
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

        if (PlayerPrefs.HasKey("Largest Size"))
        {
            if (size > PlayerPrefs.GetFloat("Largest Size"))
            {
                PlayerPrefs.SetFloat("Largest Size", (float)Math.Round(size, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Largest Size", (float)Math.Round(size, 1));
        }

        if (PlayerPrefs.HasKey("Smallest Spread"))
        {
            if (spread < PlayerPrefs.GetFloat("Smallest Spread"))
            {
                PlayerPrefs.SetFloat("Smallest Spread", (float)Math.Round(spread, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Smallest Spread", (float)Math.Round(spread, 1));
        }

        if (PlayerPrefs.HasKey("Largest Speed"))
        {
            if (speed > PlayerPrefs.GetFloat("Largest Speed"))
            {
                PlayerPrefs.SetFloat("Largest Speed", (float)Math.Round(speed, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Largest Speed", (float)Math.Round(speed, 1));
        }

        if (PlayerPrefs.HasKey("Smallest Size"))
        {
            if (size < PlayerPrefs.GetFloat("Smallest Size"))
            {
                PlayerPrefs.SetFloat("Smallest Size", (float)Math.Round(size, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Smallest Size", (float)Math.Round(size, 1));
        }

        if (PlayerPrefs.HasKey("Largest Spread"))
        {
            if (spread > PlayerPrefs.GetFloat("Largest Spread"))
            {
                PlayerPrefs.SetFloat("Largest Spread", (float)Math.Round(spread, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Largest Spread", (float)Math.Round(spread, 1));
        }

        if (PlayerPrefs.HasKey("Smallest Speed"))
        {
            if (speed < PlayerPrefs.GetFloat("Smallest Speed"))
            {
                PlayerPrefs.SetFloat("Smallest Speed", (float)Math.Round(speed, 1));
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Smallest Speed", (float)Math.Round(speed, 1));
        }

        if (PlayerPrefs.HasKey("Most Lives"))
        {
            if (lives > PlayerPrefs.GetInt("Most Lives", 0))
            {
                PlayerPrefs.SetInt("Most Lives", lives);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Most Lives", lives);
        }
    }

    // Creates the last star and ends the game
    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 1;
        SaveScores();
        constellationBackground.GetComponent<SpriteRenderer>().sprite = endBackround;
        background.GetComponent<SpriteRenderer>().sprite = endBackround;
        star.GetComponent<SpriteRenderer>().enabled = false;
        star.GetComponent<Light2D>().enabled = false;
        lightObject.GetComponent<Light2D>().enabled = false;
        endScore.text = ((int)score).ToString();
        endUniverseScore.text = ((int)universeScore).ToString();
        endCompletedScore.text = universesCleared.ToString();
        createNewStar.Invoke();
        player.transform.position = new(0, 0, 0);
        player.GetComponent<Light2D>().volumeIntensityEnabled = true;
        fullCameraObject.SetActive(true);
        endMenu.SetActive(true);
        createdStars.SetActive(false);
    }

    // Destroys remaining meteors and detects if the universe is finished
    public void DestroyMeteors()
    {
        if (destroyMeteors == true)
        {
            // Play animation and audio once
            if (limit != 110)
            {
                screen.Play("Complete");
                FindAnyObjectByType<AudioManager>().Play("IncreaseZone");
            }
            limit = 110;

            // Deactivate all meteors not on the screen
            foreach (Transform child in map.transform)
            {
                if (child.transform.position.x < -1 || child.transform.position.x > 1 || child.transform.position.y < -1.4 || child.transform.position.y > 0.3)
                {
                    Destroy(child.gameObject);
                }
            }

            // Does a bunch of stuff once universe is completed
            if (finishedUniverse == true)
            {
                isGameOver = true;
                constellationBackground.GetComponent<SpriteRenderer>().sprite = endBackround;
                background.GetComponent<SpriteRenderer>().sprite = endBackround;
                player.transform.position = new(0, 0, 0);
                player.GetComponent<Light2D>().volumeIntensityEnabled = true;
                star.GetComponent<SpriteRenderer>().enabled = false;
                star.GetComponent<Light2D>().enabled = false;
                universesCleared += 1;
                PlayerPrefs.SetInt("Current Score", (int)score);
                PlayerPrefs.SetInt("Current Lives", lives);
                PlayerPrefs.SetInt("Current Universes", universesCleared);
                completeScore.text = ((int)score).ToString();
                completeUniverseScore.text = ((int)universeScore).ToString();
                completeCompletedScore.text = (universesCleared).ToString();
                createNewStar();
                fullCameraObject.SetActive(true);
                setFullCamera.Invoke();
                SaveUniverseScores();
                SaveScores();
                finished = true;                
            }
        }
    }
}