using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Create New Ball Data", fileName = "Ball Data", order = 54)]
public class BallData : ScriptableObject
{
    [SerializeField] private BallTypes _ballType;
    [SerializeField] private Material _material;

    public BallTypes BallType => _ballType;
    public Material Material => _material;
}
