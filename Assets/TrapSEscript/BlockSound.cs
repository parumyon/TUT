using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSound : MonoBehaviour
{
    public AudioClip SetSE;
    public AudioClip BreakSE;
    private int ClickFlag=0;

    void Update()
    {
        var mPos = Input.mousePosition;
        var wPos = Camera.main.ScreenToWorldPoint(mPos);
        if (Input.GetMouseButtonDown(0))
        {
            if (((wPos.x <= transform.position.x + 0.5) && (wPos.x >= transform.position.x - 0.5)) &&
                ((wPos.y <= transform.position.y + 0.5) && (wPos.y >= transform.position.y - 0.5)))
            {
                ClickFlag = 1;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (ClickFlag == 1)
            {
                AudioSource.PlayClipAtPoint(SetSE, new Vector3(0, 0, -10));
                ClickFlag = 0;
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hammer")
        {
            AudioSource.PlayClipAtPoint(BreakSE, new Vector3(0, 0, -10));
        }
    }
}
