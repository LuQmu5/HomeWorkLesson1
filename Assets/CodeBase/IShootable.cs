using System.Collections;
using UnityEngine.Events;

public interface IShootable
{
    public int MaxBullets { get; }
    public int CurrentBullets { get; }
    public bool CanShoot { get; }

    public bool TryShoot();

    public event UnityAction Shoted;
}
