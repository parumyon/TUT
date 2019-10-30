using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public Animator Boss_anim;
    public Rigidbody2D rid2d;
    public Animator BossAttack;

    private Startbutton startbutton;

    GameObject RakusekiIwa;
    RakusekiIwa RakusekiIwaScript;
    int IwaMode;
    // Start is called before the first frame update
    void Start()
    {
        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        RakusekiIwa = GameObject.Find("rakuseki_iwa");
        RakusekiIwaScript = RakusekiIwa.GetComponent<RakusekiIwa>();

        BossAttack = GameObject.Find("Boss_walking_R").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IwaMode = RakusekiIwaScript.mode;
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (startbutton.GameStart == true)
        {

            if (collision.tag == "player")
            {
                rid2d.velocity = Vector2.zero;
                Boss_anim.SetTrigger("Attack");
                BossAttack.SetBool("isWalk", false);
                BossAttack.SetBool("isAttack", true);

            }
            else if (collision.tag == "Ground")
            {
                rid2d.velocity = Vector2.zero;
                Boss_anim.SetTrigger("Attack");
                BossAttack.SetBool("isWalk", false);
                BossAttack.SetBool("isAttack", true);

            }
            else if (collision.tag == "teki_otori")
            {
                rid2d.velocity = Vector2.zero;
                Boss_anim.SetTrigger("Attack");
                BossAttack.SetBool("isWalk", false);
                BossAttack.SetBool("isAttack", true);

            }

            if (collision.tag == "Iwa" && IwaMode == 2)
            {
                rid2d.velocity = Vector2.zero;
                Boss_anim.SetTrigger("Attack");
                BossAttack.SetBool("isWalk", false);
                BossAttack.SetBool("isAttack", true);

            }
        }
    }
}
