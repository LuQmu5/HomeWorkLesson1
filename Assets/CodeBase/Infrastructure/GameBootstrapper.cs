using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Construct(new PlayerReputation());
    }
}