public class EquipItemContextAction : ContextAction
{
    public override string Name => "Надеть";

    private readonly IEquipmentItem _item;
    private readonly IEquipmentWearer _wearer;

    public EquipItemContextAction(IEquipmentItem item, IEquipmentWearer wearer)
    {
        _item = item;
        _wearer = wearer;
    }

    public override void Invoke()
    {
        _wearer.Equip(_item);
    }
}