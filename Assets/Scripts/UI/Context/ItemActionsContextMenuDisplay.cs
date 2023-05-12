using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemActionsContextMenuDisplay : ContextMenuDisplay
{
    protected override void InitializeMenu(GameObject clickedObject, ContextMenu menu)
    {
        if (!clickedObject.TryGetComponent<ItemUiContainer>(out var container))
            return;

    }
}