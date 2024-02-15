using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 force;
    Vector2 col;

    public float speed = 120;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
	}
	// Start is called before the first frame update
	void Start()
    {
        force.x = Random.Range(-1f, 1f);
        force.y = 1f;

        rb.AddForce(force * speed);
    }

    // Update is called once per frame
    void Update()
    {
         if (rb.velocity.x > 8)
         {
             rb.velocity = new Vector2(8, rb.velocity.y);
         }
         if (rb.velocity.x < -8)
         {
             rb.velocity = new Vector2(-8, rb.velocity.y);
         }
    }



   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (collision.collider.attachedRigidbody.velocity.x > 0)
            {
                col = rb.velocity;
                col.x = rb.velocity.x + collision.collider.attachedRigidbody.velocity.x / 3;
                rb.velocity = col;
            }
            else if (collision.collider.attachedRigidbody.velocity.x < 0)
            {
                col = rb.velocity;
                col.x = rb.velocity.x + collision.collider.attachedRigidbody.velocity.x / 3;
                rb.velocity = col;
            }
            
        }
    }*/
















}
