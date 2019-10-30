using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Hole_WarpPosition;　//ワープ先
    public GameObject Yuusya;

    Transform HoleTrans;
    Transform YuusyaTrans;
    yuusyaAI YuusyaAI;

    public int q=0;
    // Start is called before the first frame update
    void Start()
    {
        HoleTrans = Hole_WarpPosition.GetComponent<Transform>();
        
        YuusyaAI = Yuusya.GetComponent<yuusyaAI>();
    }

    // Update is called once per frame
    void Update()
    {
        YuusyaTrans = Yuusya.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "player")
        {
            Vector3 WarpSaki;

            WarpSaki.x = HoleTrans.position.x;
            WarpSaki.y = HoleTrans.position.y+0.3f;
            WarpSaki.z = 0.0f;

            Vector2 sca = YuusyaTrans.localScale;
            if (YuusyaAI.MOVE == 0 || YuusyaAI.MOVE == 2)
            {
                WarpSaki.x -= 1.7f;
                YuusyaAI.MOVE = 1;
                sca.x = -sca.x;
            }

            else if (YuusyaAI.MOVE == 1 || YuusyaAI.MOVE == 3)
            {
                WarpSaki.x += 1.7f;
                YuusyaAI.MOVE = 0;
                sca.x = -sca.x;
            }

            YuusyaTrans.position = WarpSaki;
            YuusyaTrans.localScale = sca;
        }
    }

   
}
