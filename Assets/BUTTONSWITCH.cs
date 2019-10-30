using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTONSWITCH : MonoBehaviour
{
    public UnityEngine.UI.Button buttonAsiba;
    public GameObject AsibaPrefab;
    public UnityEngine.UI.Button buttonJump;
    public GameObject JumpPrefab;
    public UnityEngine.UI.Button buttonTorabasami;
    public GameObject TorabasamiPrefab;
    public UnityEngine.UI.Button buttonY_otori;
    public GameObject Y_otoriPrefab;
    public UnityEngine.UI.Button buttonB_otori;
    public GameObject B_otoriPrefab;
    public UnityEngine.UI.Button buttonToge;
    public GameObject TogePrefab;
    public UnityEngine.UI.Button buttonIwa;
    public GameObject IwaPrefab;
    public GameObject switchPrefab;

    public GameObject costSlider;
    public costSlider sliderScript;
    Startbutton startbuttonScript;

    public float cost;
    public float asibaCost = 10;
    public float jumpCost = 10;
    public float TorabasamiCost = 10;
    public float Y_otoriCost = 10;
    public float B_otoriCost = 10;
    public float TogeCost = 10;
    public float IwaCost = 10;
    public float costSpeed = 3;//ゲームスタート後のコストかいふくすぴーど


    Rigidbody rid;
    Rigidbody2D rid2;
    // Start is called before the first frame update
    void Start()
    {
        costSlider = GameObject.Find("costSlider");
        sliderScript = costSlider.GetComponent<costSlider>();
        startbuttonScript = this.GetComponent<Startbutton>();

        cost = sliderScript.maxCost;

        var pos = transform.position;

        if (buttonAsiba != null)
        {
            buttonAsiba.onClick.AddListener(delegate
            {
                if (cost >= asibaCost)
                {
                    var newAsiba = Instantiate(AsibaPrefab);
                    newAsiba.transform.position = new Vector3(-10.2f, -6.5f, 0);

                    var physic = newAsiba.GetComponent<Rigidbody>();

                    cost -= asibaCost;
                }
            });
        }
        if (buttonJump != null)
        {
            buttonJump.onClick.AddListener(delegate
            {
                if (cost >= jumpCost)
                {
                    var newJump = Instantiate(JumpPrefab);
                    newJump.transform.position = new Vector3(-7, -6.5f, 0);

                    var physic = newJump.GetComponent<Rigidbody>();

                    cost -= jumpCost;
                }
            });
        }
        if (buttonTorabasami != null)
        {
            buttonTorabasami.onClick.AddListener(delegate
            {
                if (cost >= TorabasamiCost)
                {
                    var newTorabasami = Instantiate(TorabasamiPrefab);
                    newTorabasami.transform.position = new Vector3(-3.5f, -6.5f, 0);

                    var physic = newTorabasami.GetComponent<Rigidbody>();

                    cost -= TorabasamiCost;
                }
            });
        }

        if (buttonY_otori != null)
        {
            buttonY_otori.onClick.AddListener(delegate
            {
                if (cost >= Y_otoriCost)
                {
                    var newY_otori = Instantiate(Y_otoriPrefab);
                    newY_otori.transform.position = new Vector3(3.5f, -6.5f, 0);

                    var physic = newY_otori.GetComponent<Rigidbody>();

                    cost -= Y_otoriCost;
                }
            });
        }
        if (buttonB_otori != null)
        {
            buttonB_otori.onClick.AddListener(delegate
            {
                if (cost >= B_otoriCost)
                {
                    var newB_otori = Instantiate(B_otoriPrefab);
                    newB_otori.transform.position = new Vector3(0, -6.5f, 0);

                    var physic = newB_otori.GetComponent<Rigidbody>();

                    cost -= B_otoriCost;
                }
            });
        }

        if (buttonToge != null)
        {
            buttonToge.onClick.AddListener(delegate
            {
                if (cost >= TogeCost)
                {
                    var newToge = Instantiate(TogePrefab);
                    newToge.transform.position = new Vector3(7, -6.5f, 0);

                    var physic = newToge.GetComponent<Rigidbody>();

                    cost -= TogeCost;
                }
            });
        }

        if (buttonIwa != null)
        {
            buttonIwa.onClick.AddListener(delegate
            {
                if (cost >= IwaCost)
                {
                    var newIwa = Instantiate(IwaPrefab);
                    var newSwitch = Instantiate(switchPrefab);
                    newIwa.transform.position = new Vector3(10.5f, -6.5f, 0);
                    newSwitch.transform.position = new Vector3(12.1f, -6.5f, 0);



                    cost -= IwaCost;
                }
            });
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (startbuttonScript.A == 1 && cost < sliderScript.maxCost)
        {
            cost = cost + Time.deltaTime * costSpeed;
        }


    }

}

