using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Entity spawnableEnemy = null;

    [SerializeField] Entity enemy;
    
    [SerializeField] float spawnTimer = 5f;

    float timer = 0;

    private void Update()
    {
        if(enemy.health.health <= 0)
        {
            timer += Time.deltaTime;

            if(timer >= spawnTimer)
            {
                spawnableEnemy.health.health = spawnableEnemy.health.maxHealth;
                spawnableEnemy.GetComponent<CapsuleCollider>().enabled = true;
                spawnableEnemy.GetComponent<CombatTarget>().enabled = true;
                spawnableEnemy.GetComponent<EnemyHealth>().enabled = true;

                if(enemy.patrolPath != null)
                {
                    spawnableEnemy.patrolPath = enemy.patrolPath;
                }

                Instantiate(spawnableEnemy, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
