using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _data;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Bullet _bulletPrefab;

    private Coroutine _reloadingCoroutine;
    private Coroutine _internalReloadingCoroutine;
    private int _currentBullets;

    public event UnityAction<int, int> BulletsChanged;

    private void Start()
    {
        _currentBullets = _data.MaxBulletsInClip;
        BulletsChanged?.Invoke(_currentBullets, _data.MaxBulletsInClip);
    }

    public void ResetState()
    {
        if (_reloadingCoroutine != null)
            StopCoroutine(_reloadingCoroutine);

        if (_internalReloadingCoroutine != null)
            StopCoroutine(_internalReloadingCoroutine);

        _reloadingCoroutine = null;
        _internalReloadingCoroutine = null;
    }

    public void TryReload()
    {
        if (_reloadingCoroutine != null)
            return;

        _reloadingCoroutine = StartCoroutine(Reloading());
    }

    public void TryShoot()
    {
        if (_currentBullets < _data.BulletsPerShot)
            return;

        if (_internalReloadingCoroutine != null)
            return;

        PerformShot();

        _internalReloadingCoroutine = StartCoroutine(InternalReloading());
    }

    private void PerformShot()
    {
        _audioSource.Play();

        for (int i = 0; i < _data.BulletsPerShot; i++)
        {
            Vector3 direction = _data.UseSpread ? _shootPoint.forward + CalculateSpread() : transform.forward;
            CreateBullet(direction);

            if (_data.IsInfinityBullets == false)
            {
                _currentBullets--;
                BulletsChanged?.Invoke(_currentBullets, _data.MaxBulletsInClip);
            }
        }
    }

    private void CreateBullet(Vector3 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, _shootPoint);
        bullet.transform.parent = null;
        bullet.Init(direction, _data.BaseDamage);
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-_data.SpreadFactor, _data.SpreadFactor),
            y = Random.Range(-_data.SpreadFactor, _data.SpreadFactor),
            z = Random.Range(-_data.SpreadFactor, _data.SpreadFactor)
        };
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(_data.BaseReloadTime);

        _currentBullets = _data.MaxBulletsInClip;
        _reloadingCoroutine = null;

        BulletsChanged?.Invoke(_currentBullets, _data.MaxBulletsInClip);
    }

    private IEnumerator InternalReloading()
    {
        yield return new WaitForSeconds(1 / _data.FireRate);

        _internalReloadingCoroutine = null;
    }
}