using UnityEngine;

public class Railgun : Weapon
{
    public Railgun(WeaponData data, Transform container, ICoroutineRunner coroutineRunner) : base(data, container, coroutineRunner)
    {
    }

    public override bool CanShoot => ShootDelayingCoroutine == null;
    public override int MaxBullets => 1;
    public override int CurrentBullets => 1;

    protected override void PerformShot()
    {
        foreach (var shootPoint in View.ShootPoints)
        {
            Bullet bullet = GetItem();
            bullet.gameObject.SetActive(true);
            bullet.Launch(shootPoint.position, shootPoint.forward, Data.Damage, Data.BulletSpeed);
        }

        View.PerformShot();
        OnShoted();
    }
}
