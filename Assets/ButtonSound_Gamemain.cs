using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound_Gamemain : MonoBehaviour
{
    public UnityEngine.UI.Button[] TrapButton;

    public AudioSource Button_Sound;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        for (int i = 0; i < TrapButton.Length; i++)
        {
            if (TrapButton[i] != null)
            {
                TrapButton[i].onClick.AddListener(delegate
                {
                    Button_Sound.Play();
                });
            }
        }
    }

}
