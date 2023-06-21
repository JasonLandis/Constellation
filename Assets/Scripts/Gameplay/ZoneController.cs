using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [Header("Constellation Zones")]
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;
    public GameObject zone5;
    public GameObject zone6;
    public GameObject zone7;
    public GameObject zone8;
    public GameObject zone9;
    public GameObject zone10;
    public GameObject zoneLine;
    public GameObject zone10Extended;

    [Header("Background Zones")]
    public GameObject backgroundZone1;
    public GameObject backgroundZone2;
    public GameObject backgroundZone3;
    public GameObject backgroundZone4;
    public GameObject backgroundZone5;
    public GameObject backgroundZone6;
    public GameObject backgroundZone7;
    public GameObject backgroundZone8;
    public GameObject backgroundZone9;
    public GameObject backgroundZone10;
    public GameObject backgroundZoneLine;
    public GameObject backgroundZone10Extended;


    private int value = 0; // Used for the previous zone the star was in
    private int minSpeedZone = 1; // Used for the highest zone at which speed should not decrease
    private int minSizeZone = 1; // Used for the highest zone at which size should not decrease
    private int maxSpreadZone = 1; // Used for the highest zone at which the spread should not increase

    void Start()
    {
        CreateZones();
        GameManager.instance.zoneDetection += DetectDifficulty;
        GameManager.instance.zoneDetection += SetDifficulty;
    }

    // Detects which zone the star is in
    void DetectDifficulty()
    {
        // Detects difficulty level based on location within constellation map
        if (GameManager.instance.star.transform.position.y > -35 && GameManager.instance.star.transform.position.y < 35 && GameManager.instance.star.transform.position.x > -35 && GameManager.instance.star.transform.position.x < 35)
        {
            GameManager.instance.zone = 1;
        }
        else if (GameManager.instance.star.transform.position.y > -65 && GameManager.instance.star.transform.position.y < 65 && GameManager.instance.star.transform.position.x > -65 && GameManager.instance.star.transform.position.x < 65)
        {
            GameManager.instance.zone = 2;
        }
        else if (GameManager.instance.star.transform.position.y > -95 && GameManager.instance.star.transform.position.y < 95 && GameManager.instance.star.transform.position.x > -95 && GameManager.instance.star.transform.position.x < 95)
        {
            GameManager.instance.zone = 3;
        }
        else if (GameManager.instance.star.transform.position.y > -125 && GameManager.instance.star.transform.position.y < 125 && GameManager.instance.star.transform.position.x > -125 && GameManager.instance.star.transform.position.x < 125)
        {
            GameManager.instance.zone = 4;
        }
        else if (GameManager.instance.star.transform.position.y > -155 && GameManager.instance.star.transform.position.y < 155 && GameManager.instance.star.transform.position.x > -155 && GameManager.instance.star.transform.position.x < 155)
        {
            GameManager.instance.zone = 5;
        }
        else if (GameManager.instance.star.transform.position.y > -185 && GameManager.instance.star.transform.position.y < 185 && GameManager.instance.star.transform.position.x > -185 && GameManager.instance.star.transform.position.x < 185)
        {
            GameManager.instance.zone = 6;
        }
        else if (GameManager.instance.star.transform.position.y > -215 && GameManager.instance.star.transform.position.y < 215 && GameManager.instance.star.transform.position.x > -215 && GameManager.instance.star.transform.position.x < 215)
        {
            GameManager.instance.zone = 7;
        }
        else if (GameManager.instance.star.transform.position.y > -245 && GameManager.instance.star.transform.position.y < 245 && GameManager.instance.star.transform.position.x > -245 && GameManager.instance.star.transform.position.x < 245)
        {
            GameManager.instance.zone = 8;
        }
        else if (GameManager.instance.star.transform.position.y > -275 && GameManager.instance.star.transform.position.y < 275 && GameManager.instance.star.transform.position.x > -275 && GameManager.instance.star.transform.position.x < 275)
        {
            GameManager.instance.zone = 9;
        }
        else if (GameManager.instance.star.transform.position.y > -302.5 && GameManager.instance.star.transform.position.y < 302.5 && GameManager.instance.star.transform.position.x > -302.5 && GameManager.instance.star.transform.position.x < 302.5)
        {
            GameManager.instance.zone = 10;
        }
        else if (GameManager.instance.star.transform.position.y > -305 && GameManager.instance.star.transform.position.y < 305 && GameManager.instance.star.transform.position.x > -305 && GameManager.instance.star.transform.position.x < 305)
        {
            GameManager.instance.destroyMeteors = true;
        }
        else
        {
            GameManager.instance.finishedUniverse = true;
;       }
    }

    // Creates zone colors
    void CreateZones()
    {
        float red = Random.Range(57, 73);
        float green = Random.Range(57, 73);
        float blue = Random.Range(57, 73);

        if (red >= green && red >= blue)
        {
            red = 73;
            if (green >= blue)
            {
                blue = 57;
            }
            else
            {
                green = 57;
            }
        }
        else if (green >= red && green >= blue)
        {
            green = 73;
            if (red >= blue)
            {
                blue = 57;
            }
            else
            {
                red = 57;
            }
        }
        else if (blue >= red && blue >= green)
        {
            blue = 73;
            if (green >= red)
            {
                red = 57;
            }
            else
            {
                green = 57;
            }
        }

        red /= 255;
        green /= 255;
        blue /= 255;

        backgroundZone1.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
        backgroundZone2.GetComponent<SpriteRenderer>().color = new(red * 0.95f, green * 0.95f, blue * 0.95f, 1);
        backgroundZone3.GetComponent<SpriteRenderer>().color = new(red * 0.90f, green * 0.90f, blue * 0.90f, 1);
        backgroundZone4.GetComponent<SpriteRenderer>().color = new(red * 0.85f, green * 0.85f, blue * 0.85f, 1);
        backgroundZone5.GetComponent<SpriteRenderer>().color = new(red * 0.80f, green * 0.80f, blue * 0.80f, 1);
        backgroundZone6.GetComponent<SpriteRenderer>().color = new(red * 0.75f, green * 0.75f, blue * 0.75f, 1);
        backgroundZone7.GetComponent<SpriteRenderer>().color = new(red * 0.70f, green * 0.70f, blue * 0.70f, 1);
        backgroundZone8.GetComponent<SpriteRenderer>().color = new(red * 0.65f, green * 0.65f, blue * 0.65f, 1);
        backgroundZone9.GetComponent<SpriteRenderer>().color = new(red * 0.60f, green * 0.60f, blue * 0.60f, 1);
        backgroundZone10.GetComponent<SpriteRenderer>().color = new(red * 0.55f, green * 0.55f, blue * 0.55f, 1);
        backgroundZoneLine.GetComponent<SpriteRenderer>().color = new(red * 0.65f, green * 0.65f, blue * 0.65f, 1);
        backgroundZone10Extended.GetComponent<SpriteRenderer>().color = new(red * 0.55f, green * 0.55f, blue * 0.55f, 1);

        zone1.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
        zone2.GetComponent<SpriteRenderer>().color = new(red * 0.95f, green * 0.95f, blue * 0.95f, 1);
        zone3.GetComponent<SpriteRenderer>().color = new(red * 0.90f, green * 0.90f, blue * 0.90f, 1);
        zone4.GetComponent<SpriteRenderer>().color = new(red * 0.85f, green * 0.85f, blue * 0.85f, 1);
        zone5.GetComponent<SpriteRenderer>().color = new(red * 0.80f, green * 0.80f, blue * 0.80f, 1);
        zone6.GetComponent<SpriteRenderer>().color = new(red * 0.75f, green * 0.75f, blue * 0.75f, 1);
        zone7.GetComponent<SpriteRenderer>().color = new(red * 0.70f, green * 0.70f, blue * 0.70f, 1);
        zone8.GetComponent<SpriteRenderer>().color = new(red * 0.65f, green * 0.65f, blue * 0.65f, 1);
        zone9.GetComponent<SpriteRenderer>().color = new(red * 0.60f, green * 0.60f, blue * 0.60f, 1);
        zone10.GetComponent<SpriteRenderer>().color = new(red * 0.55f, green * 0.55f, blue * 0.55f, 1);
        zoneLine.GetComponent<SpriteRenderer>().color = new(red * 0.65f, green * 0.65f, blue * 0.65f, 1);
        zone10Extended.GetComponent<SpriteRenderer>().color = new(red * 0.55f, green * 0.55f, blue * 0.55f, 1);
    }

    // Sets the difficulty depending on the zone
    void SetDifficulty()
    {
        // Set difficulty levels
        switch (GameManager.instance.zone)
        {
            case 1:
                if (value > 1)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 1;
                break;
            case 2:
                if (value > 2)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 2)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 2;
                break;
            case 3:
                if (value > 3)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 3)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 3;
                break;
            case 4:
                if (value > 4)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 4)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 4;
                break;
            case 5:
                if (value > 5)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 5)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 5;
                break;
            case 6:
                if (value > 6)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 6)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 6;
                break;
            case 7:
                if (value > 7)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 7)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 7;
                break;
            case 8:
                if (value > 8)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 8)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 8;
                break;
            case 9:
                if (value > 9)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 9)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 9;
                break;
            case 10:
                if (value > 10)
                {
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 10)
                {
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 10;
                break;            
        }        
    }

    // Decreases the speed, spread, and size when moving to a lower zone
    void DecreaseZone()
    {
        if (GameManager.instance.speed > 1)
        {
            GameManager.instance.speed -= GameManager.instance.speedChange;
            if (GameManager.instance.speed < 1)
            {
                GameManager.instance.speed = 1;
            }
        }
        else
        {
            if (GameManager.instance.zone >= minSpeedZone)
            {
                minSpeedZone = GameManager.instance.zone + 1;
            }
        }
        if (GameManager.instance.spread < 10)
        {
            GameManager.instance.spread += GameManager.instance.spreadChange;
            if (GameManager.instance.spread > 10)
            {
                GameManager.instance.spread = 10;
            }
        }
        else
        {
            if (GameManager.instance.zone >= maxSpreadZone)
            {
                maxSpreadZone = GameManager.instance.zone + 1;
            }
        }
        if (GameManager.instance.size > 0.2f)
        {
            GameManager.instance.size -= GameManager.instance.sizeChange;
            if (GameManager.instance.size < 0.2f)
            {
                GameManager.instance.size = 0.2f;
            }
        }
        else
        {
            if (GameManager.instance.zone >= minSizeZone)
            {
                minSizeZone = GameManager.instance.zone + 1;
            }
        }
    }

    // Increases the speed, spread, and size when moving to a higher zone
    void IncreaseZone()
    {
        if (minSpeedZone < GameManager.instance.zone)
        {
            GameManager.instance.speed += GameManager.instance.speedChange;
        }
        if (GameManager.instance.spread > 0 && maxSpreadZone < GameManager.instance.zone)
        {
            GameManager.instance.spread -= GameManager.instance.spreadChange;
        }
        if (minSizeZone < GameManager.instance.zone)
        {
            GameManager.instance.size += GameManager.instance.sizeChange;
        }
    }
}