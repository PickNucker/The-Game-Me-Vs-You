using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : Entity
{
    #region StateMachine & Data
    public E9_IdleState idleState { get; private set; }
    public E9_WalkState walkState { get; private set; }
    public E9_ChasePlayerState chasePlayerState { get; private set; }
    public E9_SuspicionState suspicionState { get; private set; }
    public E9_TargetingState targetingState { get; private set; }
    public E9_MeleeAttack meeleAttackState { get; private set; }
    public E9_MeleeAttack2 meeleAttackState2 { get; private set; }
    public E9_MeleeAttack3 meeleAttackState3 { get; private set; }
    public E9_GotHitState gotHitState { get; private set; }
    public E9_DeadState deadState { get; private set; }

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
    [SerializeField] AudioTrigger hit = null;
    [SerializeField] AudioTrigger hit2 = null;
    //[SerializeField] AudioTrigger strahl = null;
    [SerializeField] AudioTrigger deadSound = null;
    [SerializeField] AudioTrigger gettingHit = null;

    float timer = 0;

    int currentHitCounter = 0;

    bool activate = false;
    bool inAir = true;

    public override void Awake()
    {
        base.Awake();

        walkState = new E9_WalkState(this, stateMachine, animManager, walkStateData, this, "", "walk");
        idleState = new E9_IdleState(this, stateMachine, animManager, idleStateData, this, "", "idle");
        chasePlayerState = new E9_ChasePlayerState(this, stateMachine, animManager, chasePlayerStateData, this, "", "run");
        suspicionState = new E9_SuspicionState(this, stateMachine, animManager, suspicionStateData, this, "", "sus");
        targetingState = new E9_TargetingState(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState = new E9_MeleeAttack(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState2 = new E9_MeleeAttack2(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState3 = new E9_MeleeAttack3(this, stateMachine, animManager, targetingStateData, this, "", "");
        gotHitState = new E9_GotHitState(this, stateMachine, animManager, targetingStateData, this, "", "");
        deadState = new E9_DeadState(this, stateMachine, animManager, deadStateData, this, "", "dead");

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

    void SwordHit()
    {
        hit.Play(transform.position);
    }

    void SwordHit2()
    {
        hit2.Play(transform.position);
    }

    void BitHit()
    {

    }

    void GettingHit()
    {
        gettingHit.Play(transform.position);
    }
    #endregion
}
