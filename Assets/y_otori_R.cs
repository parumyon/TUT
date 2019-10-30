using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_otori_R : MonoBehaviour
{
    private Transform YuusyaTrans;

    private yuusyaAI YuusyaAI;
    private Startbutton startbutton;
    private SNAP holding;
    // Start is called before the first frame update
    void Start()
    {
        YuusyaAI = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        holding = GetComponentInParent<SNAP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        YuusyaTrans = GameObject.Find("yuusya").GetComponent<Transform>();
        Vector2 sca = YuusyaTrans.localScale;
        if (holding.Snapping == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player" && YuusyaAI.MOVE == 0)
                {
                    YuusyaAI.Speedtyousei = 4;
                    sca.x = -sca.x;
                    YuusyaAI.MOVE = 1;
                }
                else if (collision.gameObject.tag == "player" && YuusyaAI.MOVE == 1)
                {
                    YuusyaAI.Speedtyousei = 4;
                }
            }
        }
        YuusyaTrans.localScale = sca;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (holding.Snapping == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    YuusyaAI.Speedtyousei = 3;
                }
            }
        }
    }
}
