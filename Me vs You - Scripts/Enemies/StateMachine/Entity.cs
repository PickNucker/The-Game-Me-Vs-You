using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    #region Decleration
    public D_Entity entityData;
    public PatrolPath patrolPath;
    public Player player;

    public FiniteStateMachine stateMachine;
    public Rigidbody rigid { get; private set; }
    public Animator anim { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public AnimationManager animManager { get; private set; }
    public EnemyHealth health { get; private set; }

    public Vector3 velocity { get; private set; }
    public Vector3 guardPos { get; private set; }
    protected bool isGrounded {get; private set;}

    public int exp;

    public GameObject hitEffekt;
    public Transform hitPos;

    [HideInInspector]
    public int hitCounter;

    [HideInInspector]
    public bool abilityDone;
    [HideInInspector]
    public bool gotHit;
    [HideInInspector]
    public float timeSinceArrivedAtWaypoint = Mathf.Infinity;


    Vector3 destination;

    float timerToGetDamage = Mathf.Infinity;

    int currentWaypointIndex = 0;
    #endregion

    #region UnityCallbacks
    public virtual void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        animManager = GetComponent<AnimationManager>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        player = FindObjectOfType<Player>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Start()
    {
        abilityDone = false;
        hitCounter = entityData.maxHitCounter;
        guardPos = transform.position;
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        timeSinceArrivedAtWaypoint += Time.deltaTime;
        timerToGetDamage += Time.deltaTime;
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    #endregion

    #region Check Functions
    public virtual bool CheckDistanceToAgro()
    {
        return Vector3.Distance(transform.position, player.transform.position) < entityData.agroRange;
    }

    public virtual bool CheckDistanceToAttack()
    {
        return Vector3.Distance(transform.position, player.transform.position) < entityData.attackRange;
    }

    public virtual bool CheckDistanceForTargeting()
    {
        return Vector3.Distance(transform.position, player.transform.position) < entityData.targetingRange;
    }

    public virtual void CheckIfIsGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, entityData.groundRadius, entityData.whatIsGround);
    }

    #endregion

    #region NavMeshAgent AI

    public virtual void SetDestination(Vector3 target)
    {
        destination = target;
        agent.SetDestination(destination);
    }


    #region Patrol Behaviour
    public virtual void PatrolBehaviour()
    {
        Vector3 nextPos = guardPos;

        if(patrolPath != null)
        {
            if (AtWaypoint())
            {
                timeSinceArrivedAtWaypoint = 0;
                CycleWaypoint();
            }
            nextPos = GetCurrentWaypoint();
        }

        if(timeSinceArrivedAtWaypoint > entityData.dwellTime)
            SetDestination(nextPos);
    }
    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint < 1f;
    }

    private Vector3 GetCurrentWaypoint()
    {
        return patrolPath.GetPosition(currentWaypointIndex);
    }

    private void CycleWaypoint()
    {
        currentWaypointIndex = patrolPath.GetNextPos(currentWaypointIndex);
    }

    #endregion

    #endregion

    #region Other

    public void DoDamage(float attackDamage)
    {
        if (timerToGetDamage > 1f)
        {
            if(!Player.instance.currentlyDodging)
            {
                timerToGetDamage = 0;

                float damage;

                if (SkillSystem.instance.GetCurrentArmor() == 1)
                {
                    damage = 0;
                }
                else
                {
                    damage = SkillSystem.instance.GetCurrentArmor() / 25f;
                }

                float calculatedDamage = attackDamage - damage;
                //Debug.Log(calculatedDamage);
                if (calculatedDamage > 0)
                {
                    PlayerHealthBar.instance.RemoveHearts(calculatedDamage);
                }
                else
                {
                    PlayerHealthBar.instance.RemoveHearts(0.1f);
                }
            }
        }


    }

    public void SetAbilityDone()
    {
        abilityDone = true;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, entityData.agroRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, entityData.attackRange);
    }
    #endregion
}
