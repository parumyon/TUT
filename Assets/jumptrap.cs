using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptrap : MonoBehaviour
{
    Rigidbody2D rig2;
    public float JumpPower;
    private Startbutton startbutton;
    private SNAP holding;

    

    // Start is called before the first frame update
    void Start()
    {
        rig2 = GameObject.Find("yuusya").GetComponent<Rigidbody2D>();
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        holding = GetComponentInParent<SNAP>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (holding.Snapping == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (other.gameObject.tag == "player")
                {
                    Vector2 moveVector = Vector2.zero;
                    moveVector.y = JumpPower * 10;
                    rig2.AddForce(5 * (moveVector - rig2.velocity));
                }
            }
        }
       
    }

    
}
