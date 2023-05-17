public class UseItemContextAction : ContextAction
{
    public override string Name => "Использовать";

    private readonly IItem _item;
    private readonly IStatsUser _user;

    public UseItemContextAction(IItem item, IStatsUser user)
    {
        _item = item;
        _user = user;
    }

    public override void Invoke()
    {
        _item.Activate(_user);
    }
}