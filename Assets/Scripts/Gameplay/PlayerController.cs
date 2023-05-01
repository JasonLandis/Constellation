using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if w is pressed move up
        if (Input.GetKey(KeyCode.W))
        {
            // if the player is not touching the top of the screen
            if (transform.position.y < 4.6f)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.up);
            }          
        }

        // if s is pressed move down
        if (Input.GetKey(KeyCode.S))
        {
            // if the player is not touching the bottom of the screen
            if (transform.position.y > -4.5f)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.down);
            }
        }

        // if a is pressed move left

        if (Input.GetKey(KeyCode.A))
        {
            // if the player is not touching the left of the screen
            if (transform.position.x > -9.05f)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.left);
            }
        }

        // if d is pressed move right

        if (Input.GetKey(KeyCode.D))
        {
            // if the player is not touching the right of the screen
            if (transform.position.x < 9.05f)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.right);
            }
        }        
    }
}
