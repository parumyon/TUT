using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setti : MonoBehaviour
{
    GameObject RakusekiIwa;
    RakusekiIwa RakusekiIwaScript;
    int IwaMode;

    // Start is called before the first frame update
    void Start()
    {
        RakusekiIwa = GameObject.Find("rakuseki_iwa");
        RakusekiIwaScript = RakusekiIwa.GetComponent<RakusekiIwa>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" )
        {
            IwaMode = 2;
        }

    }
}
