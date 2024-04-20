public interface IReloadable : IShootable
{
    public int MaxBullets { get; }
    public int CurrentBullets { get; }
    public float ReloadTime { get; }

    public bool TryReload();
}
