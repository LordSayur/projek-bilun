using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private Animator animator;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        playerInput.UpdateInput();
    }

    void FixedUpdate()
    {
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Turning(movementDirection);

        Animate();
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
}
