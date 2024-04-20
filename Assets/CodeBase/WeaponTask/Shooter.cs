using System;
using System.Collections;
using UnityEngine;

public class Shooter
{
    private Weapon _currentWeapon;

    public void SetWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public bool TryShoot()
    {
        if (_currentWeapon == null || _currentWeapon is not IShootable) 
            return false;

        return _currentWeapon.TryShoot();
    }

    public bool TryReload()
    {
        if (_currentWeapon == null || _currentWeapon is not IReloadable)
            return false;

        return _currentWeapon.TryReload();
    }
}
