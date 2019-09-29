using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashForce = 20f;
    public float jumpForce = 5f;
    public float gravityForce = 1f;

    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private Animator animator;
    private CapsuleCollider capsuleCollider;

    private LayerMask groundLayer;
    private bool isDashing = false;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        playerInput.UpdateInput();
    }

    void FixedUpdate()
    {
        Vector3 movementDirection = GetMovementDirection();

        HandleAirBorne();

        Dash();

        Move(movementDirection);

        Turning(movementDirection);

        Animate();
    }

    // Handle Dashing
    void Dash()
    {
        if (playerInput.DashInput && !isDashing)
            StartCoroutine(Dashing());
    }

    // Dashing towards current forward direction
    IEnumerator Dashing()
    {
        isDashing = true;
        playerRigidbody.AddForce(dashForce * transform.forward, ForceMode.Impulse);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        playerRigidbody.velocity = Vector3.zero;
    }

    // Move towards given direction
    void Move(Vector3 direction)
    {
        Vector3 movement = direction * moveSpeed;

        playerRigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }

    //  Rotate towards given direction
    void Turning(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
    }

    //  Animate Character
    void Animate()
    {
        if (playerInput.MoveInput.sqrMagnitude > 0)
        {
            animator.SetFloat("speed", playerInput.MoveInput.sqrMagnitude, 0.1f, Time.deltaTime);
        } else {
            animator.SetFloat("speed", 0);
        }
    }
    
    //  Handle air movement
    void HandleAirBorne ()
    {
        if (IsGrounded())
        {
            Jump();
        } else {
            ApplyGravity();
        }
    }

    //  Apply jump force to player
    void Jump()
    {
        if (playerInput.JumpInput)
            playerRigidbody.AddForce(jumpForce * transform.up, ForceMode.Impulse);
    }

    //  Apply extra gravity force to player
    void ApplyGravity()
    {
        playerRigidbody.AddForce(-gravityForce * transform.up);
    }

    //  Get movement direction based on camera direction and normalized
    Vector3 GetMovementDirection()
    {
        Vector3 movementDirection = new Vector3(playerInput.MoveInput.x, 0, playerInput.MoveInput.y);

        movementDirection = Camera.main.transform.TransformDirection(movementDirection);
        movementDirection.y = 0;

        if (movementDirection.sqrMagnitude > 1f)
        {
            movementDirection.Normalize();
        }

        return movementDirection;
    }
  
    //  Check if player is grounded
    bool IsGrounded()
    {
        float radius = capsuleCollider.radius;
        Vector3 position = transform.position + Vector3.up * radius;

        return Physics.CheckSphere(position, radius, groundLayer);
    }
}
