using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Boss Data", order = 1)]
public class BossData : ScriptableObject
{
    [Header("Movement")]
    public float standardMovementSpeed = 2f;
    public float groundRadius;


    public LayerMask whatIsGround;

    [Space]
    [Header("Attack-State")]
    public float attackRange = 2f;
    public float attackDamage = 5f;
    public float timerBtwAttack = 2f;

    [Space]
    [Header("Idle State")]
    public float idleTime = 2f;

    [Space]
    [Header("Chase State")]
    public float chaseMovementSpeed = 4f;
    public float chaseFasterRange = 10f;
    public float stoppingDistance = 9f;

    //[Space]
    //[Header("other")]
}
