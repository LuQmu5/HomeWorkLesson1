using System.Collections;
using UnityEngine;

public class SimpleRiffle : Weapon
{
    [SerializeField] private LayerMask _hittableMask;

    private Coroutine _reloadingCoroutine;
    private Coroutine _internalReloadingCoroutine;

    public override void Reload()
    {
        if (_reloadingCoroutine != null)
            return;

        _reloadingCoroutine = StartCoroutine(Reloading());
    }

    public override void Shoot()
    {
        if (CurrentBullets < Data.BulletsPerShot)
            return;

        if (_internalReloadingCoroutine != null)
            return;

        PerformShot();

        _internalReloadingCoroutine = StartCoroutine(InternalReloading());
    }

    private void PerformShot()
    {
        for (int i = 0; i < Data.BulletsPerShot; i++)
        {
            CreateRaycast();

            if (Data.IsInfinityBullets == false)
                CurrentBullets--;

            OnBulletsChanged();
        }
    }

    private void CreateRaycast()
    {
        Vector3 direction = Data.UseSpread ? ShootPoint.forward + CalculateSpread() : transform.forward;
        Ray ray = new Ray(ShootPoint.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Data.Distance, _hittableMask))
        {
            Collider hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IHealth health))
            {
                health.ApplyDamage(Data.BaseDamage);
                print(health.Current);
            }
        }
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-Data.SpreadFactor, Data.SpreadFactor),
            y = Random.Range(-Data.SpreadFactor, Data.SpreadFactor),
            z = Random.Range(-Data.SpreadFactor, Data.SpreadFactor)
        };
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(Data.BaseReloadTime);

        CurrentBullets = Data.MaxBulletsInClip;
        OnBulletsChanged();
        _reloadingCoroutine = null;
    }

    private IEnumerator InternalReloading()
    {
        yield return new WaitForSeconds(1 / Data.FireRate);

        _internalReloadingCoroutine = null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Data.Distance, _hittableMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            Vector3 hitPosition = ray.origin + ray.direction * Data.Distance;

            DrawRay(ray, hitPosition, Data.Distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
#endif
}
