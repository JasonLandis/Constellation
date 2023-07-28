using UnityEngine;

public class ThreeCycleUI : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;

    public void SwapToOne()
    {
        three.SetActive(false);
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
}
