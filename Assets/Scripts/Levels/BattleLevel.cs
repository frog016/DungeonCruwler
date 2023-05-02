using UnityEngine;

public class BattleLevel : MonoBehaviour
{
    private ITurnBasedCombat _combat;

    public void Constructor(ITurnBasedCombat combat)
    {
        _combat = combat;
    }

    public void Load(ICharacter[] characters)
    {
        _combat.Initialize(characters);
        _combat.Launch();
    }

    public void Unload()
    {
        Destroy(gameObject);
    }
}