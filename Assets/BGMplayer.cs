using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{
    public AudioSource Battle_intro;
    public AudioSource Battle;
    public AudioSource Victory;
    public AudioSource Defeat;

    public yuusyaAI yuusya;
    public EnemyAI enemy;

    private int Battle_Flag = 0;
    private int Victory_Flag = 0;
    private int Defeat_Flag = 0;

    public AudioSource TrapPart;

    public UnityEngine.UI.Button buttonGameStart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.HP <= 0)
        {
            if (Victory_Flag == 0)
            {
                Battle.Stop();
                Victory.PlayDelayed(0.7f);
                Victory_Flag = 1;
            }
        }
        else if (yuusya.life <= 0)
        {
            if (Defeat_Flag == 0)
            {
                Battle.Stop();
                Defeat.PlayOneShot(Defeat.clip);
                Defeat_Flag = 1;
            }
        }
        else if (Battle_Flag == 1 || Battle_Flag == 2)
        {
            TrapPart.Stop();
            if (Battle_Flag == 1 && Battle.isPlaying == false)
            {
                Battle_intro.Play();
                Battle_Flag = 2;
            }
            if (Battle_intro.isPlaying == false && Battle.isPlaying == false)
            {
                Battle.Play();
            }
        }
        else
        {
            if (TrapPart.isPlaying == false)
            {
                TrapPart.Play();
            }
        }

        if (buttonGameStart != null)
        {
            buttonGameStart.onClick.AddListener(delegate
            {
                Battle_Flag = 1;
            });

        }
    }
}
