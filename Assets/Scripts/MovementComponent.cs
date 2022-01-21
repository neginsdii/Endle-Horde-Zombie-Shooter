using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float WalkSpeed = 5;
    [SerializeField]
    private float runSpeed = 10;
    [SerializeField]
    private float JumpForce = 5;
    
    //Components
    private PlayerController playerController;
    private Rigidbody rigidbody;
    private Animator PlayerAnimator;

    Vector2 inputVector = Vector2.zero;
    Vector3 MoveDirection = Vector3.zero;

    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("isHashing");

    private void Awake()
	{

        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
    }
    void Start()
    {
    }

    void Update()
    {
        if (playerController.isJumping) return;
        if (!(inputVector.magnitude > 0)) MoveDirection = Vector3.zero;
     
        MoveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
        float currentSpeed = playerController.isRunning ? runSpeed : WalkSpeed;
        Vector3 MovementDirection = MoveDirection * currentSpeed * Time.deltaTime;
        transform.position += MovementDirection;
    }

    public void OnMovement(InputValue value)
	{
        inputVector = value.Get<Vector2>();
        PlayerAnimator.SetFloat(movementXHash, inputVector.x);
        PlayerAnimator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnJump(InputValue value)
    {
        playerController.isJumping = value.isPressed;
        rigidbody.AddForce((transform.up + MoveDirection) * JumpForce, ForceMode.Impulse);
        PlayerAnimator.SetBool(isJumpingHash, playerController.isJumping);

    }

    public void OnRun(InputValue value)
    {
        playerController.isRunning = value.isPressed;
        PlayerAnimator.SetBool(isRunningHash, playerController.isRunning);
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (!collision.gameObject.CompareTag("Ground") && !playerController.isJumping) return;
		
        playerController.isJumping = false;
        PlayerAnimator.SetBool(isJumpingHash, playerController.isJumping);

    }

}
