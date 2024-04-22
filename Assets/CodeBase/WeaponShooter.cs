public class WeaponShooter
{
    private Weapon _currentWeapon;

    public Weapon CurrentWeapon => _currentWeapon;

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

        return ((IReloadable)_currentWeapon).TryReload();
    }
}
