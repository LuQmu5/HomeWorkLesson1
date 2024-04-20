using System;
using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Weapon _currentWeapon;

    public void SetNewWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
