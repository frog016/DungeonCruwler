public interface IModifierApplier
{
    void Apply(IStatsModifier modifier);
    void Undo(IStatsModifier modifier);
}