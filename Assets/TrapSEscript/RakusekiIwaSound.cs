using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakusekiIwaSound : MonoBehaviour
{
    public AudioClip SetSE;
    public AudioClip FallSE;
    public AudioClip BreakSE;
    private int ClickFlag = 0;
    private RakusekiIwa rakuseki;
    private AudioSource audio;
    private int OnceFlag = 0;

    private void Start()
    {
        rakuseki = GetComponent<RakusekiIwa>();
        audio = GetComponent<AudioSource>();
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

        if (rakuseki.mode == 1 && audio.isPlaying == false && OnceFlag == 0)
        {
            audio.PlayOneShot(FallSE);
            OnceFlag = 1;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" && (rakuseki.mode == 1 || rakuseki.mode == 2))
        {
            audio.Stop();
            AudioSource.PlayClipAtPoint(BreakSE, new Vector3(0, 0, -10));
        }

        if (col.gameObject.tag == "boss")
        {
            audio.Stop();
            AudioSource.PlayClipAtPoint(BreakSE, new Vector3(0, 0, -10));
        }
    }
}