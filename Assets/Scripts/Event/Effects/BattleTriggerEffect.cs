using UnityEngine;

[CreateAssetMenu(menuName = "Event/Trap/Effects/EventTrigger", fileName = "BattleTriggerEffect")]
public class BattleTriggerEffect : ScriptableTemporaryEffect
{
    [SerializeField] private int _damage;

    //private BattleEvent[] _events;

    //[Inject]
    //public void Constructor(IInteractableEvent[] events)
    //{
    //    _events = events;
    //}

    private void OnEnable() // TODO: Use Zenject here.
    {
        //_events = FindObjectsOfType<BattleEvent>();
        //_events.Apply(interactableEvent => interactableEvent.Interacted += DealDamage);
    }

    private void OnDisable()
    {
        //_events.Apply(interactableEvent => interactableEvent.Interacted -= DealDamage);
    }

    private void DealDamage(ICharacter target)
    {
        if (Duration == 0)
            return;

        target.ApplyDamage(_damage);
        Duration = 0;
    }
}