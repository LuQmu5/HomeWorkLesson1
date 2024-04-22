using System;

public class WeaponSwitcher
{
    private readonly WeaponInventory _inventory;
    private readonly WeaponShooter _shooter;

    private int _currentWeaponIndex;
    private Weapon _currentWeapon;

    public event Action<Weapon> WeaponSwitched;

    public WeaponSwitcher(WeaponInventory inventory, WeaponShooter shooter)
    {
        _inventory = inventory;
        _shooter = shooter;
    }

    public void SwitchToNextWeapon()
    {
        if (_currentWeapon != null)
            _currentWeapon.Deactivate();

        _currentWeaponIndex++;

        if (_currentWeaponIndex >= _inventory.WeaponsCount)
            _currentWeaponIndex = 0;

        _currentWeapon = _inventory.GetWeaponByIndex(_currentWeaponIndex);
        _currentWeapon.Activate();
        _shooter.SetWeapon(_currentWeapon);

        WeaponSwitched?.Invoke(_currentWeapon);
    }
}
