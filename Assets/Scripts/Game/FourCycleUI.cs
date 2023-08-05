using UnityEngine;

public class FourCycleUI : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;

    public void SwapToOne()
    {
        four.SetActive(false);
        one.SetActive(true);
    }
    public void SwapToTwo()
    {
        one.SetActive(false);
        two.SetActive(true);
    }
    public void SwapToThree()
    {
        two.SetActive(false);
        three.SetActive(true);
    }
    public void SwapToFour()
    {
        three.SetActive(false);
        four.SetActive(true);
    }
}