public interface IShootable
{
    public bool IsCanShoot { get; }

    public bool TryShoot();
}
