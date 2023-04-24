using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement State")]
    public float movementSpeed = 5f;
    public float runSpeed = 6.5f;
    public float runTime = 4f;
    public float turnSmoothTime = .05f;
    public float groundRadius = .3f;

    [Space]
    [Header("Movement while LockOn")]
    public float turnSpeed = 10f;

    [Header("Air")]
    public float gravity = -20f;
    public float jumpForce = 3f;
    public float InAirForce = 0.5f;
    public float jumpTimer = .5f;

    [Space]
    // Air dash
    public float dashDistance = 3f;

    [Space]
    [Header("Weapon")]
    public float normalDamage = 10f;
    public float criticalDamage = 30f;
    public float hitRadius = 2f;

    [Space]
    [Header("Other")]
    public float maximumLockOnDistance = 15f;
    
}
