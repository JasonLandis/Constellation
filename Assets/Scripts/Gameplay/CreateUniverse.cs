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
    public GameObject symbol1;
    private float sizeChange1;
    private float spreadChange1;
    private float speedChange1;
    private float red1;
    private float green1;
    private float blue1;

    [Header("Universe 2")]
    public TextMeshProUGUI sizeChangeText2;
    public TextMeshProUGUI spreadChangeText2;
    public TextMeshProUGUI speedChangeText2;
    public GameObject symbol2;
    private float sizeChange2;
    private float spreadChange2;
    private float speedChange2;
    private float red2;
    private float green2;
    private float blue2;

    [Header("Universe 3")]
    public TextMeshProUGUI sizeChangeText3;
    public TextMeshProUGUI spreadChangeText3;
    public TextMeshProUGUI speedChangeText3;
    public GameObject symbol3;
    private float sizeChange3;
    private float spreadChange3;
    private float speedChange3;
    private float red3;
    private float green3;
    private float blue3;

    [Header("Backgrounds")]
    public GameObject background;
    public GameObject constellationBackground;

    private void Start()
    {
        GameManager.instance.createUniverseStats += CreateUniverseStats;
    }

    // Resets the zones colors based on the universe selected by the player
    public void CreateZones(float red, float green, float blue)
    {
        background.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
        constellationBackground.GetComponent<SpriteRenderer>().color = new(red, green, blue, 1);
    }

    // Randomly generate stats for the next 3 possible universes
    public void CreateUniverseStats()
    {
        sizeChange1 = Random.Range(2, 6) / 10f;
        spreadChange1 = Random.Range(3, 8) / 10f;
        speedChange1 = Random.Range(7, 13) / 10f;
        sizeChangeText1.text = "+ " + sizeChange1.ToString();
        spreadChangeText1.text = "- " + spreadChange1.ToString();
        speedChangeText1.text = "+ " + speedChange1.ToString();
        red1 = GetColor()[0];
        green1 = GetColor()[1];
        blue1 = GetColor()[2];
        symbol1.GetComponent<Image>().color = new(red1, green1, blue1, 1);
        Instantiate(universe1, item1.transform.position, Quaternion.identity, item1.transform);

        sizeChange2 = Random.Range(2, 6) / 10f;
        spreadChange2 = Random.Range(3, 8) / 10f;
        speedChange2 = Random.Range(7, 13) / 10f;
        sizeChangeText2.text = "+ " + sizeChange2.ToString();
        spreadChangeText2.text = "- " + spreadChange2.ToString();
        speedChangeText2.text = "+ " + speedChange2.ToString();
        red2 = GetColor()[0];
        green2 = GetColor()[1];
        blue2 = GetColor()[2];
        symbol2.GetComponent<Image>().color = new(red2, green2, blue2, 1);
        Instantiate(universe2, item2.transform.position, Quaternion.identity, item2.transform);

        sizeChange3 = Random.Range(2, 6) / 10f;
        spreadChange3 = Random.Range(3, 8) / 10f;
        speedChange3 = Random.Range(7, 13) / 10f;
        sizeChangeText3.text = "+ " + sizeChange3.ToString();
        spreadChangeText3.text = "- " + spreadChange3.ToString();
        speedChangeText3.text = "+ " + speedChange3.ToString();
        red3 = GetColor()[0];
        green3 = GetColor()[1];
        blue3 = GetColor()[2];
        symbol3.GetComponent<Image>().color = new(red3, green3, blue3, 1);
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
        GameManager.instance.sizeChange = sizeChange1;
        GameManager.instance.spreadChange = spreadChange1;
        GameManager.instance.speedChange = speedChange1;
        CreateZones(red1, green1, blue1);
        GameManager.instance.resetUniverse = true;
    }
    public void UniverseTwo()
    {
        GameManager.instance.sizeChange = sizeChange2;
        GameManager.instance.spreadChange = spreadChange2;
        GameManager.instance.speedChange = speedChange2;
        CreateZones(red2, green2, blue2);
        GameManager.instance.resetUniverse = true;
    }
    public void UniverseThree()
    {
        GameManager.instance.sizeChange = sizeChange3;
        GameManager.instance.spreadChange = spreadChange3;
        GameManager.instance.speedChange = speedChange3;
        CreateZones(red3, green3, blue3);
        GameManager.instance.resetUniverse = true;
    }
}
