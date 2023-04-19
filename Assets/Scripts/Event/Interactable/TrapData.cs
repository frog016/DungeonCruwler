using UnityEngine;

[CreateAssetMenu(menuName = "Event/Trap/Data", fileName = "TrapData")]
public class TrapData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private int _detectionClass;
    [SerializeField] private int _complexityClass;

    public int Damage => _damage;
    public DamageType DamageType => _damageType;
    public int DetectionClass => _detectionClass;
    public int ComplexityClass => _complexityClass;
}