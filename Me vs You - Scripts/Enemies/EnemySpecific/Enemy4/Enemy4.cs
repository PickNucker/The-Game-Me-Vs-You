using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Entity
{
    #region StateMachine & Data
    public E4_IdleState idleState { get; private set; }
    public E4_WalkState walkState { get; private set; }
    public E4_ChasePlayerState chasePlayerState { get; private set; }
    public E4_SuspicionState suspicionState { get; private set; }
    public E4_TargetingState targetingState { get; private set; }
    public E4_MeleeAttack meeleAttackState { get; private set; }
    public E4_MeleeAttack2 meeleAttackState2 { get; private set; }
    public E4_GotHitState gotHitState { get; private set; }
    public E4_DeadState deadState { get; private set; }

    [SerializeField] D_IdleState idleStateData;
    [SerializeField] D_WalkState walkStateData;
    [SerializeField] D_ChasePlayerState chasePlayerStateData;
    [SerializeField] D_SuspicionStateData suspicionStateData;
    [SerializeField] D_BehaviourState targetingStateData;
    [SerializeField] D_DeadState deadStateData;
    #endregion

    public bool isDead { get; private set; }

    //Audio
    [SerializeField] AudioTrigger swordHit = null;
    [SerializeField] AudioTrigger swordHit2 = null;
    [SerializeField] AudioTrigger gettingHit = null;
    [SerializeField] AudioTrigger deadSound = null;

    float timer = 0;

    int currentHitCounter = 0;

    bool activate = false;
    bool inAir = true;

    public override void Awake()
    {
        base.Awake();

        walkState = new E4_WalkState(this, stateMachine, animManager, walkStateData, this, "", "walk");
        idleState = new E4_IdleState(this, stateMachine, animManager, idleStateData, this, "", "idle");
        chasePlayerState = new E4_ChasePlayerState(this, stateMachine, animManager, chasePlayerStateData, this, "", "run");
        suspicionState = new E4_SuspicionState(this, stateMachine, animManager, suspicionStateData, this, "", "sus");
        targetingState = new E4_TargetingState(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState = new E4_MeleeAttack(this, stateMachine, animManager, targetingStateData, this, "", "");
        meeleAttackState2 = new E4_MeleeAttack2(this, stateMachine, animManager, targetingStateData, this, "", "");
        gotHitState = new E4_GotHitState(this, stateMachine, animManager, targetingStateData, this, "", "");
        deadState = new E4_DeadState(this, stateMachine, animManager, deadStateData, this, "", "dead");

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

    void Dead()
    {
        deadSound.Play(transform.position);
    }

    void SwordHit()
    {
        swordHit.Play(transform.position);
    }

    void SwordHit2()
    {
        swordHit2.Play(transform.position);
    }


    void GettingHit()
    {
        gettingHit.Play(transform.position);
    }
    #endregion
}
