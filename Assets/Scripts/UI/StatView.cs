using TMPro;
using UnityEngine;

public class StatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _value;

    public void ChangeText<TStat>(TStat statType, int value)
    {
        _name.text = statType.ToString();
        _value.text = $"{value}";
    }
}
