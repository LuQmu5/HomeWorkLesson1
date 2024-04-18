using UnityEngine;

public class DestroyableObstacle : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public float Max { get => _maxHealth; set => _maxHealth = value; }
    public float Current { get => _currentHealth; set => _currentHealth = value; }

    public void ApplyDamage(float amount)
    {
        Current -= amount;

        if (Current <= 0)
            gameObject.SetActive(false);
    }
}
