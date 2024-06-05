using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBlast : MonoBehaviour
{
    public GameObject Blast;
    public GameObject Blast2;
    public AudioSource  BlastClip;
   
    public int hit=0;


    private void Start()
    {
     
        Blast.SetActive(false);
       
        Blast2.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hit++;
            if (hit == 6)
            {
                BlastClip.Play();
                Blast.SetActive(true);
                Blast2.SetActive(true);
                WeaponManager.damage += 15;
            }
        }
    }
}
