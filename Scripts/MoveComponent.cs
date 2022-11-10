using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private bool nWalltouched = false;
    [SerializeField]
    private bool sWalltouched = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NWall"))
        {
            nWalltouched = true;    
        }
        else if(collision.CompareTag("SWall"))
        {
            sWalltouched = true;
        }

    }

    void Move()
    {
        if (this.transform.position.x < 0 && Input.GetKey(KeyCode.W) && !nWalltouched && !Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y += speed;
            this.transform.position = position;
            sWalltouched = false;
        }
        if (this.transform.position.x < 0 && Input.GetKey(KeyCode.S) && !sWalltouched && !Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y -= speed;
            this.transform.position = position;
            nWalltouched = false;
        }

        if (this.transform.position.x > 0 && Input.GetKey(KeyCode.UpArrow) && !nWalltouched && !Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y += speed;
            this.transform.position = position;
            sWalltouched = false;
        }
        if (this.transform.position.x > 0 && Input.GetKey(KeyCode.DownArrow) && !sWalltouched && !Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y -= speed;
            this.transform.position = position;
            nWalltouched = false;
        }
    }
}
