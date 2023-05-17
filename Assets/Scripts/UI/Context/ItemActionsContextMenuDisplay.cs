using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class ItemActionsContextMenuDisplay : ContextMenuDisplay
{
    protected override void InitializeMenu(PointerEventData eventData, ContextMenu menu)
    {
        if (!TryGetContainer(eventData, out var container))
            return;

        var actions = GetContextActionsByItem(container.Item, container.Owner);
        menu.Initialize(actions.ToArray());
        menu.Open();
    }

    private bool TryGetContainer(PointerEventData eventData, out ItemUiContainer container)
    {
        UICell cell = null;
        _ = eventData.hovered.FirstOrDefault(obj => obj.TryGetComponent(out cell));
        container = cell?.Content;

        return container != null;
    }

    private static IEnumerable<ContextAction> GetContextActionsByItem(IItem item, ICharacter owner)
    {
        if (item is IEquipmentItem equipment)
        {
            if (owner.EquipmentWearer.TryGetItem(equipment.Slot, out var equipped))
            {
                if (equipment == equipped)
                {
                    yield return new RemoveItemContextAction(equipment, owner);
                    yield break;
                }

                yield return new ReplaceItemContextAction(equipment, owner.EquipmentWearer);
            }
            else
            {
                yield return new EquipItemContextAction(equipment, owner.EquipmentWearer);
            }
        }
        else
        {
            yield return new UseItemContextAction(item, owner);
        }

        yield return new DeleteItemContextAction(item, owner.Inventory);
    }
}