using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _damage;

    public void Launch(Vector3 startPosition, Vector3 direction, float damage, float speed)
    {
        transform.position = startPosition;
        _damage = damage;

        _rigidbody.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.ApplyDamage(_damage);
        }

        gameObject.SetActive(false);
    }
}
