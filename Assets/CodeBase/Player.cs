using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerReputation _reputation;

    public PlayerReputation Reputation => _reputation;

    public void Construct(PlayerReputation reputation)
    {
        _reputation = reputation;
    }
}
