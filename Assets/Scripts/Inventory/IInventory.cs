public interface IInventory : ICollection<IItem>
{
    IItem GetByHash(int itemHash);
}