using System;
using System.Collections;
using UnityEngine;

public class Shooter
{
    private Weapon _currentWeapon;

    public void SetNewWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public bool TryShoot()
    {
        if (_currentWeapon == null) 
            return false;

        return _currentWeapon.TryShoot();
    }

    public bool TryReload()
    {
        if (_currentWeapon == null)
            return false;

        return _currentWeapon.TryReload();
    }
}
