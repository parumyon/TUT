using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbutton : MonoBehaviour
{
    public UnityEngine.UI.Button buttonStart;
    public float A;
    public bool GameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonStart != null)
        {
            buttonStart.onClick.AddListener(delegate
            {
                GameStart = true;
            });
          
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameStart==true)
        {
            A = 1;
        }
    }
}
