using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;

    private PlayerInventory _inventory;
    private Shooter _shooter;
    private WeaponSwitcher _weaponSwitcher;

    public Transform WeaponPoint => _weaponPoint;

    public void Construct(PlayerInventory inventory)
    {
        _inventory = inventory;
        _shooter = new Shooter();
        _weaponSwitcher = new WeaponSwitcher(_inventory, _shooter);

        _weaponSwitcher.SwitchWeapon();
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
            _weaponSwitcher.SwitchWeapon();
        }
    }
}