using TMPro;
using UnityEngine;

public class BulletsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private WeaponSwitcher _playerWeaponSwitcher;
    private Weapon _currentPlayerWeapon;

    public void Init(WeaponSwitcher playerWeaponSwitcher, Weapon playerStartWeapon)
    {
        _playerWeaponSwitcher = playerWeaponSwitcher;
        _playerWeaponSwitcher.WeaponSwitched += OnWeaponSwitched;

        SubscribeToNewWeaponShoot(playerStartWeapon);
    }

    private void SubscribeToNewWeaponShoot(Weapon playerStartWeapon)
    {
        if (_currentPlayerWeapon != null)
            _currentPlayerWeapon.Shoted -= OnWeaponShoted;

        _currentPlayerWeapon = playerStartWeapon;
        _currentPlayerWeapon.Shoted += OnWeaponShoted;
        _text.text = $"{_currentPlayerWeapon.CurrentBullets}/{_currentPlayerWeapon.MaxBullets}";
    }

    private void OnDestroy()
    {
        _playerWeaponSwitcher.WeaponSwitched -= OnWeaponSwitched;

        if (_currentPlayerWeapon != null)
            _currentPlayerWeapon.Shoted -= OnWeaponShoted;
    }

    private void OnWeaponSwitched(Weapon weapon)
    {
        SubscribeToNewWeaponShoot(weapon);
    }

    private void OnWeaponShoted()
    {
        _text.text = $"{_currentPlayerWeapon.CurrentBullets}/{_currentPlayerWeapon.MaxBullets}";
    }
}
