using UnityEngine;

public class BattleLauncher : MonoBehaviour, IEventLauncher
{
    [SerializeField] private Level _battleLevelPrefab;
    [SerializeField] private CameraSwitcher _switcher;

    public void Launch()
    {
        var level = Instantiate(_battleLevelPrefab, transform);
        level.Load(_switcher);
    }
}