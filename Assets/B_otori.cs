using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_otori : MonoBehaviour
{
    public float hit;
    // Start is called before the first frame update
    private Startbutton startbutton;
    private float holding;
    private EnemyAI enemyAI;
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        enemyAI = GameObject.Find("boss").GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hit == 5)
        {
            enemyAI.EnemySpeedtyousei = 1;
            Destroy(this.gameObject);
        }
    }
    private void OnMouseDrag()
    {
        holding = 1;
    }
    private void OnMouseUp()
    {
        holding = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "boss")
                {
                    enemyAI.EnemySpeedtyousei = 0.0001f;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "Hammer")
                {
                    hit++;
                }
            }
        }
    }
}
