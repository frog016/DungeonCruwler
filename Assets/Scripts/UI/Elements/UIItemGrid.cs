using System.Linq;

public class UIItemGrid : UIGrid<UICell>
{
    public override UICell[] GetEmptyCells(ItemUiContainer uiContainer)
    {
        var cell = Cells.First(cell => cell.Content == null);
        return new UICell[] { cell };
}
}