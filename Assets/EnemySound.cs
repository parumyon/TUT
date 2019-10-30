using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public Animator Boss_anim;
    //public AudioClip Attack_Sound;
    //public AudioClip Damage_Sound;
    //public AudioClip Dead_Sound;
    public AudioSource Attack_Sound;
    public AudioSource Damage_Sound;
    public AudioSource Dead_Sound;
    public EnemyAI enemyAI;
    public int Anim_Flag=0;//アニメーションに応じて、音を鳴らすためのフラグ。
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim_Flag == 1)
        {
            Attack_Sound.Play();
           // AudioSource.PlayClipAtPoint(Attack_Sound, transform.position);
        }
        if (enemyAI.HP <= 0.0f)
        {
           AudioSource.PlayClipAtPoint(Dead_Sound.clip, transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")//勇者にあたったら
        {
            Damage_Sound.Play();
          //  AudioSource.PlayClipAtPoint(Damage_Sound, transform.position);
        }
    }
}
