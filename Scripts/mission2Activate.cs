using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission2Activate : MonoBehaviour
{
    public GameObject enemyToActivate;
    public GameObject[] enemies;
    public GameObject todestroy;
    public GameObject todestroy1;

    private void Start()
    {
        SetEnemiesActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateEnemies();
        }
        Destroy(enemyToActivate);
        Destroy(todestroy);
        Destroy(todestroy1);
    }

    void ActivateEnemies()
    {
        SetEnemiesActive(true);
    }

    void SetEnemiesActive(bool isActive)
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(isActive);
        }
    }
}
