using UnityEngine;

public class BattleEvent : HiddenInteractableEvent<BattleEvent>
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevelPrefab;
    [SerializeField] private CameraSwitcher _switcher;
    [SerializeField] private Transform _battleLevelPosition;

    protected override bool OnInteract(ICharacter character)
    {
        _mainLevel.Unload();

        var level = Instantiate(_battleLevelPrefab, _battleLevelPosition);
        level.Load(new BattleLevel.Data(_switcher, _mainLevel, this));
        return true;
    }
}