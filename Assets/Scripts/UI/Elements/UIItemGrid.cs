using System.Linq;

public class UIItemGrid : UIGrid<UICell>
{
    public override UICell[] GetEmptyCells(ItemView view)
    {
        var cell = Cells.First(cell => cell.Content == null);
        return new UICell[] { cell };
}
}