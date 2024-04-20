using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string WeaponsPath = "StaticData/Weapons";

    [SerializeField] private Player _player;

    private void Awake()
    {
        PlayerInventory playerInventory = new PlayerInventory(Resources.LoadAll<WeaponStaticData>(WeaponsPath), this, _player.WeaponPoint);

        _player.Construct(playerInventory);
    }
}
