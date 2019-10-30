using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_DeadSound : MonoBehaviour
{
    public EnemyAI enemyAI;
    public AudioSource Dead_Sound;
    private int PlayOnceFlag = 0;
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayOnceFlag == 0)
        {
            if (enemyAI.HP <= 0.0f)
            {
                Dead_Sound.Play();
                PlayOnceFlag = 1;
            }
        }
    }
}
