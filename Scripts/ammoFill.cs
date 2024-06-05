using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoFill : MonoBehaviour
{
    private Animation anim;
    public int delay;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play();
            Destroy(gameObject, delay);

            // Find the WeaponManager component in the player hierarchy
            WeaponManager weaponManager = other.GetComponentInChildren<WeaponManager>();

            if (weaponManager != null)
            {
                // Increase currentBullet1 by 25
                WeaponManager.currentBullet1 += 25;
                WeaponManager.totalBullet = WeaponManager.currentBullet1;
            }
        }
    }
}
