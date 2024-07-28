using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Transform _groundCheck;

    [Header("Gravity Parameters")]
    [SerializeField] private float _pullingVelocity = 20f;
    [SerializeField] private LayerMask _groundMask;

    [Header("Movement Speed Parameters")]
    [SerializeField] private float _speed = 15;

    [Header("Sensivity Parameters")]
    [SerializeField] private float _mouseSensivity = 15;

    private PlayerInputActions _playerInputActions;
    private CharacterController _characterController;

    private float _xRotation = 0;
    private float _currentPullingVelocity;
    private bool _isGrounded;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        _playerInputActions.PlayerMap.Enable();
    }

    private void Update()
    {
        RotateCharacter();
        MoveCharacter();
        CreateGravity();
    }

    private void RotateCharacter()
    {
        float mouseY = _playerInputActions.PlayerMap.MouseY.ReadValue<float>() * _mouseSensivity * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        _mainCamera.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        float mouseX = _playerInputActions.PlayerMap.MouseX.ReadValue<float>() * _mouseSensivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void MoveCharacter()
    {
        Vector2 inputVector = _playerInputActions.PlayerMap.Movement.ReadValue<Vector2>();
        Vector3 movement = transform.right * inputVector.x + transform.forward * inputVector.y;
        if (_isGrounded) _characterController.Move(movement * _speed * Time.deltaTime);
    }

    private void CreateGravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _characterController.radius, _groundMask);

        if (_isGrounded && _currentPullingVelocity > 2)
        {
            float constantPullingVelocity = 2; //for smoother transition
            _currentPullingVelocity = constantPullingVelocity;
        }

        _currentPullingVelocity += _pullingVelocity * Time.deltaTime;
        Vector3 pullingVelocityFormula = Vector3.down * _currentPullingVelocity * Time.deltaTime; //it is doubly multiplied by time because of how physics equation for gravity works
        _characterController.Move(pullingVelocityFormula);
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerInputActions.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _playerInputActions.PlayerMap.Disable();
    }
}
