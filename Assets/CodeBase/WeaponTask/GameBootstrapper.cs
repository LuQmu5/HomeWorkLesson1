using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string WeaponsPath = "StaticData/Weapons";

    [SerializeField] private Player _player;
    [SerializeField] private BulletsDisplay _bulletsDisplay;

    private void Awake()
    {
        PlayerInventory playerInventory = new PlayerInventory(Resources.LoadAll<WeaponStaticData>(WeaponsPath), this, _player.WeaponPoint);
        Shooter playerShooter = new Shooter();
        WeaponSwitcher playerWeaponSwitcher = new WeaponSwitcher(playerInventory, playerShooter);
        Weapon playerStartWeapon = playerInventory.GetWeaponByIndex(0);

        _player.Construct(playerInventory, playerShooter, playerWeaponSwitcher, playerStartWeapon);
        _bulletsDisplay.Init(playerWeaponSwitcher, playerStartWeapon);
    }
}
