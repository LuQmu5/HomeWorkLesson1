using System;
using System.Collections;
using UnityEngine;

public class Shotgun : Weapon, IReloadable
{
    private int _currentBulletsCount;
    private int _maxBulletsCount;
    private float _reloadTime;
    private int _bulletsPerShot;
    private Coroutine _reloadingCoroutine;

    public event Action Reloaded;

    public Shotgun(WeaponData data, Transform container, ICoroutineRunner coroutineRunner) : base(data, container, coroutineRunner)
    {
        _bulletsPerShot = data.BulletsPerShot;
        _maxBulletsCount = data.MaxBulletsCount;
        _currentBulletsCount = data.MaxBulletsCount;
        _reloadTime = data.ReloadTime;
    }

    public override bool CanShoot => _currentBulletsCount >= _bulletsPerShot && ShootDelayingCoroutine == null;
    public override int MaxBullets => _maxBulletsCount;
    public override int CurrentBullets => _currentBulletsCount;
    public float ReloadTime => _reloadTime;

    public bool TryReload()
    {
        if (_reloadingCoroutine != null)
            return false;

        _reloadingCoroutine = CoroutineRunner.StartCoroutine(Reloading());

        return true;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        if (_reloadingCoroutine != null)
            CoroutineRunner.StopCoroutine(_reloadingCoroutine);
    }

    protected override void PerformShot()
    {
        foreach (var shootPoint in View.ShootPoints)
        {
            Bullet bullet = GetItem();
            bullet.gameObject.SetActive(true);
            bullet.Launch(shootPoint.position, shootPoint.forward, Data.Damage, Data.BulletSpeed);
        }

        _currentBulletsCount -= _bulletsPerShot;
        View.PerformShot();
        OnShoted();
    }

    private IEnumerator Reloading()
    {
        while (_currentBulletsCount < _maxBulletsCount)
        {
            yield return new WaitForSeconds(ReloadTime);

            _currentBulletsCount++;
            Reloaded?.Invoke();
        }

        _reloadingCoroutine = null;
    }
}