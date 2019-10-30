using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_otori : MonoBehaviour
{
    private Startbutton startbutton;
    private float holding;
    // Start is called before the first frame update
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        holding = 1;
    }
    private void OnMouseUp()
    {
        holding = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
