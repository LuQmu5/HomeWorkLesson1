public interface IShootable
{
    public bool CanShoot { get; }

    public bool TryShoot();
}
