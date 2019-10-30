using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNAP : MonoBehaviour
{
    public float SnapRange = 1.0f;
    public float a;
    public float Snapping;

    GameObject[] snapPointList;
    Vector2 ofsPos;
    public GameObject Box;

    // Start is called before the first frame update
    void Start()
    {
        snapPointList = GameObject.FindGameObjectsWithTag("SnapPoint");
    }

    void OnMouseDown()
    {
        a = 1;

        var mPos = Input.mousePosition;
        mPos.z = 10.0f;
        var wPos = Camera.main.ScreenToWorldPoint(mPos);
        ofsPos = transform.position - wPos;



    }

    void OnMouseDrag()
    {
        var mPos = Input.mousePosition;
        mPos.z = 10.0f;
        var wPos = Camera.main.ScreenToWorldPoint(mPos);
        Snapping = 1;
        var pos = new Vector2(
            wPos.x + ofsPos.x,
            wPos.y + ofsPos.y

        );
        transform.position = CalcSnapPosition(pos);
    }

    void OnMouseUp()
    {
        Snapping = 0;
    }



    // スナップ位置を計算
    Vector2 CalcSnapPosition(Vector2 srcPos)
    {
        if (snapPointList.Length <= 0)
        {
            // SnapPoint がないとき
            return srcPos;
        }

        // 近くのSnapPointを探す
        GameObject spoint = snapPointList[0];
        float miniDistance = 1000.0f;
        foreach (var item in snapPointList)
        {
            // SnapPoint 毎に距離を測定して判定
            float distance = Vector2.Distance(
                srcPos, item.transform.position);
            if (miniDistance > distance)
            {
                miniDistance = distance;
                spoint = item; //<- 近いSnapPoint
            }
        }
        // Snap Range内か？
        if (miniDistance > SnapRange)
        {
            // Snap Range 以上のとき
            return srcPos;
        }

        // SnapPoint へ移動
        return spoint.transform.position;
    }
}
