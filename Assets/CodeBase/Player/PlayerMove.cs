using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _jumpPower = 3;
    [SerializeField] private Transform _legsPoint;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _controller;
    private Vector3 _currentVelocity;
    private bool _onGround;

    private const float GroundDistance = 0.2f;
    private const float Gravity = -9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _onGround = Physics.CheckSphere(_legsPoint.position, GroundDistance, _groundMask);
    }

    private void Update()
    {
        if (_onGround && _currentVelocity.y < 0)
        {
            _currentVelocity.y = Gravity;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _currentVelocity.y -= Gravity * Gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && _onGround)
        {
            _currentVelocity.y = Mathf.Sqrt(_jumpPower * -2f * Gravity);
        }

        _controller.Move(move * _movementSpeed * Time.deltaTime);
        _controller.Move(_currentVelocity * Time.deltaTime);
    }
}
