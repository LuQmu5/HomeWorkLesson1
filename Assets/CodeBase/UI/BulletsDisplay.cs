using System;
using TMPro;
using UnityEngine;

public class BulletsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayerCombat _playerCombat;

    private Weapon _currentWeapon;

    private void OnEnable()
    {
        _playerCombat.WeaponChanged += OnPlayerWeaponChanged;
    }

    private void OnDisable()
    {
        _playerCombat.WeaponChanged -= OnPlayerWeaponChanged;
    }

    private void OnPlayerWeaponChanged(Weapon newWeapon)
    {
        if (_currentWeapon != null)
            _currentWeapon.BulletsChanged -= OnBulletsChanged;

        _currentWeapon = newWeapon;
        newWeapon.BulletsChanged += OnBulletsChanged;
    }

    private void OnBulletsChanged(int current, int max)
    {
        _text.text = $"{current}/{max}";
    }
}