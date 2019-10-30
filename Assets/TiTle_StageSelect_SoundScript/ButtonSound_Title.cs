using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound_Title : MonoBehaviour
{
    public AudioSource Button_SE;
    public UnityEngine.UI.Button buttonGameStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonGameStart != null)
        {
            buttonGameStart.onClick.AddListener(delegate
            {
                Button_SE.PlayOneShot(Button_SE.clip);
            });

        }
    }
}
