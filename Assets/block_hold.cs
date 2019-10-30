using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_hold : MonoBehaviour
{
    public float BlockHold;
    private Startbutton startbutton;
    // Start is called before the first frame update
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        BlockHold = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        BlockHold = 1;
    }
    void OnMouseUp()
    {
        BlockHold = 0;
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
