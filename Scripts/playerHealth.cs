using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public PlayerHealthBar healthBar;
    public GameObject blood;
    public int delay;
    public GameObject GameOver;
    private bool isPaused = false;
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mediKit"))
        {
            medikit(20);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(10);
            blood.SetActive(true);
            StartCoroutine(BloodActive(delay));
            if (currentHealth <= 0)
            {
                GameOver.SetActive(true);
                TogglePause();

            }
        }
        if (collision.gameObject.CompareTag("zombie"))
        {
            TakeDamage(10);
            blood.SetActive(true);
            StartCoroutine(BloodActive(delay));
            if (currentHealth <= 0)
            {
                GameOver.SetActive(true);
                TogglePause();

            }
        }
       
        
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void medikit(int healthh)
    {
        currentHealth += healthh;
        healthBar.SetHealth(currentHealth);
        Debug.Log("updated");
       
    }
    IEnumerator BloodActive(int delay)
    {
        yield return new WaitForSeconds(delay);
        blood.SetActive(false);
    }
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGameTime();
        }
        else
        {
            ResumeGameTime();
        }
    }

    void PauseGameTime()
    {
        Time.timeScale = 0f; // Freezes the game
    }

    void ResumeGameTime()
    {
        Time.timeScale = 1f; // Resumes the game
    }

}
