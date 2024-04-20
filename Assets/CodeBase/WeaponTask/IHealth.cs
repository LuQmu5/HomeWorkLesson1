public interface IHealth
{
    public float Current { get; set; }
    public float Max { get; set; }

    public void ApplyDamage(float amount);
}