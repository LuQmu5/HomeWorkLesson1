using UnityEngine;

public class AngryMerchant : Merchant
{
    protected override void StartTrade()
    {
        Debug.Log("Ya tebya ne zval... idi na...");
    }
}
