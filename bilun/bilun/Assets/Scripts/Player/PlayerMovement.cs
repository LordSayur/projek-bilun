using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _playerInput.UpdateInput();
    }

    void FixedUpdate()
    {
        Vector3 movement = GetMovementDirection() * moveSpeed;

        _rigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }

    Vector3 GetMovementDirection()
    {
        Vector3 movementDirection = new Vector3(_playerInput.MoveInput.x, 0, _playerInput.MoveInput.y);

        if (movementDirection.sqrMagnitude > 1f)
        {
            movementDirection.Normalize();
        }

        return movementDirection;
    }
}
