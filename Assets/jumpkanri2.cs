using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpkanri2 : MonoBehaviour
{

    public float JumpPower;
    public float Counter;
    public float RejumpTime;

    private bool ikkai;
   // public float Jump;

    private yuusyaAI jimen;
    // Start is called before the first frame update
    void Start()
    {
        jimen = GetComponentInParent<yuusyaAI>();
        ikkai = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jimen.jumphantei == 0 )
        {
            Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

            Vector2 moveVector = Vector2.zero;
            moveVector.y = JumpPower * 10;
            rb2.AddForce(5 * (moveVector - rb2.velocity));
            //Jump = 1;
            jimen.hannnou = 0;
            if (jimen.MOVE == 2)
            {
                jimen.MOVE = 0;
            }
            else if (jimen.MOVE == 3)
            {
                jimen.MOVE = 1;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jimen.jumphantei == 0)
        {
            Counter += Time.deltaTime;
            if (Counter >= RejumpTime && ikkai)
            {
                ikkai = false;

                Rigidbody2D rb2 = GetComponentInParent<Rigidbody2D>();

                Vector2 moveVector = Vector2.zero;
                moveVector.y = JumpPower * 10;
                rb2.AddForce(5 * (moveVector - rb2.velocity));
                //Jump = 1;
                jimen.hannnou = 0;
                if (jimen.MOVE == 2)
                {
                    jimen.MOVE = 0;
                }
                else if (jimen.MOVE == 3)
                {
                    jimen.MOVE = 1;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jimen.jumphantei == 1)
        {
            ikkai = true;
            Counter = 0;
        }
    }
}