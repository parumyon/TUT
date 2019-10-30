using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togenoyuka : MonoBehaviour
{

    private yuusyaAI YuusyaAI;
    private EnemyAI enemyAI;

    bool FarstDame, SecondDame,ThirdDame,FourthDame;
    float Counter = 0.0f;
    private Startbutton startbutton;
    private float holding;
    // Start is called before the first frame update
    void Start()
    {
        YuusyaAI = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
        enemyAI = GameObject.Find("boss").GetComponent<EnemyAI>();

        FarstDame = true;
        SecondDame = true;
        ThirdDame = true;
        FourthDame = true;


        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDrag()
    {
        holding = 1;
    }
    private void OnMouseUp()
    {
        holding = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    YuusyaAI.Speedtyousei = 2; //床に入っているときどの程度おそくなるか（通常時は３）
                }

                if (collision.gameObject.tag == "boss" )
                {
                    Counter += Time.deltaTime;
                    if (Counter >= 0.2 && FarstDame && enemyAI.HP >= 6)
                    {
                        enemyAI.HP -= 5;
                        FarstDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }

                    else if (Counter >= 0.2 && FarstDame&&enemyAI.HP<=5)
                    {
                        enemyAI.HP = 1;
                        FarstDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }
                    
                    else if (Counter >= 0.4 && SecondDame && enemyAI.HP >= 6)
                    {
                        enemyAI.HP -= 5;
                        SecondDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }
                    else if (Counter >= 0.4 && SecondDame && enemyAI.HP <= 5)
                    {
                        enemyAI.HP = 1;
                        SecondDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }
                    else if (Counter >= 0.6 && ThirdDame && enemyAI.HP >= 6)
                    {
                        enemyAI.HP -= 5;
                        ThirdDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }
                    else if (Counter >= 0.6 && ThirdDame && enemyAI.HP <= 5)
                    {
                        enemyAI.HP = 1;
                        ThirdDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 0.5f;
                    }
                    else if (Counter >= 0.8 && FourthDame && enemyAI.HP >= 6)
                    {
                        enemyAI.HP -= 5;
                        FourthDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 1;
                        Destroy(this.gameObject);
                    }
                    else if (Counter >= 0.8 && FourthDame && enemyAI.HP <= 5)
                    {
                        enemyAI.HP = 1;
                        FourthDame = false;
                        enemyAI.damegeTime = 0.5f;
                        enemyAI.EnemySpeedtyousei = 1;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (holding == 0)
        {
            if (startbutton.GameStart == true)
            {
                if (collision.gameObject.tag == "player")
                {
                    YuusyaAI.Speedtyousei = 3;
                    Destroy(this.gameObject);
                }
                else if (collision.gameObject.tag == "boss")
                {
                    enemyAI.EnemySpeedtyousei = 1;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
