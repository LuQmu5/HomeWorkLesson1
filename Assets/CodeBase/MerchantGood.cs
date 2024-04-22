using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Items/Create Merchant Good", fileName = "New Merchant Good", order = 54)]
public class MerchantGood : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private int _reputationRequired;
    [SerializeField] private GoodTypes _type;

    public string Name => _name;
    public int Cost => _cost;
    public int ReputationRequired => _reputationRequired;
    public GoodTypes Type => _type;
}
