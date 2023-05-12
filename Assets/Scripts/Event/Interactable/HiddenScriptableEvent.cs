using UnityEngine;

[CreateAssetMenu(menuName = "Event/Hidden event", fileName = "HiddenScriptableEvent")]
public class HiddenScriptableEvent : ScriptableEvent
{
    [SerializeField] private int _detectionClass;

    public int DetectionClass => _detectionClass;
    public IEffect Effect { get; }
}