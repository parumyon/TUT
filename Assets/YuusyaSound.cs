using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuusyaSound : MonoBehaviour
{
    public AudioSource Encount_Sound;
    public AudioSource Escape_Sound;
    public AudioSource Damage_Sound;

    private yuusyaAI yuusya;

    private int Encount_Sound_Flag=0;//発見音の制御用
    
    // Start is called before the first frame update
    void Start()
    {
        yuusya = GetComponent<yuusyaAI>();
    }

    // Update is called once per frame
    void Update()
    {
        //逃げる時の音
        if (yuusya.hannnou == 0)
        {
            if (Escape_Sound.isPlaying == true)
            {
                Escape_Sound.Stop();
            }
        }
        else if (yuusya.hannnou == 2)
        {
            if (Escape_Sound.isPlaying == false)
            {
                Escape_Sound.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ダメージ音
        if (collision.gameObject.tag == "boss" || collision.gameObject.tag=="Hammer")
        {
            Damage_Sound.Play();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //発見音
        if (collision.gameObject.tag == "boss")
        {
            if (Encount_Sound_Flag == 0)
            {
                Encount_Sound.Play();
                Encount_Sound_Flag = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boss")
        {
            Encount_Sound_Flag = 0;
        }
    }
}
