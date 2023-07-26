using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCamera;
    private float deltaX, deltaY;
    private Rigidbody2D rb;

    void Start()
    {
        mainCamera = GameManager.instance.mainCamera;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && !GameManager.instance.isGameOver)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPosition.x - transform.position.x;
                    deltaY = touchPosition.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    transform.position = new(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
}
