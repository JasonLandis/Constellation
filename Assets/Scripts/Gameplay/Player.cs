using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (worldPosition.x > -4f && worldPosition.x < 4f && worldPosition.y < 4f && worldPosition.y > -4f)
        {
            transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        }

        else if (worldPosition.x < -4f && worldPosition.x < 4f && worldPosition.y < 4f && worldPosition.y > -4f)
        {
            transform.position = new Vector3(-4f, worldPosition.y, transform.position.z);
        }

        else if (worldPosition.x > -4f && worldPosition.x > 4f && worldPosition.y < 4f && worldPosition.y > -4f)
        {
            transform.position = new Vector3(4f, worldPosition.y, transform.position.z);
        }

        else if (worldPosition.x > -4f && worldPosition.x < 4f && worldPosition.y > 4f && worldPosition.y > -4f)
        {
            transform.position = new Vector3(worldPosition.x, 4f, transform.position.z);
        }

        else if (worldPosition.x > -4f && worldPosition.x < 4f && worldPosition.y < 4f && worldPosition.y < -4f)
        {
            transform.position = new Vector3(worldPosition.x, -4f, transform.position.z);
        }
    }
}
