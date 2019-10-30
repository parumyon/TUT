using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogeYukaSound : MonoBehaviour
{
    public AudioClip SetSE;
    public AudioClip UseSE;
    private int ClickFlag = 0;

    private Startbutton startbutton;
    private float holding;

    private void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
    }

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
    private void OnMouseDrag()
    {
        holding = 1;
    }
    private void OnMouseUp()
    {
        holding = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    AudioSource.PlayClipAtPoint(UseSE, new Vector3(0, 0, -10));
                }
                else if (collision.gameObject.tag == "boss")
                {
                    AudioSource.PlayClipAtPoint(UseSE, new Vector3(0, 0, -10));
                }
            }
        }
    }
}
