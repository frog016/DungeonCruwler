public interface IDamageable : IEffectApplier
{
    int Health { get; }
    int MaxHealth { get; }
    void ApplyDamage(int damage);
}