using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _Speed = 30f;

    PlayerInput _Input;

    Vector2 _Movement;

    Rigidbody2D _RigidBody;

    private void Awake()
    {
        _Input = new PlayerInput();
        _RigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _Input.Enable();

        _Input.Gameplay.Movement.performed += OnMovement;
        _Input.Gameplay.Movement.canceled += OnMovement;

    }
    
    private void OnDisable()
    {
        _Input.Disable();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _Movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _RigidBody.AddForce(_Movement * _Speed);
        //_RigidBody.velocity = _Movement * _Speed;
    }
}
