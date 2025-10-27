using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _playerCollider;
    private Animator _animator;
    
    private Vector2 _moveInput;
    private InputAction _moveAction;
    [SerializeField] private float _playerSpeed = 10;
    
    [SerializeField] private float _jumpHeight = 5;
    private InputAction _jumpAction;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];

    }

    void Update()
    {
        
        _moveInput = _moveAction.ReadValue<Vector2>();
        Movement();
    }

    void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_playerSpeed * _moveInput.x, _rigidBody.linearVelocity.y);
    }

    void Movement()
    {
        if (_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if (_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
    
    void Jump()
    {
        _rigidBody.AddForce(transform.up * _jumpHeight, ForceMode2D.Impulse);
    }
}
