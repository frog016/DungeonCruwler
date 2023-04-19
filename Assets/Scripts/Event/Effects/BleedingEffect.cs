using UnityEngine;

[CreateAssetMenu(menuName = "Event/Trap/Effects/Bleeding", fileName = "BleedingEffect")]
public class BleedingEffect : ScriptableTickableEffect
{
    [SerializeField] private int _damage;

    public override void Apply()
    {
        Target.ApplyDamage(_damage);
    }
}