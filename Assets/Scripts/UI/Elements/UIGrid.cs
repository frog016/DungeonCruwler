using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIGrid<TCell> : MonoBehaviour where TCell : UICell
{
    [SerializeField] private List<TCell> _cells;

    public List<TCell> Cells => _cells;

    public void AddContent(ItemUiContainer content)
    {
        foreach (var emptyCell in GetEmptyCells(content))
            AddContentTo(content, emptyCell);
    }

    public void AddContentTo(ItemUiContainer content, TCell cell)
    {
        cell.Content = content;
        PlaceInParent(content, cell.transform);
    }

    public void RemoveContent(ItemUiContainer content)
    {
        foreach (var cell in GetCellsWithContent(content))
            _cells.Remove(cell);
    }

    public abstract TCell[] GetEmptyCells(ItemUiContainer content);

    private IEnumerable<TCell> GetCellsWithContent(ItemUiContainer content)
    {
        return _cells
            .Where(cell => cell.Content.Item == content.Item)
            .ToArray();
    }

    private static void PlaceInParent(Component content, Transform parent)
    {
        var otherRect = content.GetComponent<RectTransform>();
        otherRect.parent = parent;
        otherRect.anchoredPosition = Vector2.zero;
    }
}