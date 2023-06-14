using TMPro;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [Header("Zones")]
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
    public GameObject zone11;
    public GameObject zone12;
    public GameObject zone13;
    public GameObject zone14;
    public GameObject zone15;
    public GameObject zone16;
    public GameObject zone17;
    public GameObject zone18;
    public GameObject zone19;
    public GameObject zone20;

    [Header("Text")]
    public TextMeshProUGUI zoneText;

    private int zone = 1; // Zone the star is in
    private int value = 0; // Used for the previous zone the star was in
    private int minSpeedZone = 1; // Used for the highest zone at which speed should not decrease
    private int minSizeZone = 1; // Used for the highest zone at which size should not decrease
    private int maxDistanceZone = 1; // Used for the highest zone at which the distance should not increase

    void Start()
    {
        GameManager.instance.zoneDetection += DetectDifficulty;
        GameManager.instance.zoneDetection += SetDifficulty;
    }

    // Detects which zone the star is in
    void DetectDifficulty()
    {
        // Detects difficulty level based on location within constellation map
        if (GameManager.instance.star.transform.position.y > -55 && GameManager.instance.star.transform.position.y < 55 && GameManager.instance.star.transform.position.x > -55 && GameManager.instance.star.transform.position.x < 55)
        {
            zone = 1;
        }
        else if (GameManager.instance.star.transform.position.y > -105 && GameManager.instance.star.transform.position.y < 105 && GameManager.instance.star.transform.position.x > -105 && GameManager.instance.star.transform.position.x < 105)
        {
            zone = 2;
        }
        else if (GameManager.instance.star.transform.position.y > -155 && GameManager.instance.star.transform.position.y < 155 && GameManager.instance.star.transform.position.x > -155 && GameManager.instance.star.transform.position.x < 155)
        {
            zone = 3;
        }
        else if (GameManager.instance.star.transform.position.y > -205 && GameManager.instance.star.transform.position.y < 205 && GameManager.instance.star.transform.position.x > -205 && GameManager.instance.star.transform.position.x < 205)
        {
            zone = 4;
        }
        else if (GameManager.instance.star.transform.position.y > -255 && GameManager.instance.star.transform.position.y < 255 && GameManager.instance.star.transform.position.x > -255 && GameManager.instance.star.transform.position.x < 255)
        {
            zone = 5;
        }
        else if (GameManager.instance.star.transform.position.y > -305 && GameManager.instance.star.transform.position.y < 305 && GameManager.instance.star.transform.position.x > -305 && GameManager.instance.star.transform.position.x < 305)
        {
            zone = 6;
        }
        else if (GameManager.instance.star.transform.position.y > -355 && GameManager.instance.star.transform.position.y < 355 && GameManager.instance.star.transform.position.x > -355 && GameManager.instance.star.transform.position.x < 355)
        {
            zone = 7;
        }
        else if (GameManager.instance.star.transform.position.y > -405 && GameManager.instance.star.transform.position.y < 405 && GameManager.instance.star.transform.position.x > -405 && GameManager.instance.star.transform.position.x < 405)
        {
            zone = 8;
        }
        else if (GameManager.instance.star.transform.position.y > -455 && GameManager.instance.star.transform.position.y < 455 && GameManager.instance.star.transform.position.x > -455 && GameManager.instance.star.transform.position.x < 455)
        {
            zone = 9;
        }
        else if (GameManager.instance.star.transform.position.y > -505 && GameManager.instance.star.transform.position.y < 505 && GameManager.instance.star.transform.position.x > -505 && GameManager.instance.star.transform.position.x < 505)
        {
            zone = 10;
        }
        else if (GameManager.instance.star.transform.position.y > -555 && GameManager.instance.star.transform.position.y < 555 && GameManager.instance.star.transform.position.x > -555 && GameManager.instance.star.transform.position.x < 555)
        {
            zone = 11;
        }
        else if (GameManager.instance.star.transform.position.y > -605 && GameManager.instance.star.transform.position.y < 605 && GameManager.instance.star.transform.position.x > -605 && GameManager.instance.star.transform.position.x < 605)
        {
            zone = 12;
        }
        else if (GameManager.instance.star.transform.position.y > -655 && GameManager.instance.star.transform.position.y < 655 && GameManager.instance.star.transform.position.x > -655 && GameManager.instance.star.transform.position.x < 655)
        {
            zone = 13;
        }
        else if (GameManager.instance.star.transform.position.y > -705 && GameManager.instance.star.transform.position.y < 705 && GameManager.instance.star.transform.position.x > -705 && GameManager.instance.star.transform.position.x < 705)
        {
            zone = 14;
        }
        else if (GameManager.instance.star.transform.position.y > -755 && GameManager.instance.star.transform.position.y < 755 && GameManager.instance.star.transform.position.x > -755 && GameManager.instance.star.transform.position.x < 755)
        {
            zone = 15;
        }
        else if (GameManager.instance.star.transform.position.y > -805 && GameManager.instance.star.transform.position.y < 805 && GameManager.instance.star.transform.position.x > -805 && GameManager.instance.star.transform.position.x < 805)
        {
            zone = 16;
        }
        else if (GameManager.instance.star.transform.position.y > -855 && GameManager.instance.star.transform.position.y < 855 && GameManager.instance.star.transform.position.x > -855 && GameManager.instance.star.transform.position.x < 855)
        {
            zone = 17;
        }
        else if (GameManager.instance.star.transform.position.y > -905 && GameManager.instance.star.transform.position.y < 905 && GameManager.instance.star.transform.position.x > -905 && GameManager.instance.star.transform.position.x < 905)
        {
            zone = 18;
        }
        else if (GameManager.instance.star.transform.position.y > -955 && GameManager.instance.star.transform.position.y < 955 && GameManager.instance.star.transform.position.x > -955 && GameManager.instance.star.transform.position.x < 955)
        {
            zone = 19;
        }
        else
        {
            zone = 20;
        }
    }

    // Sets the difficulty depending on the zone
    void SetDifficulty()
    {
        // Set difficulty levels
        switch (zone)
        {
            case 1:
                if (value > 1)
                {
                    zone3.SetActive(false);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 1;
                break;
            case 2:
                if (value > 2)
                {
                    zone4.SetActive(false);
                    zone1.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 2)
                {
                    zone3.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 2;
                break;
            case 3:
                if (value > 3)
                {
                    zone5.SetActive(false);
                    zone2.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 3)
                {
                    zone1.SetActive(false);
                    zone4.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 3;
                break;
            case 4:
                if (value > 4)
                {
                    zone6.SetActive(false);
                    zone3.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 4)
                {
                    zone2.SetActive(false);
                    zone5.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 4;
                break;
            case 5:
                if (value > 5)
                {
                    zone7.SetActive(false);
                    zone4.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 5)
                {
                    zone3.SetActive(false);
                    zone6.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 5;
                break;
            case 6:
                if (value > 6)
                {
                    zone8.SetActive(false);
                    zone5.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 6)
                {
                    zone4.SetActive(false);
                    zone7.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 6;
                break;
            case 7:
                if (value > 7)
                {
                    zone9.SetActive(false);
                    zone6.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 7)
                {
                    zone5.SetActive(false);
                    zone8.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 7;
                break;
            case 8:
                if (value > 8)
                {
                    zone10.SetActive(false);
                    zone7.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 8)
                {
                    zone6.SetActive(false);
                    zone9.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 8;
                break;
            case 9:
                if (value > 9)
                {
                    zone11.SetActive(false);
                    zone8.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 9)
                {
                    zone7.SetActive(false);
                    zone10.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 9;
                break;
            case 10:
                if (value > 10)
                {
                    zone12.SetActive(false);
                    zone9.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 10)
                {
                    zone8.SetActive(false);
                    zone11.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 10;
                break;
            case 11:
                if (value > 11)
                {
                    zone13.SetActive(false);
                    zone10.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 11)
                {
                    zone9.SetActive(false);
                    zone12.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 11;
                break;
            case 12:
                if (value > 12)
                {
                    zone14.SetActive(false);
                    zone11.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 12)
                {
                    zone10.SetActive(false);
                    zone13.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 12;
                break;
            case 13:
                if (value > 13)
                {
                    zone15.SetActive(false);
                    zone12.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 13)
                {
                    zone11.SetActive(false);
                    zone14.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 13;
                break;
            case 14:
                if (value > 14)
                {
                    zone16.SetActive(false);
                    zone13.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 14)
                {
                    zone12.SetActive(false);
                    zone15.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 14;
                break;
            case 15:
                if (value > 15)
                {
                    zone17.SetActive(false);
                    zone14.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 15)
                {
                    zone13.SetActive(false);
                    zone16.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 15;
                break;
            case 16:
                if (value > 16)
                {
                    zone18.SetActive(false);
                    zone15.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 16)
                {
                    zone14.SetActive(false);
                    zone17.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 16;
                break;
            case 17:
                if (value > 17)
                {
                    zone19.SetActive(false);
                    zone16.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 17)
                {
                    zone15.SetActive(false);
                    zone18.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 17;
                break;
            case 18:
                if (value > 18)
                {
                    zone20.SetActive(false);
                    zone17.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 18)
                {
                    zone16.SetActive(false);
                    zone19.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 18;
                break;
            case 19:
                if (value > 19)
                {
                    zone18.SetActive(true);
                    DecreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                else if (value < 19)
                {
                    zone17.SetActive(false);
                    zone20.SetActive(true);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 19;
                break;
            case 20:
                if (value < 20)
                {
                    zone18.SetActive(false);
                    IncreaseZone();
                    GameManager.instance.GenerateNewMap(GameManager.instance.directionVector);
                }
                value = 20;
                break;
        }

        zoneText.text = zone.ToString();
    }

    // Decreases the speed, distance, and size when moving to a lower zone
    void DecreaseZone()
    {
        if (GameManager.instance.speed > 1)
        {
            GameManager.instance.speed -= 1;
            if (GameManager.instance.speed < 1)
            {
                GameManager.instance.speed = 1;
            }
        }
        else
        {
            if (zone >= minSpeedZone)
            {
                minSpeedZone = zone + 1;
            }
        }
        if (GameManager.instance.distance < 10)
        {
            GameManager.instance.distance += 0.4f;
            if (GameManager.instance.distance > 10)
            {
                GameManager.instance.distance = 10;
            }
        }
        else
        {
            if (zone >= maxDistanceZone)
            {
                maxDistanceZone = zone + 1;
            }
        }
        if (GameManager.instance.size > 0.125f)
        {
            GameManager.instance.size -= 0.25f;
            if (GameManager.instance.size < 0)
            {
                GameManager.instance.size = 0.25f;
            }
        }
        else
        {
            if (zone >= minSizeZone)
            {
                minSizeZone = zone + 1;
            }
        }
    }

    // Increases the speed, distance, and size when moving to a higher zone
    void IncreaseZone()
    {
        if (minSpeedZone < zone)
        {
            GameManager.instance.speed += 1;
        }
        if (GameManager.instance.distance > 0 && maxDistanceZone < zone)
        {
            GameManager.instance.distance -= 0.4f;
        }
        if (minSizeZone < zone)
        {
            GameManager.instance.size += 0.25f;
        }
    }
}
