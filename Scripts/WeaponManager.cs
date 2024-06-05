using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;
    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletPerShot;
    AimStateManager aim;
    public ParticleSystem fireParticle;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;

    public static int damage = 0;
    public TextMeshProUGUI damageText;

    public static int totalBullet=25;
    public TextMeshProUGUI totalBulletText;
    public static int currentBullet1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        totalBullet = 25;

        fireRateTimer = fireRate;
    }

   
    void Update()
    {
        if (shouldfire())
        {
            Fire();
        }
        totalBulletText.text = currentBullet1.ToString();

    }
    bool shouldfire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate)
        {
            return false;
        }
        if(semiAuto&&Input.GetKeyDown(KeyCode.Mouse0))
        {
         return true;
        }
        if (!semiAuto && Input.GetKeyDown(KeyCode.Mouse0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Fire()
    {
       
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
     
        if(totalBullet >= 0)
        {
            for (int i = 0; i < bulletPerShot; i++)
            {
                audioSource.PlayOneShot(gunShot);
                fireParticle.Play();
                GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
                Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
                rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
                currentBullet1=totalBullet--;
                totalBulletText.text = currentBullet1.ToString();
                damage++;
                damageText.text = "Damage : " + damage.ToString();
            }
        }
        
    }
}
