using UnityEngine;

[RequireComponent(typeof(HiddenObject))]
public class HiddenEventHolder : InteractableEventHolder
{
    [SerializeField] private ScriptableEventAction _hiddenAction;

    private HiddenObject _hiddenObject;

    private void Awake()
    {
        _hiddenObject = GetComponent<HiddenObject>();
        _hiddenObject.DetectionClass = ((HiddenScriptableEvent)_event).DetectionClass;
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