using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementCellGrid<TElement> : MonoBehaviour where TElement : UIElementCell
{
    public IEnumerable<TElement> Cells => _cells;

    private List<TElement> _cells;

    private void Awake()
    {
        _cells = GetComponentsInChildren<TElement>().ToList();
    }
}