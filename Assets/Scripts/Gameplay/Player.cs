using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Customizable")]
    [SerializeField] private float speed;
    public BoxCollider2D boxCollider2D;

    private void MoveUp()
    {
        if (transform.position.y < 4f)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }
    private void MoveDown()
    {
        if (transform.position.y > -4f)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
    }
    private void MoveLeft()
    {
        if (transform.position.x > -4f)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
    }
    private void MoveRight()
    {
        if (transform.position.x < 4f)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();        
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }        
    }
}
