using UnityEngine;

public abstract class MapTickableEffect : ScriptableObject, ITickableEffect
{
    [SerializeField] private int _duration;

    protected readonly ICharacter _target;

    private int _tickCount;
    private object _roundSystem;

    public void Constructor(object roundSystem)
    {
        _roundSystem = roundSystem;
        //_roundSystem.TurnStarted += OnPlayerTurn;
    }

    public int Tick()
    {
        if (_tickCount < _duration)
        {
            UseEffect();
            _tickCount++;
        }

        return _tickCount;
    }

    protected abstract void UseEffect();

    private void OnPlayerTurn(int team) //  TODO: Replace this on ITargetable ñ enum Team.
    {
        if (team != 0)
            return;

        Tick();
    }
}

[CreateAssetMenu(menuName = "Event/Trap/Effects/Bleeding", fileName = "BleedingEffect")]
public class BleedingEffect : MapTickableEffect
{
    [SerializeField] private int _damage;

    protected override void UseEffect()
    {
        _target.ApplyDamage(_damage);
    }
}