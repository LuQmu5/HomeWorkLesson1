using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapons/Create Weapon Data", order = 54)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private int _maxBulletsInClip;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _baseDamage;
    [SerializeField] private float _baseReloadTime;

    public int MaxBulletsInClip => _maxBulletsInClip;
    public float FireRate => _fireRate;
    public float BaseDamage => _baseDamage;
    public float BaseReloadTime => _baseReloadTime;
}