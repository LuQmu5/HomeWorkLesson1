using System;
using System.Collections;
using UnityEngine;

public class Weapon : ObjectPool<Bullet>, IReloadable
{
    private WeaponView _weaponView;
    private ICoroutineRunner _coroutineRunner;

    private float _damage;
    private float _shotsPerSecond;
    private float _reloadTime;

    private int _bulletsPerShot;
    private int _maxBulletsCount;
    private int _currentBulletsCount;
    private float _bulletSpeed;

    private Coroutine _reloadingCoroutine;
    private Coroutine _shootDelayingCoroutine;

    public event Action Shoted;

    public float ReloadTime { get => _reloadTime; }
    public int MaxBullets { get => _maxBulletsCount; }
    public int CurrentBullets { get => _currentBulletsCount; }
    public bool CanShoot { get => _reloadingCoroutine == null && _shootDelayingCoroutine == null && _currentBulletsCount > 0; }

    public Weapon(WeaponStaticData data, ICoroutineRunner coroutineRunner, Transform container)
    {
        _weaponView = UnityEngine.Object.Instantiate(data.WeaponView, container);
        _coroutineRunner = coroutineRunner;

        _damage = data.Damage;
        _shotsPerSecond = data.ShotsPerSecond;
        _reloadTime = data.ReloadTime;

        _bulletsPerShot = data.BulletsPerShot;
        _maxBulletsCount = data.MaxBulletsCount;
        _currentBulletsCount = data.MaxBulletsCount;
        _bulletSpeed = data.BulletSpeed;

        InitPool(data.BulletPrefab);
    }

    public void Activate()
    {
        _weaponView.gameObject.SetActive(true);

        _reloadingCoroutine = null;
        _shootDelayingCoroutine = null;
    }

    public void Deactivate()
    {
        if (_reloadingCoroutine != null)
            _coroutineRunner.StopCoroutine(_reloadingCoroutine);

        if (_shootDelayingCoroutine != null)
            _coroutineRunner.StopCoroutine(_shootDelayingCoroutine);

        _weaponView.gameObject.SetActive(false);
    }

    public bool TryReload()
    {
        if (_reloadingCoroutine != null)
            return false;

        _weaponView.Reload();
        _reloadingCoroutine = _coroutineRunner.StartCoroutine(Reloading());

        return true;
    }

    public bool TryShoot()
    {
        if (CanShoot == false)
            return false;

        _weaponView.Shoot();

        foreach (Transform shootPoint in _weaponView.ShootPoints)
            LaunchBullet(shootPoint);

        _currentBulletsCount -= _bulletsPerShot;
        Shoted?.Invoke();

        _shootDelayingCoroutine = _coroutineRunner.StartCoroutine(ShootDelaying());

        return true;
    }

    private void LaunchBullet(Transform shootPoint)
    {
        Bullet bullet = GetItem();
        bullet.gameObject.SetActive(true);
        bullet.Launch(shootPoint.position, shootPoint.forward, _damage, _bulletSpeed);
    }

    private IEnumerator ShootDelaying()
    {
        int oneSecond = 1;

        yield return new WaitForSeconds(oneSecond / _shotsPerSecond);

        _shootDelayingCoroutine = null;
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(_reloadTime);

        _currentBulletsCount = _maxBulletsCount;
        _reloadingCoroutine = null;
    }
}
