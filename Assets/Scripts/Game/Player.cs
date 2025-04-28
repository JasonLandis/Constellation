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
        if (!GameManager.instance.isPlayerPaused)
        {
            if (Input.touchCount > 0)  // Mobile Touch
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
                        transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                        break;

                    case TouchPhase.Ended:
                        rb.linearVelocity = Vector2.zero;
                        break;
                }
            }
            else if (Input.GetMouseButtonDown(0))  // PC Mouse Start
            {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                deltaX = mousePosition.x - transform.position.x;
                deltaY = mousePosition.y - transform.position.y;
            }
            else if (Input.GetMouseButton(0))  // PC Mouse Drag
            {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
            }
            else if (Input.GetMouseButtonUp(0))  // PC Mouse Release
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}
