using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Data/Weapons/Create Weapon Data", order = 54)]
public class WeaponStaticData : ScriptableObject
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _damage;
    [SerializeField] private int _maxBulletsCount;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _reloadTime;

    public float FireRate => _fireRate;
    public float Damage => _damage;
    public int MaxBulletsCount => _maxBulletsCount;
    public Bullet BulletPrefab => _bulletPrefab;
    public WeaponView WeaponView => _weaponView;
    public float BulletSpeed => _bulletSpeed;
    public float ReloadTime => _reloadTime;
}
