using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string WeaponsPath = "StaticData/Weapons/";
    private const string Plasmagun = nameof(Plasmagun);
    private const string Railgun = nameof(Railgun);
    private const string Shotgun = nameof(Shotgun);

    [SerializeField] private Player _player;
    [SerializeField] private BulletsDisplay _bulletsDisplay;

    private void Awake()
    {
        WeaponData plasmagunData = Resources.Load<WeaponData>(WeaponsPath + Plasmagun);
        WeaponData RailgunData = Resources.Load<WeaponData>(WeaponsPath + Railgun);
        WeaponData ShotgunData = Resources.Load<WeaponData>(WeaponsPath + Shotgun);

        WeaponInventory playerInventory = new WeaponInventory(new List<Weapon>()
        {
            new Plasmagun(plasmagunData, _player.WeaponPoint, this),
            new Railgun(RailgunData, _player.WeaponPoint, this),
            new Shotgun(ShotgunData, _player.WeaponPoint, this),
        });

        WeaponShooter playerShooter = new WeaponShooter();
        WeaponSwitcher playerWeaponSwitcher = new WeaponSwitcher(playerInventory, playerShooter);
        Weapon playerStartWeapon = playerWeaponSwitcher.GetNextWeapon();

        _player.Init(playerInventory, playerShooter, playerWeaponSwitcher, playerStartWeapon);
        _bulletsDisplay.Init(playerWeaponSwitcher, playerStartWeapon);
    }
}
