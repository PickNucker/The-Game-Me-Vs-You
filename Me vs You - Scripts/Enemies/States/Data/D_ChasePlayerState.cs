using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E_ChasePlayerStateData", menuName = "Data /State Data /Chase Player State")]
public class D_ChasePlayerState : ScriptableObject
{
    public float chaseMovementSpeed = 2.5f;
    public float stoppingDistance = 3f;
}
