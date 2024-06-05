using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class parasiteragdollEnabling : MonoBehaviour
{


    public BoxCollider mainCollider;
    public GameObject ThisGuyRig;
    public Animator animator;
    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;
    NavMeshAgent navMeshAgent;
    public ParticleSystem bloodEffect;
    public ParticleSystem DestroyEffect;
    public float delay = 1f;
    public AudioSource dieEffect;
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();

        currentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);

    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(5);
            bloodEffect.transform.position = collision.contacts[0].point;
            bloodEffect.Play();
            Debug.Log("hitted");
            if (currentHealth <= 0)
            {
                GameManager.Pkilled++;
                RagdollModeOn();
                Destroy(healthBar);
            }

        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void GetRagdollBits()
    {
        ragDollColliders = ThisGuyRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThisGuyRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
        StartCoroutine(PlayDestroyEffectWithDelay(delay));
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }
        animator.enabled = false;
        mainCollider.enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;
        dieEffect.Play();

        GameManager.instance.IncrementKills();

        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = true; // Stop the NavMeshAgent from finding a path.
        }
    }
    IEnumerator PlayDestroyEffectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Play the destroy effect at the object's position
        if (DestroyEffect != null)
        {
            Destroy(ThisGuyRig);
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        }



    }
    void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        animator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = false; // Resume the NavMeshAgent's pathfinding.
        }
    }


}
