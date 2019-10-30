using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otoriyou_View : MonoBehaviour
{
    private EnemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GameObject.Find("boss").GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "teki_otori")
        {
            enemyAI.EnemySpeedtyousei = 1.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "teki_otori")
        {
            enemyAI.EnemySpeedtyousei = 1.0f;
        }
    }
}
