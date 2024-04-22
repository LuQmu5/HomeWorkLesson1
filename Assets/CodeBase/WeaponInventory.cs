﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory
{
    private readonly List<Weapon> _weapons = new List<Weapon>();

    public int WeaponsCount => _weapons.Count;

    public WeaponInventory(WeaponStaticData[] weaponData, ICoroutineRunner coroutineRunner, Transform container)
    {
        foreach (WeaponStaticData data in weaponData)
            _weapons.Add(new Weapon(data, coroutineRunner, container));
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