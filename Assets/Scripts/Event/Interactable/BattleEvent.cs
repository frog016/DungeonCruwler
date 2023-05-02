using UnityEngine;

[RequireComponent(typeof(ICharacter))]
public class BattleEvent : HiddenInteractableEvent<BattleEvent>
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevelPrefab;
    [SerializeField] private Transform _battleLevelPosition;

    private ICharacter _character;

    protected override void Awake()
    {
        base.Awake();
        _character = GetComponent<ICharacter>();
    }
    protected override bool OnInteract(ICharacter character)
    {
        _mainLevel.Unload();

        var level = Instantiate(_battleLevelPrefab, _battleLevelPosition);
        level.Initiator = gameObject;
        level.Load(new ICharacter[] { character, _character });
        return false;
    }
}