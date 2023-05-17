public class RemoveItemContextAction : ContextAction
{
    public override string Name => "Снять";

    private readonly IEquipmentItem _item;
    private readonly IItemUser _itemUser;

    public RemoveItemContextAction(IEquipmentItem item, IItemUser itemUser)
    {
        _item = item;
        _itemUser = itemUser;
    }

    public override void Invoke()
    {
        _itemUser.EquipmentWearer.Remove(_item);
        _itemUser.Inventory.Add(_item);
    }
}