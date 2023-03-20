public interface IDamageable : IEffectApplier
{
    int Health { get; }
    void ApplyDamage(int damage);
}