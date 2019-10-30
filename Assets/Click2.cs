using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click2 : MonoBehaviour
{
    public GameObject Asiba;
    public GameObject iwa;
    // クリックした位置座標
    private Vector3 clickPosition;
    int x;
    // Use this for initialization
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            x = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            x = 2;
        }
        // マウス入力で左クリックをした瞬間
        if (Input.GetMouseButtonDown(0) && x ==1)
        {
            // ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
            // Vector3でマウスがクリックした位置座標を取得する
            clickPosition = Input.mousePosition;
            // Z軸修正
            clickPosition.z = 10f;
            // オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
            // ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
            Instantiate(Asiba, Camera.main.ScreenToWorldPoint(clickPosition), Asiba.transform.rotation);
        }
        if (Input.GetMouseButtonDown(0) && x == 2)
        {
            clickPosition = Input.mousePosition;
            clickPosition.z = 10f;
            Instantiate(iwa, Camera.main.ScreenToWorldPoint(clickPosition), iwa.transform.rotation);
        }
    }
}
