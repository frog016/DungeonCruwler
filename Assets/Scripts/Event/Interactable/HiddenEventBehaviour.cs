using UnityEngine;

[RequireComponent(typeof(HiddenObject))]
public class HiddenEventBehaviour : EventBehaviour
{
    [SerializeField] private int _detectionClass;
    [SerializeField] private int _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private ScriptableEventAction _hiddenAction;

    public int DetectionClass => _detectionClass;
    public int Damage => _damage;
    public DamageType DamageType => _damageType;

    private HiddenObject _hiddenObject;

    private void Awake()
    {
        _hiddenObject = GetComponent<HiddenObject>();
        _hiddenObject.DetectionClass = DetectionClass;
    }

    public override void Interact(ICharacter character)
    {
        if (_hiddenObject.Detected)
        {
            base.Interact(character);
            return;
        }

        _hiddenAction.Invoke(this, character);
    }
}