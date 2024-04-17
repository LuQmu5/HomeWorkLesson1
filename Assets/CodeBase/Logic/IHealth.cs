public interface IHealth
{
    public float Max {  get; set; }
    public float Current { get; set; }

    void ApplyDamage(float amount);
}