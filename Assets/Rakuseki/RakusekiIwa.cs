using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakusekiIwa : MonoBehaviour
{
    public Rigidbody2D rb2;
    GameObject interactStatus;
    interact script;

    int OnOff = 0;
    public int mode = 0;
    public float IwaDamage = 20.0f;
    bool isCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.gravityScale = 0.0f;

        interactStatus = GameObject.Find("interactSwitch");
        script = interactStatus.GetComponent<interact>();

        mode = 0;
    }

    // Update is called once per frame

    void Update()
    {
        OnOff = script.Rakuseki;

        if (OnOff == 1 && !isCalled)
        {
            rb2.gravityScale = 1.0f;
            mode = 1;
            isCalled = true;

        }


    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" && (mode == 1 || mode == 2))
        {
            mode = 2;
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "boss")
        {
            mode = 2;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hammer" && mode == 2)
        {
            Destroy(this.gameObject);
        }
    }









}