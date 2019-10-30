using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iwa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            default:
            case "Ground":
                Destroy(this.gameObject);
                break;
            case "player":
                Destroy(this.gameObject);
                break;
            case "boss":
                Destroy(this.gameObject);
                break;
                //return;
        }
    }
}
