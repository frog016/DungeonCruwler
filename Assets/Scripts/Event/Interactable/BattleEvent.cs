using UnityEngine;

public class BattleEvent : InteractableEventBehaviour
{
    [SerializeField] private BattleLauncher _battleLauncher;

    protected override void OnInteract(Character character)
    {
        _battleLauncher.Launch();
    }
}