using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    [SerializeField] private LayerMask _hittableMask;

    private Vector3 _direction;
    private float _damage;

    public void Init(Vector3 direction, float damage)
    {
        _direction = direction.normalized;
        _damage = damage;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, Time.deltaTime * _speed);
        CreateRaycast();
    }

    private void CreateRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 1, _hittableMask))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IHealth health))
            {
                health.ApplyDamage(_damage);
                print(health.Current);
            }

            Destroy(gameObject);
        }
    }
}
