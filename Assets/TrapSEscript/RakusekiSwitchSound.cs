using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakusekiSwitchSound : MonoBehaviour
{
    public AudioClip SetSE;
    public AudioClip UseSE;
    private int ClickFlag = 0;
    private int OnceFlag = 0;

    private void Start()
    {

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player"&&OnceFlag==0)
        {
            AudioSource.PlayClipAtPoint(UseSE, new Vector3(0, 0, -10));
            OnceFlag = 1;
        }
    }
}
