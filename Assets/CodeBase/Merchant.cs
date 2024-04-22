using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Merchant : MonoBehaviour, IInteractableObject
{
    [SerializeField] private MerchantGood[] _goods;

    public string InteractMessage { get => "Press 'E' to trade"; }

    public void Interact(Player player)
    {
        StartTrade(player);
    }

    private void StartTrade(Player player)
    {
        var sellableGoods = _goods.Where(i => i.ReputationRequired <= player.Reputation.CurrentReputation);

        if (sellableGoods.Count() == 0)
        {
            Debug.Log("��� ������ ���� �������. ������� ��� ������� ���������...");
            return;
        }

        print("���, ��� � ���� ���� �������: ");

        foreach (var item in sellableGoods)
        {
            print($"{item.Name} : {item.Cost} �����");
        }
    }
}
