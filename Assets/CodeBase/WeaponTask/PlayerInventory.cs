using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private readonly List<Weapon> _weapons = new List<Weapon>();

    public int WeaponsCount => _weapons.Count;

    public PlayerInventory(WeaponStaticData[] weaponData, ICoroutineRunner coroutineRunner, Transform container)
    {
        foreach (WeaponStaticData data in weaponData)
            _weapons.Add(new Weapon(data, coroutineRunner, container));
    }

    public bool TryGetWeaponByIndex(out Weapon weapon, int index)
    {
        weapon = null;

        if (index < 0 || index >= _weapons.Count)
            return false;

        weapon = _weapons[index];

        return true;
    }
}
