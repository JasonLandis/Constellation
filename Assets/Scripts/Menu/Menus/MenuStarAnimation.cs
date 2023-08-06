using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuStarAnimation : MonoBehaviour
{
    public GameObject menuStar;
    public Light2D menuStarLight;

    public GameObject motion1;
    public GameObject motion2;
    public GameObject motion3;
    public GameObject motion4;
    public GameObject motion5;
    public GameObject motion6;

    private Vector3 end1;
    private Vector3 end2;
    private Vector3 end3;
    private Vector3 end4;
    private Vector3 end5;
    private Vector3 end6;

    private float speed1;
    private float speed2;
    private float speed3;
    private float speed4;
    private float speed5;
    private float speed6;

    public List<GameObject> left;
    public List<GameObject> right;

    private Vector2 bounds;

    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SetPositions();

        CreateStar(motion1);
        CreateStar(motion2);
        CreateStar(motion3);
        CreateStar(motion4);
        CreateStar(motion5);
        CreateStar(motion6);

        end1 = right[Random.Range(0, 11)].transform.position;
        end2 = right[Random.Range(0, 11)].transform.position;
        end3 = right[Random.Range(0, 11)].transform.position;
        end4 = left[Random.Range(0, 11)].transform.position;
        end5 = left[Random.Range(0, 11)].transform.position;
        end6 = left[Random.Range(0, 11)].transform.position;

        speed1 = Random.Range(4, 10) / 500f;
        speed2 = Random.Range(4, 10) / 500f;
        speed3 = Random.Range(4, 10) / 500f;
        speed4 = Random.Range(4, 10) / 500f;
        speed5 = Random.Range(4, 10) / 500f;
        speed6 = Random.Range(4, 10) / 500f;
    }

    // Update is called once per frame
    void Update()
    {
        motion1.transform.position = Vector3.MoveTowards(motion1.transform.position, end1, speed1);
        if (motion1.transform.position == end1)
        {
            ChangeStar(motion1.transform.GetChild(0).gameObject);
            end1 = ChooseEndPoint(motion1);
            speed1 = Random.Range(4, 10) / 500f;
        }

        motion2.transform.position = Vector3.MoveTowards(motion2.transform.position, end2, speed2);
        if (motion2.transform.position == end2)
        {
            ChangeStar(motion2.transform.GetChild(0).gameObject);
            end2 = ChooseEndPoint(motion2);
            speed2 = Random.Range(4, 10) / 500f;
        }

        motion3.transform.position = Vector3.MoveTowards(motion3.transform.position, end3, speed3);
        if (motion3.transform.position == end3)
        {
            ChangeStar(motion3.transform.GetChild(0).gameObject);
            end3 = ChooseEndPoint(motion3);
            speed3 = Random.Range(4, 10) / 500f;
        }

        motion4.transform.position = Vector3.MoveTowards(motion4.transform.position, end4, speed4);
        if (motion4.transform.position == end4)
        {
            ChangeStar(motion4.transform.GetChild(0).gameObject);
            end4 = ChooseEndPoint(motion4);
            speed4 = Random.Range(4, 10) / 500f;
        }

        motion5.transform.position = Vector3.MoveTowards(motion5.transform.position, end5, speed5);
        if (motion5.transform.position == end5)
        {
            ChangeStar(motion5.transform.GetChild(0).gameObject);
            end5 = ChooseEndPoint(motion5);
            speed5 = Random.Range(4, 10) / 500f;
        }

        motion6.transform.position = Vector3.MoveTowards(motion6.transform.position, end6, speed6);
        if (motion6.transform.position == end6)
        {
            ChangeStar(motion6.transform.GetChild(0).gameObject);
            end6 = ChooseEndPoint(motion6);
            speed6 = Random.Range(4, 10) / 500f;
        }
    }

    private void SetPositions()
    {
        motion1.transform.position = new(bounds.x * -1 - 1, motion1.transform.position.y, 0);
        motion2.transform.position = new(bounds.x * -1 - 1, motion2.transform.position.y, 0);
        motion3.transform.position = new(bounds.x * -1 - 1, motion3.transform.position.y, 0);
        motion4.transform.position = new(bounds.x + 1, motion4.transform.position.y, 0);
        motion5.transform.position = new(bounds.x + 1, motion5.transform.position.y, 0);
        motion6.transform.position = new(bounds.x + 1, motion6.transform.position.y, 0);

        foreach (GameObject l in left)
        {
            l.transform.position = new(bounds.x * -1 - 1, l.transform.position.y, 0);
        }

        foreach (GameObject r in right)
        {
            r.transform.position = new(bounds.x + 1, r.transform.position.y, 0);
        }
    }

    private Vector3 ChooseEndPoint(GameObject motion)
    {
        if (motion.transform.position.x > 0)
        {
            return left[Random.Range(0, 11)].transform.position;
        }

        else
        {
            return right[Random.Range(0, 11)].transform.position;
        }
    }

    private void ChangeStar(GameObject star)
    {
        float scale = Random.Range(4, 11) / 10f;
        star.transform.localScale = new(scale, scale, scale);

        float red = Random.Range(0, 255);
        float green = Random.Range(0, 255);
        float blue = Random.Range(0, 255);

        if (red >= green && red >= blue)
        {
            red = 255;
            if (green >= blue)
            {
                blue = 0;
            }
            else
            {
                green = 0;
            }
        }
        else if (green >= red && green >= blue)
        {
            green = 255;
            if (red >= blue)
            {
                blue = 0;
            }
            else
            {
                red = 0;
            }
        }
        else if (blue >= red && blue >= green)
        {
            blue = 255;
            if (green >= red)
            {
                red = 0;
            }
            else
            {
                green = 0;
            }
        }

        red /= 255;
        green /= 255;
        blue /= 255;

        star.GetComponent<Light2D>().color = new(red, green, blue, 1);
    }

    private void CreateStar(GameObject motion)
    {
        float scale = Random.Range(4, 11) / 10f;
        menuStar.transform.localScale = new(scale, scale, scale);

        float red = Random.Range(0, 255);
        float green = Random.Range(0, 255);
        float blue = Random.Range(0, 255);

        if (red >= green && red >= blue)
        {
            red = 255;
            if (green >= blue)
            {
                blue = 0;
            }
            else
            {
                green = 0;
            }
        }
        else if (green >= red && green >= blue)
        {
            green = 255;
            if (red >= blue)
            {
                blue = 0;
            }
            else
            {
                red = 0;
            }
        }
        else if (blue >= red && blue >= green)
        {
            blue = 255;
            if (green >= red)
            {
                red = 0;
            }
            else
            {
                green = 0;
            }
        }

        red /= 255;
        green /= 255;
        blue /= 255;

        menuStarLight.color = new(red, green, blue, 1);
        
        Instantiate(menuStar, motion.transform.position, Quaternion.identity, motion.transform);
    }
}
