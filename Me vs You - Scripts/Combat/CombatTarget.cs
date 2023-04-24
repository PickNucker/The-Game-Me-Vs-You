using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTarget : MonoBehaviour
{
    public Transform lockOnTarget = null;
    public GameObject healthNameEnemy;
    public GameObject boss;

    public float curhealth;

    private void Update()
    {
        //if(healthNameEnemy != null)

        var enmey = healthNameEnemy.TryGetComponent<EnemyHealth>(out EnemyHealth health);
        var bossHealth = boss.TryGetComponent<BossHealth>(out BossHealth bossHealths);

        if (enmey)
        {
            curhealth = health.health;
        }

        if (bossHealth)
        {
            curhealth = bossHealths.health;
        }
    }
}
