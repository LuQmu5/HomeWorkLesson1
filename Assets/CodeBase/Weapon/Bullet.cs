using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100;

    private Vector3 _direction;

    public void Init(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
