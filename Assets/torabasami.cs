using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torabasami : MonoBehaviour
{
    public float kousokujikan = 2.0f;
    public Animator TorabasamiAnim;

    private yuusyaAI YuusyaAI;
    private EnemyAI enemyAI;

    //bool FarstDame, SecondDame;
    public GameObject parent;
    float Counter = 0.0f;
    private Startbutton startbutton;
    private SNAP holding;
    //private SNAP snap;
    // Start is called before the first frame update
    void Start()
    {
        YuusyaAI = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
        enemyAI = GameObject.Find("boss").GetComponent<EnemyAI>();
        holding = GetComponentInParent<SNAP>();
        TorabasamiAnim = GameObject.Find("Trap_Torabasami_Animation_1").GetComponent<Animator>();

        //FarstDame = true;
        //SecondDame = true;
        parent = transform.parent.gameObject;

        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        //snap = GameObject.Find("torabasami").GetComponent<SNAP>();
    }

    // Update is called once per frame
    void Update()
    {
    }

   


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (holding.Snapping == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    Counter += Time.deltaTime;
                    if (Counter >= kousokujikan)
                    {
                        YuusyaAI.Speedtyousei = 3;
                        Destroy(parent.gameObject);
                    }

                }

                if (collision.gameObject.tag == "boss")
                {
                    Counter += Time.deltaTime;
                    /*if (Counter >= 1 && FarstDame)
                    {
                        enemyAI.HP -= 10;
                        FarstDame = false;
                        enemyAI.damegeTime = 0.5f;
                    }*/
                    if (Counter >= kousokujikan /*&& SecondDame*/)
                    {
                        /*enemyAI.HP -= 10;
                        SecondDame = false;
                        enemyAI.damegeTime = 0.5f;*/
                        enemyAI.EnemySpeedtyousei = 1;
                        Destroy(parent.gameObject);
                    }
                }
            }
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (holding.Snapping == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    YuusyaAI.life--;
                    YuusyaAI.Speedtyousei = 0;
                }
                else if (collision.gameObject.tag == "boss"&&enemyAI.HP>=31)
                {
                    enemyAI.HP -= 30;
                    enemyAI.EnemySpeedtyousei = 0.0001f;
                    enemyAI.damegeTime = 0.5f;
                    TorabasamiAnim.SetBool("isHUNDA", true);
                }

                else if (collision.gameObject.tag == "boss" && enemyAI.HP <= 30)
                {
                    enemyAI.HP =1;
                    enemyAI.EnemySpeedtyousei = 0.0001f;
                    enemyAI.damegeTime = 0.5f;
                    TorabasamiAnim.SetBool("isHUNDA", true);
                }
            }
        }
    }

   
}
