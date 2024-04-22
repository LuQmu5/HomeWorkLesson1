using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Merchant : MonoBehaviour, IInteractableObject
{
    [SerializeField] private GoodTypes _goodsType;

    private List<MerchantGood> _sellingGoods;
    private PlayerReputationChecker _playerReputationChecker;

    public GoodTypes GoodsType => _goodsType;
    public string InteractMessage { get => "Press 'E' to trade"; }

    public void Init(PlayerReputationChecker playerReputationChecker, IEnumerable<MerchantGood> goods)
    {
        _playerReputationChecker = playerReputationChecker;

        _sellingGoods = new List<MerchantGood>();
        _sellingGoods.AddRange(goods);
    }

    public void Interact(Player player)
    {
        StartTrade(player);
    }

    private void StartTrade(Player player)
    {
        foreach (var item in _sellingGoods)
        {
            if (_playerReputationChecker.IsReputationEnough(item.ReputationRequired))
                print($"{item.Name} : {item.Cost} тенге");
        }
    }
}
