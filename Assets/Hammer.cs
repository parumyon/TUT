using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public yuusyaAI Yuusya;
    public Transform YuusyaTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 sca = YuusyaTrans.localScale;
        if (collision.gameObject.tag == "player" && Yuusya.MOVE == 0)
        {
            Yuusya.MOVE = 3;
            Yuusya.kaisuu++;
            sca.x = -sca.x;
            Yuusya.hannnou = 2;
            Yuusya.life--;
        }
        else if (collision.gameObject.tag == "player" && Yuusya.MOVE == 1)
        {
            Yuusya.MOVE = 2;
            Yuusya.kaisuu++;
            sca.x = -sca.x;
            Yuusya.hannnou = 2;
            Yuusya.life--;
        }
        YuusyaTrans.localScale = sca;
    }
}
