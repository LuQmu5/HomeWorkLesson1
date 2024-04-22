using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory
{
    private readonly List<Weapon> _weapons = new List<Weapon>();

    public int WeaponsCount => _weapons.Count;

    public WeaponInventory(List<Weapon> weapons)
    {
        _weapons.AddRange(weapons);
    }

    public Weapon GetWeaponByIndex(int index)
    {
        if (index < 0 || index >= _weapons.Count)
            throw new IndexOutOfRangeException();

        return _weapons[index];
    }

    public void AddNewWeapon(Weapon weapon)
    {
        if (weapon == null)
            throw new NullReferenceException();

        _weapons.Add(weapon);
    }
}
