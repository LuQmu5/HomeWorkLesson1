using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;

    private PlayerInventory _inventory;
    private Shooter _shooter;
    private WeaponSwitcher _weaponSwitcher;

    public Transform WeaponPoint => _weaponPoint;

    public void Construct(PlayerInventory inventory, Shooter shooter, WeaponSwitcher weaponSwitcher, Weapon startWeapon)
    {
        _inventory = inventory;
        _shooter = shooter;
        _weaponSwitcher = weaponSwitcher;

        _shooter.SetWeapon(startWeapon);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _shooter.TryShoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _shooter.TryReload();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponSwitcher.SwitchToNextWeapon();
        }
    }
}