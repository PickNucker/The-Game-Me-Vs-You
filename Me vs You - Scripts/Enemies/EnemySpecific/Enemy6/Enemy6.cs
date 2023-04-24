using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : Entity
{
    #region StateMachine & Data
    public E6_IdleState idleState { get; private set; }
    public E6_WalkState walkState { get; private set; }
    public E6_ChasePlayerState chasePlayerState { get; private set; }
    public E6_SuspicionState suspicionState { get; private set; }
    public E6_TargetingState targetingState { get; private set; }
    public E6_MeleeAttack meeleAttackState { get; private set; }
    public E6_MeleeAttack2 meeleAttackState2 { get; private set; }
    public E6_MeleeAttack3 meeleAttackState3 { get; private set; }
    public E6_GotHitState gotHitState { get; private set; }
    public E6_DeadState deadState { get; private set; }

    [SerializeField] D_IdleState idleStateData;
    [SerializeField] D_WalkState walkStateData;
    [SerializeField] D_ChasePlayerState chasePlayerStateData;
    [SerializeField] D_SuspicionStateData suspicionStateData;
    [SerializeField] D_BehaviourState targetingStateData;
    [SerializeField] D_DeadState deadStateData;
    #endregion

    public bool isDead { get; private set; }

    //Audio
    [SerializeField] AudioTrigger footSteps = null;
    [SerializeField] AudioTrigger krabeHit = null;
    [SerializeField] AudioTrigger krabeBleyBlade = null;
    [SerializeField] AudioTrigger krabeHit3 = null;
    [SerializeField] AudioTrigger gettingHit = null;
    [SerializeField] AudioTrigger deadSound = null;

    float timer = 0;

    int currentHitCounter = 0;

    bool activate = false;
    bool inAir = true;

    public override void Awake()
    {
        base.Awake();

        walkState = new E6_WalkState(this, stateMachine, animManager, walkStateData, this, "", "walk");
        idleState = new E6_IdleState(this, stateMachine, animManager, idleStateData, this, "", "idle");
        chasePlayerState = new E6_ChasePlayerState(this, stateMachine, animManager, chasePlayerStateData, this, "", "run");
        suspicionState = new E6_SuspicionState(this, stateMachine, animManager, suspicionStateData, this, "", "sus");
        targetingState = new E6_TargetingState(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState = new E6_MeleeAttack(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState2 = new E6_MeleeAttack2(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState3 = new E6_MeleeAttack3(this, stateMachine, animManager, targetingStateData, this, "", "");
        gotHitState = new E6_GotHitState(this, stateMachine, animManager, targetingStateData, this, "", "");
        deadState = new E6_DeadState(this, stateMachine, animManager, deadStateData, this, "", "dead");

        stateMachine.Initialize(idleState);
    }



    public override void Update()
    {
        base.Update();
        HandleDeath();
        HandleHit();
        HandleAir();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckIfIsGrounded();
    }

    void HandleDeath()
    {
        if (health.health <= 0)
        {
            isDead = true;
            stateMachine.ChangeState(deadState);
            Invoke(nameof(GetPlayerEXP), .1f);
            return;
        }
    }

    void HandleHit()
    {
        if (gotHit)
        {
            if (currentHitCounter > hitCounter && isGrounded)
            {
                if (timer >= targetingStateData.timerToGetHitable) currentHitCounter = 0;
                timer += Time.deltaTime;
            }
            else
            {
                currentHitCounter++;
                var effekt = Instantiate(hitEffekt, hitPos.position, Quaternion.identity);
                effekt.transform.LookAt(Camera.main.transform.position);
                Destroy(effekt, .5f);
                stateMachine.ChangeState(gotHitState);
            }
        }
    }

    void HandleAir()
    {
        if (inAir)
        {
            //rigid.MovePosition(new Vector3(0, curveY.Evaluate(Time.time), 0));
        }
    }

    void GetPlayerEXP()
    {
        if (!activate)
        {
            LevelSystem.instance.AddEXP(exp);
            activate = true;
        }
    }

    #region Audio
    void FootSteps()
    {
        footSteps.Play(transform.position);
    }

    void Dead()
    {
        deadSound.Play(transform.position);
    }

    void KrabeHit()
    {
        krabeHit.Play(transform.position);
    }

    void KrabeHit2()
    {
        krabeBleyBlade.Play(transform.position);
    }
    void KrabeHit3()
    {
        krabeHit3.Play(transform.position);
    }

    void GettingHit()
    {
        gettingHit.Play(transform.position);
    }
    #endregion
}
