using UnityEngine;

public class BootsTrapper_WeaponTask : MonoBehaviour, ICoroutineRunner
{
    private const string WeaponsPath = "StaticData/Weapons";

    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Init(new PlayerInventory(Resources.LoadAll<WeaponStaticData>(WeaponsPath)));
    }
}
