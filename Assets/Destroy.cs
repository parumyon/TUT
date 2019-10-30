using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Startbutton startbutton;
    // Start is called before the first frame update

    public float b;
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (startbutton.GameStart == true)
        {
            if (collision.gameObject.tag == "boss")
            {
                b++;
                Destroy(this.gameObject);
            }
        }
    }
}
