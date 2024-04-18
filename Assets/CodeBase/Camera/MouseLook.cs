using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _sensetivity = 100;
    [SerializeField] private Transform _playerBody;

    private float _rotationY = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity * Time.deltaTime;

        _rotationY -= mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -45f, 45f);

        transform.localRotation = Quaternion.Euler(_rotationY, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
