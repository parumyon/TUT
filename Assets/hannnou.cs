using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hannnou : MonoBehaviour
{
    public GameObject bikkuri;
    public GameObject butukari;

    private yuusyaAI moving;
    // Start is called before the first frame update
    void Start()
    {
        moving = GameObject.Find("yuusya").GetComponent<yuusyaAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moving.hannnou == 0)
        {
            bikkuri.SetActive(false);
            butukari.SetActive(false);
        }
        else if (moving.hannnou == 1)
        {
            bikkuri.SetActive(true);
            butukari.SetActive(false);
        }
        else if (moving.hannnou == 2)
        {
            bikkuri.SetActive(false);
            butukari.SetActive(true);
        }
    }
}
