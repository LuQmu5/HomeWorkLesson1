using System;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    public Transform ShootPoint => _shootPoint;

    public void Shoot()
    {
        Debug.Log("Pah!");
    }

    public void Reload()
    {
        Debug.Log("Reloading");
    }
}