public class ReplaceItemContextAction : ContextAction
{
    public override string Name => "Заменить";

    private readonly IEquipmentItem _item;
    private readonly IEquipmentWearer _wearer;

    public ReplaceItemContextAction(IEquipmentItem item, IEquipmentWearer wearer)
    {
        _item = item;
        _wearer = wearer;
    }

    public override void Invoke()
    {
        _wearer.TryGetItem(_item.Slot, out var oldItem);
        _wearer.Remove(oldItem);
        _wearer.Equip(_item);
    }
}