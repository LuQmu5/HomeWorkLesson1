using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData Data;
    [SerializeField] protected Transform ShootPoint;

    protected int CurrentBullets;

    public event Action<int, int> BulletsChanged;

    private void Awake()
    {
        CurrentBullets = Data.MaxBulletsInClip;
        OnBulletsChanged();
    }

    protected void OnBulletsChanged()
    {
        BulletsChanged?.Invoke(CurrentBullets, Data.MaxBulletsInClip);
    }

    public abstract void Shoot();
    public abstract void Reload();
}
