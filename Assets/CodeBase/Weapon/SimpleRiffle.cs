using System.Collections;
using UnityEngine;

public class SimpleRiffle : Weapon
{
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
        if (CurrentBullets == 0)
            return;

        if (_internalReloadingCoroutine != null)
            return;

        CurrentBullets--;
        print("pah");

        _internalReloadingCoroutine = StartCoroutine(InternalReloading());
    }

    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(Data.BaseReloadTime);

        CurrentBullets = Data.MaxBulletsInClip;
        _reloadingCoroutine = null;
    }

    private IEnumerator InternalReloading()
    {
        yield return new WaitForSeconds(1 / Data.FireRate);

        _internalReloadingCoroutine = null;
    }
}
