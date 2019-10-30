using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takasa : MonoBehaviour
{
    private jumpkanri2 jumping;
    private yuusyaAI moving;
    public float a;

    // Start is called before the first frame update
    void Start()
    {
       jumping = GameObject.Find("jamp").GetComponent<jumpkanri2>();
        moving = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" &&  moving.MOVE == 0)
        {
            Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

            Vector2 moveVector = Vector2.zero;
            moveVector.y = jumping.JumpPower * -10;
            rb2.AddForce(5 * (moveVector - rb2.velocity));
            a++;
            moving.MOVE = 1;
            moving.muki = 1;
        }
        else if (collision.gameObject.tag == "Ground" &&  moving.MOVE == 1)
        {
            Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

            Vector2 moveVector = Vector2.zero;
            moveVector.y = jumping.JumpPower * -10;
            rb2.AddForce(5 * (moveVector - rb2.velocity));
            moving.MOVE = 0;
            moving.muki = 1;
        }
        else if (collision.gameObject.tag == "Ground" &&  moving.MOVE == 2)
        {
            Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

            Vector2 moveVector = Vector2.zero;
            moveVector.y = jumping.JumpPower * -10;
            rb2.AddForce(5 * (moveVector - rb2.velocity));
            moving.MOVE = 1;
            moving.muki = 1;
        }
        else if (collision.gameObject.tag == "Ground" &&  moving.MOVE == 3)
        {
            Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

            Vector2 moveVector = Vector2.zero;
            moveVector.y = jumping.JumpPower * -10;
            rb2.AddForce(5 * (moveVector - rb2.velocity));
            moving.MOVE = 0;
            moving.muki = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" && moving.muki == 1)
        {
            moving.muki = 0;
        }
    }
}
