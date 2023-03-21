using UnityEngine;

public class BattleLauncher : MonoBehaviour, IEventLauncher
{
    [SerializeField] private MainLevel _mainLevel;
    [SerializeField] private BattleLevel _battleLevelPrefab;
    [SerializeField] private CameraSwitcher _switcher;

    public void Launch(InteractableEventBehaviour interactableEvent)
    {
        _mainLevel.Unload();

        var level = Instantiate(_battleLevelPrefab, transform);
        level.Load(new BattleLevel.Data(_switcher, _mainLevel, interactableEvent));
    }
}