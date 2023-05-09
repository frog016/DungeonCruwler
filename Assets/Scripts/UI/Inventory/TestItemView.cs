using UnityEngine;

public class TestItemView : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Start()
    {
        var itemView = GetComponent<ItemView>();
        itemView.Initialize(_weapon.name, _weapon);
    }
}
