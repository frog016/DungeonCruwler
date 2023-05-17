using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Event/Actions/Launch Battle", fileName = "LaunchBattleEventAction")]
public class LaunchBattleEventAction : ScriptableEventAction
{
    private MainLevel _mainLevel;
    private BattleLevel _battleLevelPrefab;

    [Inject]
    public void Constructor(MainLevel mainLevel, BattleLevel battleLevel)
    {
        _mainLevel = mainLevel;
        _battleLevelPrefab = battleLevel;
    }

    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);
        _mainLevel.Unload();

        var level = Instantiate(_battleLevelPrefab, new Vector3(1000, 0, 0), Quaternion.identity);
        level.Initiator = owner.gameObject;
        level.Load(new ICharacter[] { target, owner.GetComponent<ICharacter>() });
    }
}