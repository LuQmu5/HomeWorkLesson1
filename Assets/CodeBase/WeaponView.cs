using System;
using UnityEngine;

// тут будут свистоперделки
public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform[] _shootPoints;

    public Transform[] ShootPoints => _shootPoints;

    public void Shoot()
    {
        Debug.Log("Pah!");
    }

    public void Reload()
    {
        Debug.Log("Reloading");
    }
}