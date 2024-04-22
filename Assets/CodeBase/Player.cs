﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;

    private WeaponInventory _inventory;
    private WeaponShooter _shooter;
    private WeaponSwitcher _weaponSwitcher;

    public Transform WeaponPoint => _weaponPoint;

    public void Init(WeaponInventory inventory, WeaponShooter shooter, WeaponSwitcher weaponSwitcher, Weapon startWeapon)
    {
        _inventory = inventory;
        _shooter = shooter;
        _weaponSwitcher = weaponSwitcher;

        _shooter.SetWeapon(startWeapon);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooter.TryShoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _shooter.TryReload();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _shooter.SetWeapon(_weaponSwitcher.GetNextWeapon());
        }
    }
}