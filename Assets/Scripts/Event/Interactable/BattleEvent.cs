using UnityEngine;

public class BattleEvent : HiddenInteractableEvent<BattleEvent>
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevelPrefab;
    [SerializeField] private CameraSwitcher _switcher;

    protected override bool OnInteract(ICharacter character)
    {
        _mainLevel.Unload();

        var level = Instantiate(_battleLevelPrefab, transform);
        level.Load(new BattleLevel.Data(_switcher, _mainLevel, this));
        return true;
    }
}