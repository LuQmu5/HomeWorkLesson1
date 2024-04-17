using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData Data;
    [SerializeField] protected Transform ShootPoint;

    protected int CurrentBullets;

    private void Awake()
    {
        CurrentBullets = Data.MaxBulletsInClip;
    }

    public abstract void Shoot();
    public abstract void Reload();
}
