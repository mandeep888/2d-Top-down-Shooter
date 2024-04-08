using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _screenBorder;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmootheVelocity;
    private Camera _camera;
    private Animator _animator;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
        SetAnimation();
    }
    private void SetAnimation(){
        bool isMoving = _movementInput != Vector2.zero;
        _animator.SetBool("IsMoving" , isMoving);
    }
    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmootheVelocity, 0.1f);
        _rigidbody.velocity = _smoothedMovementInput * _speed;
        PreventPlayerGoingOffscreen();
    }

    private void PreventPlayerGoingOffscreen(){
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x <_screenBorder && _rigidbody.velocity.x <0)|| (screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidbody.velocity.x >0))
        {
            _rigidbody.velocity = new Vector2(0 , _rigidbody.velocity.y);
        }
        if ((screenPosition.y < _screenBorder && _rigidbody.velocity.y <0)|| (screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidbody.velocity.y >0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,0 );
        }
    }
    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
