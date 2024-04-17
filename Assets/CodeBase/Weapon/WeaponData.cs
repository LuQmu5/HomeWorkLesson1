using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapons/Create Weapon Data", order = 54)]
public class WeaponData : ScriptableObject
{
    [SerializeField, Min(1)] private int _maxBulletsInClip;
    [SerializeField] private float _fireRate;
    [SerializeField, Min(0)] private float _baseDamage;
    [SerializeField] private float _baseReloadTime;
    [SerializeField, Min(0)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(1)] private int _bulletsPerShot = 1;
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0)] private float _spreadFactor = 1;

    public int MaxBulletsInClip => _maxBulletsInClip;
    public float FireRate => _fireRate;
    public float BaseDamage => _baseDamage;
    public float BaseReloadTime => _baseReloadTime;
    public float Distance => _distance;
    public int BulletsPerShot => _bulletsPerShot;   
    public bool UseSpread => _useSpread;
    public float SpreadFactor => _spreadFactor;
}