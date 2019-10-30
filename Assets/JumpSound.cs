using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioSource Jump_Sound;

    private yuusyaAI jimen;
    private jumpkanri2 jumpkanri;
    private bool ikkai;

    // Start is called before the first frame update
    void Start()
    {
        jimen = GetComponentInParent<yuusyaAI>();
        jumpkanri = GetComponent<jumpkanri2>();
        ikkai = true;
    }
    
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jimen.jumphantei == 0)
        {
                Jump_Sound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && jimen.jumphantei == 0)
        {
            jumpkanri.Counter += Time.deltaTime;
            if (jumpkanri.Counter >= jumpkanri.RejumpTime && ikkai==true)
            {
                ikkai = false;
                Jump_Sound.Play();
            }
        }
    }
    
}
