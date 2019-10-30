using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Transform mytrans;
    public float MOVE_SPEED;
    public int MOVE;
    public Animator BossWalk;
    public Animator ClearAnim;

    Animator myAnim;

    const float DAMEGE_TIME = 0.5f;

    public UnityEngine.UI.Slider sliderHP;
    public float HP;
    public float maxHP = 100.0f;


    public float damegeTime = 0.0f;
    public float EnemySpeedtyousei = 1.0f;
    float Counter;
    SpriteRenderer sprite;

    GameObject RakusekiIwa;
    RakusekiIwa RakusekiIwaScript;
    int IwaMode;

    private Startbutton startbutton;


    // Start is called before the first frame update
    void Start()
    {
        MOVE = 1;
        myAnim = GetComponent<Animator>();
        ClearAnim = GameObject.Find("Image").GetComponent<Animator>();


        sprite = GetComponent<SpriteRenderer>();
        this.HP = maxHP;
        if (sliderHP != null)
        {
            sliderHP.value = 1.0f;
        }

        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();

        RakusekiIwa = GameObject.Find("rakuseki_iwa");
        RakusekiIwaScript = RakusekiIwa.GetComponent<RakusekiIwa>();

        BossWalk = GameObject.Find("Boss_walking_R").GetComponent<Animator>();
    }

      
     
        
    // Update is called once per frame
    void Update()
    {
        if (startbutton.GameStart == true)
        {
            AnimatorStateInfo stateInfo = myAnim.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Boss_anim") == false)
            {
                if (MOVE == 0)//右
                {
                    GetComponent<Transform>().Translate(new Vector3(MOVE_SPEED * EnemySpeedtyousei, 0, 0));
                    BossWalk.SetBool("isWalk", true);
                    BossWalk.SetBool("isAttack", false);
                }

                if (MOVE == 1)//左
                {
                    GetComponent<Transform>().Translate(new Vector3(-MOVE_SPEED * EnemySpeedtyousei, 0, 0));
                    BossWalk.SetBool("isWalk", true);
                    BossWalk.SetBool("isAttack", false);
                }
            }

            IwaMode = RakusekiIwaScript.mode;
        }

        var pos = transform.position;

        if (damegeTime > 0.0f)
        {
            damegeTime -= Time.deltaTime;
            if (damegeTime < 0.0f) damegeTime = 0.0f;
            sprite.color = Color.Lerp(
                Color.red, Color.white, (1.0f - damegeTime / DAMEGE_TIME));
        }


        if (this.HP <= 0.0f)
        {
            this.HP = 0.0f;
            Destroy(this.gameObject);
            ClearAnim.SetBool("isClear", true);
        }
        if (sliderHP != null)
        {
            sliderHP.value = this.HP / maxHP;
        }


    
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform myTransform = this.transform;
        Vector2 sca = myTransform.localScale;

        if (collision.gameObject.tag == "haji" && MOVE == 0)
        {
            MOVE = 1;
            sca.x = -sca.x;
        }
        else if (collision.gameObject.tag == "haji" && MOVE == 1)
        {
            MOVE = 0;
            sca.x = -sca.x;
        }

        transform.localScale = sca;

        if (collision.gameObject.tag == "player")//勇者にあたったら
        {
            var script = collision.gameObject.GetComponent<yuusyaAI>();
            if (script != null)
            {
                this.HP -= script.AttackDamage;
                damegeTime = DAMEGE_TIME;
            }
            EnemySpeedtyousei = 0.1f;
        }

        if (collision.gameObject.tag == "Iwa" && IwaMode == 1 && HP>=21)
        {
            this.HP -= RakusekiIwaScript.IwaDamage;
            damegeTime = DAMEGE_TIME;
        }
       else if (collision.gameObject.tag == "Iwa" && IwaMode == 1 && HP <= 20)
        {
            this.HP =1;
            damegeTime = DAMEGE_TIME;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")//勇者にあたったら
        {
            EnemySpeedtyousei = 1.0f;
        }

    }

}
