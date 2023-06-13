using System.Collections;
using System.Linq;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] private EditorInventory _inventory;
    [SerializeField] private TreasureUIPanel _itemWindow;

    public IItem[] GetItems() => _inventory.GetAll().ToArray();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EventActivator>(out var activator))
        {
            _itemWindow.Initialize(_inventory, activator.GetComponentInParent<ICharacter>());
            _itemWindow.Open();
            StartCoroutine(WaitForClose());
        }
    }

    private IEnumerator WaitForClose()
    {
        yield return new WaitUntil(() => !_itemWindow.gameObject.activeSelf);
        Destroy(gameObject);
    }
}