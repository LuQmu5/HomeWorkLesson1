using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private const string WeaponsPath = "StaticData/Weapons";
    private const string PlayerPath = "Player";

    private void Awake()
    {
        Player player = Resources.Load<Player>(PlayerPath);
        PlayerInventory playerInventory = new PlayerInventory(Resources.LoadAll<WeaponStaticData>(WeaponsPath), this, player.WeaponPoint);

        player.Construct(playerInventory);
    }
}
