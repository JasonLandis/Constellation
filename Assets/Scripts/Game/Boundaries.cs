using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 bounds;
    private float objectWidth;
    private float yLimit;

    private float negBoundsx;
    private float posBoundsx;
    private float negBoundsy;
    private float posBoundsy;

    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        yLimit = bounds.x * 0.31695f;

        negBoundsx = bounds.x * -1 + objectWidth;
        posBoundsx = bounds.x - objectWidth;
        negBoundsy = bounds.y * -1 + objectWidth;
        posBoundsy = yLimit - objectWidth;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, negBoundsx, posBoundsx);
        viewPos.y = Mathf.Clamp(viewPos.y, negBoundsy, posBoundsy);
        transform.position = viewPos;
    }
}
