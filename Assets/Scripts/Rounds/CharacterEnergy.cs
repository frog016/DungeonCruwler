using UnityEngine;

[RequireComponent(typeof(ICharacter), typeof(ITargetable))]
public class CharacterEnergy : MonoBehaviour
{
    [SerializeField] private Round _round;
    
    public int CurrentEnergy { get; private set; }

    private int _limit;
    private ITargetable _targetable;

    private void Awake()
    {
        _targetable = GetComponent<ITargetable>();
        var character = GetComponent<ICharacter>();

        _limit = character.Stats.GetStat(StatType.Speed);
        CurrentEnergy = _limit;
    }

    private void OnEnable()
    {
        _round.TurnEnded += OnPlayerTurn;
    }

    private void OnDisable()
    {
        _round.TurnEnded -= OnPlayerTurn;
    }

    public bool TryDoAction(CharacterAction action)
    {
        if (action.Cost > CurrentEnergy)
            return false;

        CurrentEnergy -= action.Cost;
        action.Action.Invoke();

        return true;
    }

    public void RestoreEnergy()
    {
        CurrentEnergy = _limit;
    }

    private void OnPlayerTurn(ITargetable obj)
    {
        if (obj.Team != _targetable.Team)
            return;

        RestoreEnergy();
    }
}
