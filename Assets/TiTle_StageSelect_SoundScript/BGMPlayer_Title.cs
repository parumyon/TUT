using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer_Title : MonoBehaviour
{
    public AudioSource title_intro;
    public AudioSource title_loop;
    // Start is called before the first frame update
    void Start()
    {
        //イントロ部分の再生開始
        title_intro.PlayScheduled(AudioSettings.dspTime);

        //イントロ終了後にループ部分の再生を開始
        title_loop.PlayScheduled(AudioSettings.dspTime +0.1f+ ((float)title_intro.clip.samples / (float)title_intro.clip.frequency));
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
