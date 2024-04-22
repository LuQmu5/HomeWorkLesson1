using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Create New Ball Data", fileName = "Ball Data", order = 54)]
public class BallData : ScriptableObject
{
    [SerializeField] private BallColors _color;
    [SerializeField] private Material _material;
    [SerializeField] private int _number;

    public BallColors Color => _color;
    public BallNumbersType NumberType => _number % 2 == 0 ? BallNumbersType.Even : BallNumbersType.Odd;
    public Material Material => _material;
    public int Number => _number;
}
