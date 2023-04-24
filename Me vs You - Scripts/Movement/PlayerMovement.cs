using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  //  // Movement
  //  [Space][Header("Movement")]
  //  [SerializeField] float movementSpeed = 5f;
  //  [SerializeField] float turnSmoothTime = .05f;
  //  [SerializeField] float groundRadius = .3f;
  //
  //      //-- IngameStuff
  //  [SerializeField] Transform groundCheck = null;
  //  [SerializeField] LayerMask whatIsGround = default;
  //
  //  // Jumping
  //  [Space]
  //  [Header("Gravity")]
  //  [SerializeField] int jumpsInTotal = 2;
  //  [SerializeField] float jumpForce = 5f;
  //  [SerializeField] float gravity = -50f;
  //
  //  // dodge
  //  [Space]
  //  [SerializeField] float dashDistance;
  //  [SerializeField] float timerBtwDash = 2f;
  //  [SerializeField] Vector3 drag;
  //   
  //
  //  CharacterController controller;
  //  AnimationManager animationManager;
  //  Animator anim;
  //  Camera cam;
  //
  //  [HideInInspector] public Vector3 velocity;
  //
  //  float turningRefSpeed;
  //  float timerToDash = Mathf.Infinity;
  //
  //  int maxJumps = 0;
  //
  //  bool isGrounded;
  //  bool isRunning;
  //  bool canJump = true;
  //  [HideInInspector]
  //  public bool canMove = true;
  //  
  //  public bool isUsingRootMotion;
  //  public bool isInteracting;
  //
  //  private void Awake()
  //  {
  //      animationManager = GetComponent<AnimationManager>();
  //      controller = GetComponent<CharacterController>();
  //      anim = GetComponent<Animator>();
  //      cam = Camera.main;
  //  }
  //
  //  void Start()
  //  {
  //      maxJumps = jumpsInTotal;
  //      Cursor.lockState = CursorLockMode.Locked;
  //      Cursor.visible = false;
  //      
  //  }
  //
  //  void Update()
  //  {
  //      UpdateAnimation();
  //      CheckSurroundings();
  //
  //      ApplyRootMotion();
  //
  //      if (isInteracting) return;
  //      ApplyDashGround();
  //      //ApplyDashAttack();
  //      ApplyMovement();
  //      ApplyJump();
  //  }
  //
  //  private void ApplyRootMotion()
  //  {
  //      if (isUsingRootMotion)
  //          anim.applyRootMotion = true;
  //      else
  //          anim.applyRootMotion = false;
  //  }
  //
  //  void LateUpdate()
  //  {
  //      isInteracting = anim.GetBool("isInteracting");
  //      isUsingRootMotion = anim.GetBool("isUsingRootMotion");
  //  }
  //
  //  void CheckSurroundings()
  //  {
  //      isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
  //  }
  //
  //  private void ApplyMovement()
  //  {
  //      float inputH = Input.GetAxisRaw("Horizontal");
  //      float inputV = Input.GetAxisRaw("Vertical");
  //
  //      Vector3 direction = new Vector3(inputH, 0, inputV).normalized;
  //
  //      if (isGrounded && velocity.y < 0)
  //      {
  //              velocity.y = -2f;
  //          }
  //
  //      if (direction.magnitude > 0.1f && canMove)
  //      {
  //          float target = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
  //          float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref turningRefSpeed, turnSmoothTime);
  //          transform.rotation = Quaternion.Euler(0, angle, 0);
  //
  //          Vector3 moveDir = Quaternion.Euler(0, target, 0) * Vector3.forward;
  //
  //          if(!anim.applyRootMotion)
  //              controller.Move(moveDir * movementSpeed * Time.deltaTime);
  //      }
  //
  //      isRunning = direction.magnitude > 0.1f && isGrounded ? true : false;
  //
  //  }
  //
  //  void ApplyJump()
  //  {
  //      velocity.y += gravity * Time.deltaTime;
  //
  //     // if(InputSystem.instance.jump.GetKeyDown() && isGrounded && canJump)
  //     // {
  //     //     velocity.y += Mathf.Sqrt(-2f * jumpForce * gravity);
  //     // }
  //      controller.Move(velocity * Time.deltaTime);
  //  }
  //
  //  void ApplyDashGround()
  //  {
  //      timerToDash += Time.deltaTime;
  //      if(timerToDash > timerBtwDash)
  //      {
  //        //  if (InputSystem.instance.dodge.GetKeyDown() && isGrounded)
  //        //  {
  //        //      animationManager.PlayTargetAnimation("Dodge", true, true);
  //        //
  //        //     // timerToDash = 0;
  //        //     // velocity += Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * drag.x + 1)) / -Time.deltaTime)
  //        //     //     , 0,
  //        //     //     (Mathf.Log(1f / (Time.deltaTime * drag.z + 1)) / -Time.deltaTime)));
  //        //
  //        //  }
  //      }
  //
  //      velocity.x /= 1 + drag.x * Time.deltaTime;
  //      velocity.y /= 1 + drag.y * Time.deltaTime;
  //      velocity.z /= 1 + drag.z * Time.deltaTime;
  //
  //  }
  //
  //  void ApplyDashAttack()
  //  {
  //      timerToDash += Time.deltaTime;
  //      if (timerToDash > timerBtwDash)
  //      {
  //          if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
  //          {
  //              animationManager.PlayTargetAnimation("Dash", true, true);
  //
  //          }
  //      }
  //  }
  //
  //  void CanMove()
  //  {
  //      canMove = true;
  //  }
  //
  //  void CanNotMove()
  //  {
  //      canMove = false;
  //  }
  //
  //  void UpdateAnimation()
  //  {
  //      anim.SetBool("isRunning", isRunning);
  //      anim.SetFloat("movementVelocityY", velocity.y);
  //      anim.SetBool("isGrounded", isGrounded);
  //  }
}
