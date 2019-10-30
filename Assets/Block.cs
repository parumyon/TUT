using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Startbutton startbutton;
    private block_hold holding;

    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        holding = GetComponentInParent<block_hold>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(holding.BlockHold == 1)
        {
            box.enabled = false;
        }
        else if(holding.BlockHold == 0)
        {
            box.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (startbutton.GameStart == true)
        {
            if (collision.tag == "Hammer")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
