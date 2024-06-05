using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] float timeToDestroy;
  
    float timer;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            Destroy(this.gameObject,5f);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {


        
        string collidedObjectTag = collision.gameObject.tag;
       

        Debug.Log("Hit On: " + collidedObjectTag);
        Destroy(this.gameObject, 0.01f);
    }

}
