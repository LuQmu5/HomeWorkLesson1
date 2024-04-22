using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : ObjectPool<Bullet>, IShootable
{
    protected readonly WeaponView View;
    protected readonly WeaponData Data;
    protected readonly ICoroutineRunner CoroutineRunner;

    protected Coroutine ShootDelayingCoroutine;
    protected float TimeBetweenShots;

    public Weapon(WeaponData data, Transform container, ICoroutineRunner coroutineRunner)
    {
        CoroutineRunner = coroutineRunner;
        Data = data;
        TimeBetweenShots = 1 / data.ShotsPerSecond;
        View = Object.Instantiate(data.WeaponView, container);
        InitPool(data.BulletPrefab);
    }

    public abstract bool CanShoot { get; }
    public abstract int MaxBullets { get; }
    public abstract int CurrentBullets { get; }

    public event UnityAction Shoted;

    public bool TryShoot()
    {
        if (CanShoot == false)
            return false;

        ShootDelayingCoroutine = CoroutineRunner.StartCoroutine(ShootDelaying());
        PerformShot();

        return true;
    }

    public virtual void Activate()
    {
        View.gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        View.gameObject.SetActive(false);

        if (ShootDelayingCoroutine != null)
            CoroutineRunner.StopCoroutine(ShootDelayingCoroutine);
    }

    protected abstract void PerformShot();

    protected void OnShoted()
    {
        Shoted?.Invoke();
    }

    private IEnumerator ShootDelaying()
    {
        yield return new WaitForSeconds(TimeBetweenShots);

        ShootDelayingCoroutine = null;
    }
}
