using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapons/Create Weapon Data", order = 54)]
public class WeaponData : ScriptableObject
{
    [SerializeField, Min(1)] private float _shotsPerSecond;
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(1)] private int _maxBulletsCount;
    [SerializeField, Min(0)] private int _bulletsPerShot;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField, Min(0)] private float _bulletSpeed;
    [SerializeField, Min(0)] private float _reloadTime;

    public float ShotsPerSecond => _shotsPerSecond;
    public float Damage => _damage;
    public int MaxBulletsCount => _maxBulletsCount;
    public Bullet BulletPrefab => _bulletPrefab;
    public WeaponView WeaponView => _weaponView;
    public float BulletSpeed => _bulletSpeed;
    public float ReloadTime => _reloadTime;
    public int BulletsPerShot => _bulletsPerShot;
}
