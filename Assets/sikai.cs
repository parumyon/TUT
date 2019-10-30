using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sikai : MonoBehaviour
{
    private yuusyaAI moving;
    // Start is called before the first frame update
    void Start()
    {
        moving = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="boss"&&moving.MOVE == 0 /*&& moving.jumphantei == 0*/)
        {
            moving.MOVE = 2;
            moving.hannnou = 1;
        }
        else if(collision.gameObject.tag == "boss" && moving.MOVE == 1 /*&& moving.jumphantei == 0*/)
        {
            moving.MOVE = 3;
            moving.hannnou = 1;
        }
    }
}
