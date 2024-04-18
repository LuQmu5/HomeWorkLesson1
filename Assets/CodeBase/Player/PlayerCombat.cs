using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;

    public event Action<Weapon> WeaponChanged;

    private void Start()
    {
        SwitchWeapon(0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _currentWeapon.TryShoot();
        }

        if (Input.GetKey(KeyCode.R))
        {
            _currentWeapon.TryReload();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon(GetNextWeaponIndex());
        }
    }

    private void SwitchWeapon(int index)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.ResetState();
            _currentWeapon.gameObject.SetActive(false);
        }

        _currentWeapon = _weapons[index];
        _currentWeapon.gameObject.SetActive(true);

        WeaponChanged?.Invoke(_currentWeapon);
    }

    private int GetNextWeaponIndex()
    {
        if (_currentWeapon == null)
            throw new ArgumentNullException("No Current Weapon");

        int nextWeaponIndex = _weapons.IndexOf(_currentWeapon) + 1;

        if (nextWeaponIndex >= _weapons.Count)
            nextWeaponIndex = 0;

        return nextWeaponIndex;
    }
}