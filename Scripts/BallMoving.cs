using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{

    Rigidbody2D rb;


    [SerializeField]
    public float speed = 0.1f;

    Vector2 direction;

    [SerializeField]
    private bool wallbounced = false;
    [SerializeField]
    private bool barbounced = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;    }

    private void FixedUpdate()
    {
        ballBounce();
        rb.velocity = direction * speed;
    }

    void ballBounce()
    {
        if(wallbounced)
        {
            direction.y = -direction.y;
            wallbounced = false;
        }
        else if(barbounced)
        {
            direction.x = -direction.x;
            barbounced = false;
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) barbounced = true;

        if(collision.CompareTag("NWall") || collision.CompareTag ("SWall")) wallbounced = true;
    }

}
