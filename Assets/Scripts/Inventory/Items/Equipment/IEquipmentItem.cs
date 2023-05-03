public interface IEquipmentItem : IItem
{
    EquipmentSlot Slot { get; }
    void Deactivate(IStatsUser statsUser);
}