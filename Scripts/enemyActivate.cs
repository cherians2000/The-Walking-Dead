using UnityEngine;

public class EnemyActivate : MonoBehaviour
{
    public GameObject enemyToActivate;
    public GameObject[] enemies;

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
