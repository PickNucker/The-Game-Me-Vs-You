using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region State Decleration
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    public PlayerDodgeGroundState DodgeGroundState { get; private set; }
    public PlayerDodgeBackState DodgeBackState { get; private set; }
    public PlayerDodgeLeftState DodgeLeftState { get; private set; }
    public PlayerDodgeRightState DodgeRightState { get; private set; }

    public PlayerDashAirState DashAirState { get; private set; }
    public PlayerSprintState SprintState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }

    public Ability_1 Ability1 { get; private set; }
    public Ability_2 Ability2 { get; private set; }
    public Ability_3 Ability3 { get; private set; }
    public Ability_4 Ability4 { get; private set; }

    // Combo 1
    public P_Attack_1_1_G Attack_1_1_G { get; private set; }
    public P_Attack_1_2_G Attack_1_2_G { get; private set; }
    public P_Attack_1_3_G Attack_1_3_G { get; private set; }
    public P_Attack_1_4_G Attack_1_4_G { get; private set; }
    public P_UpperAttack_1_5_A UpperAttack_1_5_A { get; private set; }
    public P_AirAttack_1_6_A AirAttack_1_6_A { get; private set; }
    public P_AirAttack_1_7_A AirAttack_1_7_A { get; private set; }
    public P_AirAttack_1_8_A AirAttack_1_8_A { get; private set; }

    // Combo 2
    public P_Attack_2_2_G Attack_2_2_G { get; private set; }
    public P_Attack_2_3_G Attack_2_3_G { get; private set; }
    public P_Attack_2_4_G Attack_2_4_G { get; private set; }
    public P_Attack_2_5_G Attack_2_5_G { get; private set; }
    public P_Attack_2_6_G Attack_2_6_G { get; private set; }
    public P_Attack_2_7_G Attack_2_7_G { get; private set; }
    public P_Attack_2_8_G Attack_2_8_G { get; private set; }

    // Combo 3
    public P_Attack_3_2_G Attack_3_2_G { get; private set; }
    public P_Attack_3_3_G Attack_3_3_G { get; private set; }
    public P_Attack_3_4_G Attack_3_4_G { get; private set; }
    public P_Attack_3_5_G Attack_3_5_G { get; private set; }
    public P_Attack_3_6_G Attack_3_6_G { get; private set; }
    public P_Attack_3_7_G Attack_3_7_G { get; private set; }
    public P_Attack_3_8_G Attack_3_8_G { get; private set; }

    // Combo 4
    public P_Attack_4_3_G Attack_4_3_G { get; private set; }
    public P_Attack_4_4_G Attack_4_4_G { get; private set; }
    public P_Attack_4_6_G Attack_4_6_G { get; private set; }
    public P_Attack_4_7_G Attack_4_7_G { get; private set; }

    [SerializeField] PlayerData playerData;
    PlayerState state;
    #endregion

    #region attached Objects
    public static Player instance;

    public CharacterController Controller { get; private set; }
    public Animator Anim { get; private set; }
    public AnimationManager AnimManager { get; private set; }
    public InputSystem Input { get; private set; }
    public IngameUIHandler IngameUi { get; private set; }
    public PlayerHealthBar Health { get; private set; }
    public SkillSystem Skill { get; private set; }
    #endregion

    #region Variables and Stuff
    [SerializeField] Tutorial objecte;
    [SerializeField] Vector3 drag;
    public Transform groundCheck = null;
    [SerializeField] Transform hitPoint = null;
    public LayerMask whatIsGround = default;
    [SerializeField] LayerMask whatIsHitable = default;

    public GameObject healEffekt;
    public Transform healEffektPos;

    [HideInInspector]
    public List<CombatTarget> combatTarget = new List<CombatTarget>();
    public List<BossHealth> boss = new List<BossHealth>();

    public Transform currentTarget = null;
    public CinemachineFreeLook currentCam = null;
    public CinemachineVirtualCamera lockOnCam = null;
    public CinemachineInputProvider provider;
    public InputActionReference reference;

    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool canStartCombo;
    [HideInInspector]
    public bool currentlyAttacking;
    [HideInInspector]
    public bool currentlyDodging;
    [HideInInspector]
    public bool currentlyInLocking;
    [HideInInspector]
    public bool dodgeAttack;
    [HideInInspector]
    public bool canCombo;
    [HideInInspector]
    public bool canInteractWithSomething;

    public bool AnimationHasFinished { get; private set; }
    public bool IsUsingRootMotion { get; private set; }
    public bool IsInteracting { get; private set; }
    public bool EnemyGotHit { get; private set; }
    public bool KnockBack { get; private set; }

    // private variables
    float turningRefSpeed;

    #endregion

    #region Audio
    [Space]
    [Header("Audio")]
    [SerializeField] AudioTrigger footSteps = default;
    [SerializeField] AudioTrigger bleyBlade = default;
    public AudioTrigger healUp = default;
    public AudioTrigger swordHit = default;
    public AudioTrigger dodge = default;

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        // Movement States
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "isIdle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "isRunning");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jumpStart");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "jumpAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "jumpLand");

        DodgeGroundState = new PlayerDodgeGroundState(this, StateMachine, playerData, "dodge");
        DodgeBackState = new PlayerDodgeBackState(this, StateMachine, playerData, "");
        DodgeRightState = new PlayerDodgeRightState(this, StateMachine, playerData, "");
        DodgeLeftState = new PlayerDodgeLeftState(this, StateMachine, playerData, "");

        DashAirState = new PlayerDashAirState(this, StateMachine, playerData, "dash");
        SprintState = new PlayerSprintState(this, StateMachine, playerData, "runningFast");
        DeadState = new PlayerDeadState(this, StateMachine, playerData, "isDead");

        //Skills
        Ability1 = new Ability_1(this, StateMachine, playerData, "");
        Ability2 = new Ability_2(this, StateMachine, playerData, "");
        Ability3 = new Ability_3(this, StateMachine, playerData, "");
        Ability4 = new Ability_4(this, StateMachine, playerData, "");

        // Ground & Air Attack States
        #region Combo 1
        Attack_1_1_G = new P_Attack_1_1_G(this, StateMachine, playerData, "");
        Attack_1_2_G = new P_Attack_1_2_G(this, StateMachine, playerData, "");
        Attack_1_3_G = new P_Attack_1_3_G(this, StateMachine, playerData, "");
        Attack_1_4_G = new P_Attack_1_4_G(this, StateMachine, playerData, "");

        UpperAttack_1_5_A = new P_UpperAttack_1_5_A(this, StateMachine, playerData, "");
        AirAttack_1_6_A = new P_AirAttack_1_6_A(this, StateMachine, playerData, "");
        AirAttack_1_7_A = new P_AirAttack_1_7_A(this, StateMachine, playerData, "");
        AirAttack_1_8_A = new P_AirAttack_1_8_A(this, StateMachine, playerData, "");
        #endregion

        #region Combo 2

        Attack_2_2_G = new P_Attack_2_2_G(this, StateMachine, playerData, "");
        Attack_2_3_G = new P_Attack_2_3_G(this, StateMachine, playerData, "");
        Attack_2_4_G = new P_Attack_2_4_G(this, StateMachine, playerData, "");
        Attack_2_5_G = new P_Attack_2_5_G(this, StateMachine, playerData, "");
        Attack_2_6_G = new P_Attack_2_6_G(this, StateMachine, playerData, "");
        Attack_2_7_G = new P_Attack_2_7_G(this, StateMachine, playerData, "");
        Attack_2_8_G = new P_Attack_2_8_G(this, StateMachine, playerData, "");

        #endregion

        #region Combo 3

        Attack_3_2_G = new P_Attack_3_2_G(this, StateMachine, playerData, "");
        Attack_3_3_G = new P_Attack_3_3_G(this, StateMachine, playerData, "");
        Attack_3_4_G = new P_Attack_3_4_G(this, StateMachine, playerData, "");
        Attack_3_5_G = new P_Attack_3_5_G(this, StateMachine, playerData, "");
        Attack_3_6_G = new P_Attack_3_6_G(this, StateMachine, playerData, "");
        Attack_3_7_G = new P_Attack_3_7_G(this, StateMachine, playerData, "");
        Attack_3_8_G = new P_Attack_3_8_G(this, StateMachine, playerData, "");

        #endregion

        #region Combo 4

        Attack_4_3_G = new P_Attack_4_3_G(this, StateMachine, playerData, "");
        Attack_4_4_G = new P_Attack_4_4_G(this, StateMachine, playerData, "");
        Attack_4_6_G = new P_Attack_4_6_G(this, StateMachine, playerData, "");
        Attack_4_7_G = new P_Attack_4_7_G(this, StateMachine, playerData, "");

        #endregion

        Anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<InputSystem>();
        AnimManager = GetComponent<AnimationManager>();
        Skill = GetComponent<SkillSystem>();
        IngameUi = FindObjectOfType<IngameUIHandler>();
        Health = FindObjectOfType<PlayerHealthBar>();

        instance = this;
    }

    void Start()
    {
        StateMachine.Initzialize(IdleState);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        canStartCombo = true;
        currentlyAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.PlayerIsDead)
        {
            StateMachine.ChangeState(DeadState);
            return;
        }

        playerData.normalDamage = Skill.GetCurrentStrength();

        if(objecte != null)
        {
            if (objecte.isInteracting)
            {
                provider.XYAxis = default;
                return;
            }
            else
            {
                provider.XYAxis = reference;
            }
        }



        if (IngameUIHandler.instance.EnablePauseMenu())
        {
            provider.XYAxis = default;
            return;
        }
        else
        {
            provider.XYAxis = reference;
        }

        StateMachine.CurrentState.LogicUpdate();

        Input.HandleAllInput();

        CheckLockOnEnemy();

        if (currentTarget != null)
            currentlyInLocking = true;
        else
            currentlyInLocking = false;

        velocity.x /= 1 + drag.x * Time.deltaTime;
        velocity.y /= 1 + drag.y * Time.deltaTime;
        velocity.z /= 1 + drag.z * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        CheckForEnemies();
    }

    private void LateUpdate()
    {
        Anim.SetBool("isGrounded", isGrounded);
        IsUsingRootMotion = Anim.GetBool("isUsingRootMotion");
        IsInteracting = Anim.GetBool("isInteracting");

        if (IsUsingRootMotion)
            Anim.applyRootMotion = true;
        else
            Anim.applyRootMotion = false;

        if (currentlyInLocking)
        {
            currentCam.gameObject.SetActive(false);
            lockOnCam.gameObject.SetActive(true);
        }
        else
        {
            lockOnCam.gameObject.SetActive(false);

            currentCam.gameObject.SetActive(true);
        }
    }
    #endregion

    #region Check Functions

    public void SavePos()
    {
        ES3.Save("playerPos", transform.position);
    }

    public void LoadPos()
    {
        Vector3 newPos = ES3.Load("playerPos", transform.position);
        transform.position = newPos;
    }

    public void CheckSurroundings()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, playerData.groundRadius, whatIsGround);
    }

    public void CheckForEnemies()
    {
        Collider[] collider = Physics.OverlapSphere(hitPoint.position, playerData.hitRadius, whatIsHitable);

        if (EnemyGotHit)
        {
            foreach (Collider item in collider)
            {
                IDamageable damageToEnemy = item.GetComponent<IDamageable>();

                if (damageToEnemy != null)
                {
                    damageToEnemy.Damage(playerData.normalDamage);

                }
            }
        }
    }

    private void CheckLockOnEnemy()
    {
        if (Input.LockOn)
        {
            Input.LockOnHasBeenUsed();
            HandleLockOn();
        }
        else if (Input.UnLockOn || currentTarget == null)
        {
            Input.UnLockOnHasBeenUsed();
            currentTarget = null;
            combatTarget.Clear();
        }
    }

    public void HandleLockOn()
    {
        float shortestDistanceToEnemy = Mathf.Infinity;

        Collider[] collider = Physics.OverlapSphere(transform.position, 26f);

        for (int i = 0; i < collider.Length; i++)
        {
            CombatTarget enemy = collider[i].GetComponent<CombatTarget>();

            if (enemy != null && enemy.curhealth > 0)
            {
                float distanceToTarget = Vector3.Distance(transform.position, enemy.transform.position);
            
                if (distanceToTarget <= playerData.maximumLockOnDistance)
                {
                    if (!combatTarget.Contains(enemy))
                    {
                        combatTarget.Add(enemy);
                    }
                }
            }
        }

        for (int k = 0; k < combatTarget.Count; k++)
        {
            float distanceFromTarget = Vector3.Distance(transform.position, combatTarget[k].transform.position);

            if (distanceFromTarget < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceFromTarget;
                currentTarget = combatTarget[k].lockOnTarget;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, playerData.hitRadius);
    }

    #endregion

    #region Apply Functions
    public void ApplyMovement(float movement)
    {
        float target = Mathf.Atan2(Input.Movement.x, Input.Movement.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref turningRefSpeed, playerData.turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        Vector3 moveDir = Quaternion.Euler(0, target, 0) * Vector3.forward;

        Controller.Move(moveDir * movement * Time.deltaTime);
    }

    public void ApplyGravityForce()
    {
        velocity.y += playerData.gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);
    }

    public void ApplyJumpForce(float amount)
    {
        //velocity.y += Mathf.Sqrt(-2f * amount * playerData.gravity);
        velocity.Set(velocity.x, Mathf.Sqrt(-2f * amount * playerData.gravity), velocity.z);
        Controller.Move(velocity * Time.deltaTime);
    }

    public void ApplyVelocity()
    {
        Controller.Move(velocity * Time.deltaTime);
    }

    public void ApplyDashForward()
    {
        velocity += Vector3.Scale(transform.forward,
            playerData.dashDistance * new Vector3(Mathf.Log(1f / (Time.deltaTime * drag.x + 1) / -Time.deltaTime), 0, Mathf.Log(1f / (Time.deltaTime * drag.x + 1) / -Time.deltaTime)));
    }

    public void ApplyRotationToTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, playerData.turnSpeed * Time.deltaTime);
    }

    public void AppplyKnockBack(Vector3 knockBackDirection, float knockBackAmount, float knockBackMultiplyer, int variableAmount)
    {
        StartCoroutine(_KnockBack(knockBackDirection, knockBackAmount, knockBackMultiplyer, variableAmount));
    }

    IEnumerator _KnockBack(Vector3 knockBackDirection, float knockBackAmount, float knockBackMultiplyer, int variableAmount)
    {
        KnockBack = true;
        StartCoroutine(_KnockBackForce(knockBackDirection, knockBackAmount, knockBackMultiplyer, variableAmount));
        yield return new WaitForSeconds(.1f);
        KnockBack = false;
    }

    IEnumerator _KnockBackForce(Vector3 knockBackDirection, float knockBackAmount, float knockBackMultiplyer, int variableAmount)
    {
        while (KnockBack)
        {
            currentTarget.GetComponentInParent<Rigidbody>().AddForce(knockBackDirection * (knockBackMultiplyer * 10), ForceMode.Impulse);
            yield return null;
        }
    }
    #endregion

    #region Declare Functions
    public void AnimHasFinished()
    {
        AnimationHasFinished = true;
    }
    public void AnimHasNotFinished()
    {
        AnimationHasFinished = false;
    }

    void CanDoCombo()
    {
        canCombo = true;
    }

    void CanDoNotCombo()
    {
        canCombo = false;
    }


    void CanStartCombo()
    {
        canStartCombo = true;
        currentlyAttacking = false;
    }

    public void EnemyGotHitTrue()
    {
        EnemyGotHit = true;
    }
    public void EnemyGotNotHitTrue()
    {
        EnemyGotHit = false;
    }

    void FootSteps()
    {
        if (isGrounded)
            footSteps.Play(transform.position);
    }

    void BleybladeSwing()
    {
        bleyBlade.Play(transform.position);
    }

    #endregion
}
