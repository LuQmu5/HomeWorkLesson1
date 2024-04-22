using System;

public interface IReloadable : IShootable
{
    public float ReloadTime { get; }

    public bool TryReload();
    public event Action Reloaded;
}
