using UnityEngine;

public class StayInside : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.4f, 0.4f), 
            Mathf.Clamp(transform.position.y, -0.94f, 0.075f), transform.position.z);
    }
}
