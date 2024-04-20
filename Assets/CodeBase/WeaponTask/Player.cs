using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInventory _inventory;

    public void Init(PlayerInventory inventory)
    {
        _inventory = inventory;
    }
}