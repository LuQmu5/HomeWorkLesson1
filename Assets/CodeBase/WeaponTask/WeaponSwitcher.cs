using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher
{
    private readonly PlayerInventory _inventory;
    private readonly Shooter _shooter;

    private int _currentWeaponIndex = -1;
    private Weapon _currentWeapon;

    public WeaponSwitcher(PlayerInventory inventory, Shooter shooter)
    {
        _inventory = inventory;
        _shooter = shooter;
    }

    public void SwitchWeapon()
    {
        if (_currentWeapon != null)
            _currentWeapon.Deactivate();

        _currentWeaponIndex++;

        if (_currentWeaponIndex >= _inventory.WeaponsCount)
            _currentWeaponIndex = 0;

        if (_inventory.TryGetWeaponByIndex(out _currentWeapon, _currentWeaponIndex))
        {
            _currentWeapon.Activate();
            _shooter.SetWeapon(_currentWeapon);
        }
    }
}
