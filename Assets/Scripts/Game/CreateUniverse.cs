using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateUniverse : MonoBehaviour
{
    [Header("Containers")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    [Header("Objects")]
    public GameObject universe1;
    public GameObject universe2;
    public GameObject universe3;

    [Header("Universe 1")]
    public TextMeshProUGUI sizeChangeText1;
    public TextMeshProUGUI spreadChangeText1;
    public TextMeshProUGUI speedChangeText1;
    public TextMeshProUGUI difficultyText1;
    public GameObject symbol1;
    private float sizeChange1;
    private float spreadChange1;
    private float speedChange1;
    private float[] color1;
    private string difficulty1;

    [Header("Universe 2")]
    public TextMeshProUGUI sizeChangeText2;
    public TextMeshProUGUI spreadChangeText2;
    public TextMeshProUGUI speedChangeText2;
    public TextMeshProUGUI difficultyText2;
    public GameObject symbol2;
    private float sizeChange2;
    private float spreadChange2;
    private float speedChange2;
    private float[] color2;
    private string difficulty2;

    [Header("Universe 3")]
    public TextMeshProUGUI sizeChangeText3;
    public TextMeshProUGUI spreadChangeText3;
    public TextMeshProUGUI speedChangeText3;
    public TextMeshProUGUI difficultyText3;
    public GameObject symbol3;
    private float sizeChange3;
    private float spreadChange3;
    private float speedChange3;
    private float[] color3;
    private string difficulty3;

    void Start()
    {
        GameManager.instance.createUniverseStats += CreateUniverseStats;
    }

    // Randomly generate stats for the next 3 possible universes
    public void CreateUniverseStats()
    {
        sizeChange1 = Random.Range(2, 7) / 10f;
        spreadChange1 = Random.Range(7, 15) / 10f;
        speedChange1 = Random.Range(13, 21) / 10f;
        if (sizeChange1 + spreadChange1 + speedChange1 < 3)
        {
            difficulty1 = "<color=#11DC58>Easy</color>";
        }

        else if (sizeChange1 + spreadChange1 + speedChange1 < 3.3)
        {
            difficulty1 = "<color=#E0E0E0>Normal</color>";
        }

        else
        {
            difficulty1 = "<color=#E54B4B>Hard</color>";
        }
        sizeChangeText1.text = "+ " + sizeChange1.ToString();
        spreadChangeText1.text = "- " + spreadChange1.ToString();
        speedChangeText1.text = "+ " + speedChange1.ToString();
        difficultyText1.text = difficulty1;
        color1 = GetColor();
        symbol1.GetComponent<Image>().color = new(color1[0], color1[1], color1[2], 1);
        Instantiate(universe1, item1.transform.position, Quaternion.identity, item1.transform);

        sizeChange2 = Random.Range(2, 7) / 10f;
        spreadChange2 = Random.Range(7, 15) / 10f;
        speedChange2 = Random.Range(13, 21) / 10f;
        if (sizeChange2 + spreadChange2 + speedChange2 < 3)
        {
            difficulty2 = "<color=#11DC58>Easy</color>";
        }

        else if (sizeChange2 + spreadChange2 + speedChange2 < 3.3)
        {
            difficulty2 = "<color=#E0E0E0>Normal</color>";
        }

        else
        {
            difficulty2 = "<color=#E54B4B>Hard</color>";
        }
        sizeChangeText2.text = "+ " + sizeChange2.ToString();
        spreadChangeText2.text = "- " + spreadChange2.ToString();
        speedChangeText2.text = "+ " + speedChange2.ToString();
        difficultyText2.text = difficulty2;
        color2 = GetColor();
        symbol2.GetComponent<Image>().color = new(color2[0], color2[1], color2[2], 1);
        Instantiate(universe2, item2.transform.position, Quaternion.identity, item2.transform);

        sizeChange3 = Random.Range(2, 7) / 10f;
        spreadChange3 = Random.Range(7, 15) / 10f;
        speedChange3 = Random.Range(13, 21) / 10f;
        if (sizeChange3 + spreadChange3 + speedChange3 < 3)
        {
            difficulty3 = "<color=#11DC58>Easy</color>";
        }

        else if (sizeChange3 + spreadChange3 + speedChange3 < 3.3)
        {
            difficulty3 = "<color=#E0E0E0>Normal</color>";
        }

        else
        {
            difficulty3 = "<color=#E54B4B>Hard</color>";
        }
        sizeChangeText3.text = "+ " + sizeChange3.ToString();
        spreadChangeText3.text = "- " + spreadChange3.ToString();
        speedChangeText3.text = "+ " + speedChange3.ToString();
        difficultyText3.text = difficulty3;
        color3 = GetColor();
        symbol3.GetComponent<Image>().color = new(color3[0], color3[1], color3[2], 1);
        Instantiate(universe3, item3.transform.position, Quaternion.identity, item3.transform);
    }

    // Returns the rgb values of a randomly generated color
    public float[] GetColor()
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

        return new float[] { red, green, blue };
    }

    // Button functions for the 3 universes
    public void UniverseOne()
    {
        PlayerPrefs.SetFloat("Size Change", sizeChange1);
        PlayerPrefs.SetFloat("Spread Change", spreadChange1);
        PlayerPrefs.SetFloat("Speed Change", speedChange1);
        PlayerPrefs.SetString("Difficulty", difficulty1);
        PlayerPrefs.SetFloat("Red", color1[0]);
        PlayerPrefs.SetFloat("Green", color1[1]);
        PlayerPrefs.SetFloat("Blue", color1[2]);
        GameManager.instance.resetUniverse = true;
    }
    public void UniverseTwo()
    {
        PlayerPrefs.SetFloat("Size Change", sizeChange2);
        PlayerPrefs.SetFloat("Spread Change", spreadChange2);
        PlayerPrefs.SetFloat("Speed Change", speedChange2);
        PlayerPrefs.SetString("Difficulty", difficulty2);
        PlayerPrefs.SetFloat("Red", color2[0]);
        PlayerPrefs.SetFloat("Green", color2[1]);
        PlayerPrefs.SetFloat("Blue", color2[2]);
        GameManager.instance.resetUniverse = true;
    }
    public void UniverseThree()
    {
        PlayerPrefs.SetFloat("Size Change", sizeChange3);
        PlayerPrefs.SetFloat("Spread Change", spreadChange3);
        PlayerPrefs.SetFloat("Speed Change", speedChange3);
        PlayerPrefs.SetString("Difficulty", difficulty3);
        PlayerPrefs.SetFloat("Red", color3[0]);
        PlayerPrefs.SetFloat("Green", color3[1]);
        PlayerPrefs.SetFloat("Blue", color3[2]);
        GameManager.instance.resetUniverse = true;
    }
}
