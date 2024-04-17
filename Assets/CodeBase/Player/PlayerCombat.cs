using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    public event Action<Weapon> WeaponChanged;

    private void Start()
    {
        WeaponChanged?.Invoke(_currentWeapon);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _currentWeapon.Shoot();
        }

        if (Input.GetKey(KeyCode.R))
        {
            _currentWeapon.Reload();
        }
    }
}