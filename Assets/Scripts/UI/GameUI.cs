using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("Objects")]
    public GameObject directionUI;
    public GameObject distanceUI;

    [Header("Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager.instance.showText += ShowText;
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
        GameManager.instance.mapLength = 10;
        GameManager.instance.limit = 10;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Twenty()
    {
        GameManager.instance.mapLength = 20;
        GameManager.instance.limit = 20;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Thirty()
    {
        GameManager.instance.mapLength = 30;
        GameManager.instance.limit = 30;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Forty()
    {
        GameManager.instance.mapLength = 40;
        GameManager.instance.limit = 40;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Fifty()
    {
        GameManager.instance.mapLength = 50;
        GameManager.instance.limit = 50;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Sixty()
    {
        GameManager.instance.mapLength = 60;
        GameManager.instance.limit = 60;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Seventy()
    {
        GameManager.instance.mapLength = 70;
        GameManager.instance.limit = 70;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Eighty()
    {
        GameManager.instance.mapLength = 80;
        GameManager.instance.limit = 80;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Ninety()
    {
        GameManager.instance.mapLength = 90;
        GameManager.instance.limit = 90;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
    }
    public void Hundred()
    {
        GameManager.instance.mapLength = 100;
        GameManager.instance.limit = 100;
        GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
        distanceUI.SetActive(false);
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
        distanceText.text = GameManager.instance.distance.ToString();
        sizeText.text = GameManager.instance.size.ToString();
        speedText.text = GameManager.instance.speed.ToString();
        scoreText.text = GameManager.instance.score.ToString();
    }

    // Set the distance UI to active
    public void ShowDistanceUI()
    {
        directionUI.SetActive(true);
    }
}

