using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceScript : MonoBehaviour
{
    [SerializeField] GameObject[] iwa;
    [SerializeField] float appearNextTime;
    //[SerializeField] int maxNumOfIwa;
    private int numberOfIwa;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        numberOfIwa = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (numberOfIwa >= maxNumOfIwa)
        //{
          //  return;
        //}
        elapsedTime += Time.deltaTime;

        if(elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearIwa();
        }
    }
    void AppearIwa()
    {
        var randomValue = Random.Range(0, iwa.Length);
        var randomRotationY = Random.value * 360f;
        var randomX = Random.Range(-5.0f, 5.0f);
        GameObject.Instantiate(iwa[randomValue], transform.position, Quaternion.Euler(0f, 0f, 0f));
        numberOfIwa++;
        elapsedTime = 0f;
    }
}
