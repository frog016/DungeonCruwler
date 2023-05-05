using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Try Break Object", fileName = "TryBreakObjectAction")]
public class TryBreakObjectAction : ScriptableEventAction<BreakableObjectEvent>
{
    public override void Invoke(BreakableObjectEvent owner, ICharacter target)
    {
        Debug.Log("!!!");
        var strength = target.Stats.GetStat(StatType.Strength);
        if (strength >= 17)
        {
            owner.enabled = false;
            Debug.Log("Object broke!");
        }
        else if (strength < 12)
        {
            target.ApplyDamage(1);
            Debug.Log("Strength is Too Low! Get some damage.");
        }
        else
        {
            Debug.Log("Not enough strength to break the wall.");
        }
    }
}
