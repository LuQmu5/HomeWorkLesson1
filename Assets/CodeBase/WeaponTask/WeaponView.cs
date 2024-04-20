using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public Transform ShootPoint => _shootPoint;
}