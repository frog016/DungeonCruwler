using UnityEngine;

public class BattleEvent : InteractableEventBehaviour
{
    [SerializeField] private BattleLauncher _battleLauncher;

    protected override bool OnInteract(ICharacter character)
    {
        _battleLauncher.Launch(this);
        return true;
    }
}