using System.Linq;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string GoodsPath = "StaticData/Goods";

    [SerializeField] private Player _player;
    [SerializeField] private PlayerReputationDisplay _playerReputationDisplay;
    [SerializeField] private Merchant[] _merchants;

    private MerchantGood[] _goods;

    private void Awake()
    {
        _goods = Resources.LoadAll<MerchantGood>(GoodsPath);

        PlayerReputation playerReputation = new PlayerReputation();
        PlayerReputationChecker playerReputationChecker = new PlayerReputationChecker(playerReputation);

        _player.Construct(playerReputation);
        _playerReputationDisplay.Construct(playerReputation);

        foreach (var merchant in _merchants)
        {
            merchant.Init(playerReputationChecker, _goods.Where(i => i.Type == merchant.GoodsType));
        }
    }
}