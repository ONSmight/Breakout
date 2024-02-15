using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


	private void Move()
	{
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, 0f);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

    }













}
























