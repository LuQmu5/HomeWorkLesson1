using System;

public interface IShootable
{
    public bool CanShoot { get; }

    public bool TryShoot();

    public event Action Shoted;
}
