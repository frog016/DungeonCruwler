public class DeleteItemContextAction : ContextAction
{
    public override string Name => "Выкинуть";

    private readonly IItem _item;
    private readonly IInventory _inventory;

    public DeleteItemContextAction(IItem item, IInventory inventory)
    {
        _item = item;
        _inventory = inventory;
    }

    public override void Invoke()
    {
        _inventory.Remove(_item);
    }
}