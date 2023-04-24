using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    #region StateMachine
    public BossStateMachine BossStateMachine { get; private set; }

    //Ground
    public BossIdleState BossIdleState { get; private set; }
    public BossMoveState BossMoveState { get; private set; }
    public BossChaseState BossChaseState { get; private set; }
    public BossTargetingG BossTargetingG { get; private set; }
    public BossStunned BossStunned { get; private set; }

    public BossIdleTakeof BossIdleTakeof { get; private set; }
    public BossRunTakeof BossRunTakeof { get; private set; }

    public BossAttack1 BossAttack1 { get; private set; }
    public BossAttack2 BossAttack2 { get; private set; }
    public BossBreathFire BossBreathFire { get; private set; }

    // Air
    public BossFlyIdle BossFlyIdle { get; private set; }
    public BossFlyMove BossFlyMove { get; private set; }
    public BossTargetingA BossTargetingA { get; private set; }

    public BossIdleLanding BossIdleLanding { get; private set; }
    public BossRunLanding BossRunLanding { get; private set; }

    public BossFlyBreathFire BossFlyBreathFire { get; private set; }


    #endregion

    #region Attached Stuff

    public Animator Anim { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public BossHealth Health { get; private set; }

    #endregion

    #region Variables

    bool isDead;
    //[HideInInspector]
    public bool wave1Cleared;
    [HideInInspector]
    public bool firstStage;
    //[HideInInspector]
    public bool wave2Cleared;
    [HideInInspector]
    public bool secondStage;
    [HideInInspector]
    public bool canDoSpecialAttack;
    [HideInInspector]
    public bool abilityDone;

    bool breathFirevar;

    [SerializeField] BossData data;
    [SerializeField] Player player;

    [SerializeField] List<Entity> wave1 = new List<Entity>();
    [SerializeField] List<Entity> wave2 = new List<Entity>();

    [SerializeField] GameObject firingEffect;

    [SerializeField] GameObject battlemusic;
    [SerializeField] AudioTrigger entranceMusic;

    [SerializeField] AudioTrigger battleEnd;

    [SerializeField] AudioTrigger flügelschlag;
    [SerializeField] AudioTrigger footSteps;
    [SerializeField] AudioTrigger attack1;
    [SerializeField] AudioTrigger attack2;
    [SerializeField] AudioTrigger breathFire;
    [SerializeField] AudioTrigger scream;
    [SerializeField] AudioTrigger land;
    [SerializeField] AudioTrigger dead;

    [SerializeField] UnityEvent bossDead;

    Collider colliderr;

    float timerToGetDamage = 0;


    public bool endWave1;
    public bool endWave2;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        #region States
        BossStateMachine = new BossStateMachine();

        //Ground
        BossIdleState = new BossIdleState(this, data, BossStateMachine, "sidle");
        BossMoveState = new BossMoveState(this, data, BossStateMachine, "run");
        BossChaseState = new BossChaseState(this, data, BossStateMachine, "run");
        BossTargetingG = new BossTargetingG(this, data, BossStateMachine, "noAggro");
        //BossStunned = new BossStunned(this, data, BossStateMachine, "stunned");
        BossIdleTakeof = new BossIdleTakeof(this, data, BossStateMachine, "");
        //BossRunTakeof = new BossRunTakeof(this, data, BossStateMachine, "runTakeof");
        BossAttack1 = new BossAttack1(this, data, BossStateMachine, "");
        BossAttack2 = new BossAttack2(this, data, BossStateMachine, "");
        BossBreathFire = new BossBreathFire(this, data, BossStateMachine, "");

        // Air
        BossFlyIdle = new BossFlyIdle(this, data, BossStateMachine, "flyIdle");
        BossFlyMove = new BossFlyMove(this, data, BossStateMachine, "flyMove");
        BossTargetingA = new BossTargetingA(this, data, BossStateMachine, "dead");
        BossIdleLanding = new BossIdleLanding(this, data, BossStateMachine, "");
        // BossRunLanding = new BossRunLanding(this, data, BossStateMachine, "flyToRun");
        BossFlyBreathFire = new BossFlyBreathFire(this, data, BossStateMachine, "");
        #endregion

        Health = GetComponent<BossHealth>();
        Anim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        colliderr = GetComponent<Collider>();
    }

    void Start()
    {
        Time.timeScale = 1;
        BossStateMachine.Initialize(BossTargetingG);
        entranceMusic.Play(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            bossDead.Invoke();
            return;
        }

        timerToGetDamage += Time.deltaTime;

        if (breathFirevar)
        {
            firingEffect.SetActive(true);
        }
        else
        {
            firingEffect.SetActive(false);
        }

        //if (!firstStage && !endWave1)
        //{
        //    if (Health.health <= Health.maxHealth - Health.maxHealth * 0.4f && Health.health > 0)
        //    {
        //        endWave1 = true;
        //        SpawnFirstWave();
        //        BossStateMachine.ChangeState(BossIdleTakeof);
        //        firstStage = true;
        //        Health.hittable = false;
        //    }
        //
        //}

        if (!secondStage && !endWave2)
        {
            if (Health.health <= Health.maxHealth - Health.maxHealth * 0.5f && Health.health > 0)
            {
                endWave2 = true;
                firstStage = false;
                SpawnSecondWave();
                BossStateMachine.ChangeState(BossIdleTakeof);
                canDoSpecialAttack = true;
                secondStage = true;
                Health.hittable = false;
            }
        }

        if (!isDead)
            if (Health.health <= 0)
            {
                StopAgent();
                BossStateMachine.ChangeState(BossTargetingA);
                isDead = true;
            }


        //CheckIfWave1IsCleared();
        CheckIfWave2IsCleared();

        BossStateMachine.CurrentState.LogicUpdate();

    }

    private void FixedUpdate()
    {
        BossStateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    public void DoDamage(float attackDamage)
    {
        if (timerToGetDamage > 1f)
        {
            if (!Player.instance.currentlyDodging && Vector3.Distance(transform.position, player.transform.position) < 10f)
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
                Debug.Log(calculatedDamage);
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

    void EnableBreathFire()
    {
        breathFirevar = true;
        firingEffect.GetComponent<ParticleSystem>().Play(true);
    }

    void DisableBreathFire()
    {
        breathFirevar = false;
        //firingEffect.GetComponent<ParticleSystem>().Stop(true);
    }

    public void SetDestination(Vector3 target, float movementSpeed)
    {
        Agent.isStopped = false;
        Agent.speed = movementSpeed;
        Agent.SetDestination(target);
    }

    public void StopAgent()
    {
        Agent.isStopped = true;
    }

    public bool CheckDistanceToAttack()
    {
        return Vector3.Distance(transform.position, player.transform.position) < data.attackRange;
    }

    public bool CheckDistanceForChase()
    {
        return Vector3.Distance(transform.position, player.transform.position) < data.chaseFasterRange;
    }

    public void SpawnFirstWave()
    {
       // foreach (Entity enemies in wave1)
       // {
       //     enemies.gameObject.SetActive(true);
       // }
    }

    public void SpawnSecondWave()
    {
        foreach (Entity enemies in wave2)
        {
            enemies.gameObject.SetActive(true);
        }
    }

    public void CheckIfWave1IsCleared()
    {
        foreach (Entity enemies in wave1)
        {
            if (enemies.isActiveAndEnabled)
            {
                if (enemies.health.health <= 0)
                {
                    wave1.Remove(enemies);

                    if (wave1.Count <= 0)
                    {
                        wave1Cleared = true;
                    }
                }
            }
        }
    }

    public void CheckIfWave2IsCleared()
    {
        foreach (Entity enemies in wave2)
        {
            if (enemies.isActiveAndEnabled)
            {
                if (enemies.health.health <= 0)
                {
                    wave2.Remove(enemies);

                    if (wave2.Count <= 0)
                    {
                        wave2Cleared = true;
                    }
                }
            }
        }     
    }

    public void SetAbilityDone()
    {
        abilityDone = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, data.chaseFasterRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.attackRange);
    }


    #region Audio

    public void BattleMusic()
    {
        entranceMusic.Stop();
        // battleMusic.Play(Camera.main.transform.position);
        battlemusic.SetActive(true);

    }

    public void BattleEnd()
    {
        //battleEnd.Play(Camera.main.transform.position);
    }

    public void Flügelschlag()
    {
        flügelschlag.Play(transform.position);
    }

    public void FootSteps()
    {
        footSteps.Play(transform.position);
    }

    public void Attack1()
    {
        attack1.Play(transform.position);
    }

    public void Attack2()
    {
        attack2.Play(transform.position);
    }

    public void BreathFire()
    {
        breathFire.Play(transform.position);
    }

    public void Scream()
    {
        scream.Play(transform.position);
    }

    public void Land()
    {
        land.Play(transform.position);
    }

    public void Dead()
    {
        dead.Play(transform.position);
    }

    #endregion
}
