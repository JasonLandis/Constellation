using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public GameObject front;
    public GameObject back;

    public void Info()
    {
        front.SetActive(false);
        back.SetActive(true);
    }

    public void Back()
    {
        back.SetActive(false);
        front.SetActive(true);
    }
}
