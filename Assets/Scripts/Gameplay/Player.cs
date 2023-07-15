using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x > -1 && touchPosition.x < 1 && touchPosition.y > -1.4 && touchPosition.y < 0.1)
            {
                touchPosition.z = 0f;
                transform.position = touchPosition;
            }
        }
    }
}
