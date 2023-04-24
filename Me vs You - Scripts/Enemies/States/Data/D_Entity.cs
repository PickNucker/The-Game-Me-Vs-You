using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E_BaseData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float agroRange = 10f;
    public float attackRange = 2f;
    public float targetingRange = 2.5f;
    public float dwellTime = 2f;

    public int maxHitCounter = 5;

    public float groundRadius = .4f;
    public LayerMask whatIsGround;
}
