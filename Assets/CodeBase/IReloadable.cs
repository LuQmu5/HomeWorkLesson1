public interface IReloadable : IShootable
{
    public float ReloadTime { get; }

    public bool TryReload();
}
