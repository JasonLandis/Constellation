using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject screen6;

    public void SwapToTwo()
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
    }
    public void SwapToThree()
    {
        screen2.SetActive(false);
        screen3.SetActive(true);
    }
    public void SwapToFour()
    {
        screen3.SetActive(false);
        screen4.SetActive(true);
    }
    public void SwapToFive()
    {
        screen4.SetActive(false);
        screen5.SetActive(true);
    }
    public void SwapToSix()
    {
        screen5.SetActive(false);
        screen6.SetActive(true);
    }

    public void SwapBackToOne()
    {
        screen2.SetActive(false);
        screen1.SetActive(true);
    }
    public void SwapBackToTwo()
    {
        screen3.SetActive(false);
        screen2.SetActive(true);
    }
    public void SwapBackToThree()
    {
        screen4.SetActive(false);
        screen3.SetActive(true);
    }
    public void SwapBackToFour()
    {
        screen5.SetActive(false);
        screen4.SetActive(true);
    }
    public void SwapBackToFive()
    {
        screen6.SetActive(false);
        screen5.SetActive(true);
    }
    public void Ok()
    {
        screen6.SetActive(false);
        screen5.SetActive(false);
        screen4.SetActive(false);
        screen3.SetActive(false);
        screen2.SetActive(false);
        screen1.SetActive(true);
        gameObject.SetActive(false);
    }
}
