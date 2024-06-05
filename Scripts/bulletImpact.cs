using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact : MonoBehaviour
   
{
    public ParticleSystem impact;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            impact.transform.position = collision.contacts[0].point;
            impact.Play();
        }
    }
}
