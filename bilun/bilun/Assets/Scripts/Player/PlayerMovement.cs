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
        Vector3 direction = GetMovementDirection();

        Vector3 movement = direction * moveSpeed;

        playerRigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, angle, 0);

            animator.SetFloat("speed", direction.sqrMagnitude);
        }
    }

    Vector3 GetMovementDirection()
    {
        Vector3 movementDirection = new Vector3(playerInput.MoveInput.x, 0, playerInput.MoveInput.y);

        if (movementDirection.sqrMagnitude > 1f)
        {
            movementDirection.Normalize();
        }

        return movementDirection;
    }
}
