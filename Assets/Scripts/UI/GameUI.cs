using System;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("Objects")]
    public GameObject directionUI;
    public GameObject distanceUI;
    public GameObject totalScoreUI;
    public GameObject universeScoreUI;
    public GameObject distanceLeftUI;

    [Header("Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI spreadText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI zoneText;
    public TextMeshProUGUI sizeChangeText;
    public TextMeshProUGUI spreadChangeText;
    public TextMeshProUGUI speedChangeText;
    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI difficultyUIText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI universeScoreText;
    public TextMeshProUGUI distanceLeftText;

    void Start()
    {
        GameManager.instance.showText += ShowText;
        GameManager.instance.showStatText += ShowStatText;
        GameManager.instance.showDistanceUI += ShowDistanceUI;
    }

    // Button functions for arrow directions
    public void Up()
    {
        GameManager.instance.directionVector = Vector3.zero;
        GameManager.instance.direction = "up";
        ShowDistance();
    }
    public void Down()
    {
        GameManager.instance.directionVector = new(0, 0, 180);
        GameManager.instance.direction = "down";
        ShowDistance();
    }
    public void Left()
    {
        GameManager.instance.directionVector = new(0, 0, 90);
        GameManager.instance.direction = "left";
        ShowDistance();
    }
    public void Right()
    {
        GameManager.instance.directionVector = new(0, 0, 270);
        GameManager.instance.direction = "right";
        ShowDistance();
    }
    public void UpRight()
    {
        GameManager.instance.directionVector = new(0, 0, 315);
        GameManager.instance.direction = "upright";
        ShowDistance();
    }
    public void DownRight()
    {
        GameManager.instance.directionVector = new(0, 0, 225);
        GameManager.instance.direction = "downright";
        ShowDistance();
    }
    public void UpLeft()
    {
        GameManager.instance.directionVector = new(0, 0, 45);
        GameManager.instance.direction = "upleft";
        ShowDistance();
    }
    public void DownLeft()
    {
        GameManager.instance.directionVector = new(0, 0, 135);
        GameManager.instance.direction = "downleft";
        ShowDistance();
    }

    // Button functions for map length
    public void Ten()
    {
        GameManager.instance.player.SetActive(true);
        GameManager.instance.mapLength = 10;
        GameManager.instance.limit = 10;
        GameManager.instance.distanceLeft = 10;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
        GameManager.instance.cover.SetActive(true);
    }
    public void Twenty()
    {
        GameManager.instance.player.SetActive(true);
        GameManager.instance.mapLength = 20;
        GameManager.instance.limit = 20;
        GameManager.instance.distanceLeft = 20;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
        GameManager.instance.cover.SetActive(true);
    }
    public void Thirty()
    {
        GameManager.instance.player.SetActive(true);
        GameManager.instance.mapLength = 30;
        GameManager.instance.limit = 30;
        GameManager.instance.distanceLeft = 30;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
        GameManager.instance.cover.SetActive(true);
    }

    // Button functions for switching between arrows and direction screen
    private void ShowDistance()
    {
        directionUI.SetActive(false);
        distanceUI.SetActive(true);
    }
    public void HideDistance()
    {
        directionUI.SetActive(true);
        distanceUI.SetActive(false);
    }

    // Updates the text objects
    public void ShowText()
    {
        livesText.text = GameManager.instance.lives.ToString();
        spreadText.text = Math.Round(GameManager.instance.spread, 1).ToString();
        sizeText.text = Math.Round(GameManager.instance.size, 1).ToString();
        speedText.text = Math.Round(GameManager.instance.speed, 1).ToString();
        totalScoreText.text = ((int)GameManager.instance.score).ToString();
        universeScoreText.text = ((int)GameManager.instance.universeScore).ToString();
        distanceLeftText.text = (Math.Ceiling(GameManager.instance.distanceLeft)).ToString();
        zoneText.text = GameManager.instance.zone.ToString();
    }
    public void ShowStatText()
    {
        sizeChangeText.text = "+ " + GameManager.instance.sizeChange.ToString();
        spreadChangeText.text = "- " + GameManager.instance.spreadChange.ToString();
        speedChangeText.text = "+ " + GameManager.instance.speedChange.ToString();
        difficultyText.text = GameManager.instance.universeDifficulty;
        difficultyUIText.text = GameManager.instance.universeDifficulty;
    }

    // Set the distance UI to active
    public void ShowDistanceUI()
    {
        directionUI.SetActive(true);
    }

    // Toggling score UI
    public void SwapToTotalScore()
    {
        distanceLeftUI.SetActive(false);
        totalScoreUI.SetActive(true);
    }
    public void SwapToUniverseScore()
    {
        totalScoreUI.SetActive(false);
        universeScoreUI.SetActive(true);
    }
    public void SwapToDistanceLeft()
    {
        universeScoreUI.SetActive(false);
        distanceLeftUI.SetActive(true);
    }    
}
