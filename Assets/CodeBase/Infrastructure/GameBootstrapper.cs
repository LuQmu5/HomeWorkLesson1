using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerReputationDisplay _playerReputationDisplay;

    private void Awake()
    {
        PlayerReputation playerReputation = new PlayerReputation();

        _player.Construct(playerReputation);
        _playerReputationDisplay.Construct(playerReputation);
    }
}