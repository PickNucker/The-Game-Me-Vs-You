using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E_BehaviourStateData", menuName = "Data/State Data/Behaviour State")]
public class D_BehaviourState : ScriptableObject
{
    public float chaseSpeed = 2.5f;
    public float timeBetweenAttacks = 1.5f;
    public float timerToGetHitable = 2f;
}
