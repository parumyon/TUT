﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stageselect : MonoBehaviour
{
   
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
                    SceneManager.LoadScene("yuusyaAI_otamesi");
                });

            }
        }
    }