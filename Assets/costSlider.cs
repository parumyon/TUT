using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//このスクリプトではvalueを受けっとって表示する処理だけで、コスト値自体はBUTTONSWITCHスクリプト内で処理
public class costSlider : MonoBehaviour
{
    GameObject Gamemain;
    BUTTONSWITCH script;

    Slider CostSlider;
    public float maxCost = 200;
    public float maxCostInGame = 100;
    public float nowCost;


    // Start is called before the first frame update
    void Start()
    {
        Gamemain = GameObject.Find("Gamemain");
        script = Gamemain.GetComponent<BUTTONSWITCH>();


        CostSlider = GetComponent<Slider>();
        CostSlider.maxValue = maxCost;
        CostSlider.value = maxCost;
    }

    // Update is called once per frame
    void Update()
    {
        nowCost = script.cost;
        CostSlider.value = nowCost;
    }
}
