using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuusyaAI : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Animator YuushaAnim;
    public UnityEngine.UI.Text textLife;

    public float runSpeed;
    public float moveForceMultiplier;
    public float MOVE;
    public float kaisuu;//判定ができているか確認用
    public float jumphantei;
    public float muki;
    public float hannnou;
    public float AttackDamage = 10.0f;
    public float Speedtyousei;//Unity内で変更しない方がよい、空中制御、拘束などに使用。現在通常時は３
    public int life = 3;

    private Startbutton startbutton;
   // private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        Speedtyousei = 3;

        startbutton = GameObject.Find("Gamemain").GetComponent<Startbutton>();
        YuushaAnim = GameObject.Find("Hero_running").GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        if (textLife != null)
        {
            textLife.text = "Life " + life.ToString();
        }
        if (startbutton.GameStart == true)
        {

            Vector2 moveVector = Vector2.zero;
            if (MOVE == 0)
            {
                moveVector.x = runSpeed * 1 * Speedtyousei;
            }
            else if (MOVE == 1)
            {
                moveVector.x = runSpeed * -1 * Speedtyousei;
            }
            else if (MOVE == 2)
            {
                moveVector.x = runSpeed * 1 * Speedtyousei + 1.8f * Speedtyousei / 3; //２を変更することで敵に近づく速さが変わる
            }
            else if (MOVE == 3)
            {
                moveVector.x = runSpeed * -1 * Speedtyousei - 1.8f * Speedtyousei / 3;
            }
            rb2.AddForce(moveForceMultiplier * (moveVector - rb2.velocity));

            Transform myTransform = this.transform;
            Vector2 sca = myTransform.localScale;
            if (muki == 1)//他のスクリプトで使う変数です。ちゃんと０にもどしてね。
            {
                sca.x = -sca.x;
            }
            transform.localScale = sca;
        }

        ChangeAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform myTransform = this.transform;
        Vector2 sca = myTransform.localScale;
        if (collision.gameObject.tag == "haji" && (MOVE == 0 || MOVE == 2))
        {

            MOVE = 1;
            kaisuu++;
            sca.x = -sca.x;
            hannnou = 0;
        }

        else if (collision.gameObject.tag == "haji" && (MOVE == 1 || MOVE == 3))
        {
            MOVE = 0;
            kaisuu++;
            sca.x = -sca.x;
            hannnou = 0;
        }
        else if (collision.gameObject.tag == "boss" && (MOVE == 0 || MOVE == 2))
        {
            MOVE = 3;
            kaisuu++;
            sca.x = -sca.x;
            hannnou = 2;
            life--;
        }
        else if (collision.gameObject.tag == "boss" && (MOVE == 1 || MOVE == 3))
        {
            MOVE = 2;
            kaisuu++;
            sca.x = -sca.x;
            hannnou = 2;
            life--;
        }
        transform.localScale = sca;

        /*if (collision.gameObject.tag == "Ground")
        {
            jumphantei = 0;
            Speedtyousei = 3;
        }*/

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumphantei = 0;
            Speedtyousei = 3;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumphantei = 1;
            Speedtyousei = Speedtyousei / 4;

        }
    }


    //アニメーションを切り替えるためのメソッド  
    void ChangeAnimation()
    {
        if(startbutton.GameStart==false)
        {
            YuushaAnim.enabled = false;

        }
        else if(startbutton.GameStart)
        {
            YuushaAnim.enabled = true;
        }
        if (MOVE == 0 || MOVE == 1)
        {
            YuushaAnim.SetBool("isRun", false);
            YuushaAnim.SetBool("isWalk", true);
        }
        else if (MOVE == 2 || MOVE == 3)
        {
            YuushaAnim.SetBool("isRun", true);
            YuushaAnim.SetBool("isWalk", false);
        }
    }
}
