using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [Header("Backgrounds")]
    public GameObject background;
    public GameObject constellationBackground;

    [Header("Animation")]
    public Animator zoneChange;

    private int value = 0; // Used for the previous zone the star was in
    private int minSpeedZone = 1; // Used for the highest zone at which speed should not decrease
    private int minSizeZone = 1; // Used for the highest zone at which size should not decrease
    private int maxSpreadZone = 1; // Used for the highest zone at which the spread should not increase

    void Start()
    {
        CreateZoneColors();
        GameManager.instance.zoneDetection += DetectDifficulty;
        GameManager.instance.zoneDetection += SetDifficulty;
        GameManager.instance.resetZones += ResetZones;
    }

    // Create random zone colors
    void CreateZoneColors()
    {
        float red = Random.Range(83, 147);
        float green = Random.Range(83, 147);
        float blue = Random.Range(83, 147);

        if (red >= green && red >= blue)
        {
            red = 147;
            if (green >= blue)
            {
                blue = 83;
            }
            else
            {
                green = 83;
            }
        }
        else if (green >= red && green >= blue)
        {
            green = 147;
            if (red >= blue)
            {
                blue = 83;
            }
            else
            {
                red = 83;
            }
        }
        else if (blue >= red && blue >= green)
        {
            blue = 147;
            if (green >= red)
            {
                red = 83;
            }
            else
            {
                green = 83;
            }
        }

        red /= 255;
        green /= 255;
        blue /= 255;

        background.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
        constellationBackground.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
    }

    // Detects which zone the star is in
    void DetectDifficulty()
    {
        // Detects difficulty level based on location within constellation map
        if (GameManager.instance.star.transform.position.y > -3.5 && GameManager.instance.star.transform.position.y < 3.5 && GameManager.instance.star.transform.position.x > -3.5 && GameManager.instance.star.transform.position.x < 3.5)
        {
            GameManager.instance.zone = 1;
        }
        else if (GameManager.instance.star.transform.position.y > -6.5 && GameManager.instance.star.transform.position.y < 6.5 && GameManager.instance.star.transform.position.x > -6.5 && GameManager.instance.star.transform.position.x < 6.5)
        {
            GameManager.instance.zone = 2;
        }
        else if (GameManager.instance.star.transform.position.y > -9.5 && GameManager.instance.star.transform.position.y < 9.5 && GameManager.instance.star.transform.position.x > -9.5 && GameManager.instance.star.transform.position.x < 9.5)
        {
            GameManager.instance.zone = 3;
        }
        else if (GameManager.instance.star.transform.position.y > -12.5 && GameManager.instance.star.transform.position.y < 12.5 && GameManager.instance.star.transform.position.x > -12.5 && GameManager.instance.star.transform.position.x < 12.5)
        {
            GameManager.instance.zone = 4;
        }
        else if (GameManager.instance.star.transform.position.y > -15.5 && GameManager.instance.star.transform.position.y < 15.5 && GameManager.instance.star.transform.position.x > -15.5 && GameManager.instance.star.transform.position.x < 15.5)
        {
            GameManager.instance.zone = 5;
        }
        else if (GameManager.instance.star.transform.position.y > -18.5 && GameManager.instance.star.transform.position.y < 18.5 && GameManager.instance.star.transform.position.x > -18.5 && GameManager.instance.star.transform.position.x < 18.5)
        {
            GameManager.instance.zone = 6;
        }
        else if (GameManager.instance.star.transform.position.y > -21.5 && GameManager.instance.star.transform.position.y < 21.5 && GameManager.instance.star.transform.position.x > -21.5 && GameManager.instance.star.transform.position.x < 21.5)
        {
            GameManager.instance.zone = 7;
        }
        else if (GameManager.instance.star.transform.position.y > -24.5 && GameManager.instance.star.transform.position.y < 24.5 && GameManager.instance.star.transform.position.x > -24.5 && GameManager.instance.star.transform.position.x < 24.5)
        {
            GameManager.instance.zone = 8;
        }
        else if (GameManager.instance.star.transform.position.y > -27.5 && GameManager.instance.star.transform.position.y < 27.5 && GameManager.instance.star.transform.position.x > -27.5 && GameManager.instance.star.transform.position.x < 27.5)
        {
            GameManager.instance.zone = 9;
        }
        else if (GameManager.instance.star.transform.position.y > -30.5 && GameManager.instance.star.transform.position.y < 30.5 && GameManager.instance.star.transform.position.x > -30.5 && GameManager.instance.star.transform.position.x < 30.5)
        {
            GameManager.instance.zone = 10;
        }
        else if (GameManager.instance.star.transform.position.y > -31.0 && GameManager.instance.star.transform.position.y < 31.0 && GameManager.instance.star.transform.position.x > -31.0 && GameManager.instance.star.transform.position.x < 31.0)
        {
            GameManager.instance.destroyMeteors = true;
        }
        else
        {
            GameManager.instance.finishedUniverse = true;
;       }
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
        zoneChange.Play("Zone");
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
        zoneChange.Play("Zone");
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

    // Function for reseting the zone values on a universe reset
    public void ResetZones()
    {
        value = 0;
        minSpeedZone = 1;
        minSizeZone = 1;
        maxSpreadZone = 1;
    }
}