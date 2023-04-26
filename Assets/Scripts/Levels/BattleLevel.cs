using UnityEngine;

public class BattleLevel : Level<BattleLevel.Data>
{
    [SerializeField] private StateTurnBasedCombat _combat;

    private Data _data;

    public override void Load(Data data)
    {
        _data = data;
        _data.CameraSwitcher.Switch(_activeCamera);
    }

    public override void Unload()
    {
        _data.CameraSwitcher.ReturnPrevious();
        _data.MainLevel.Load(null);
        Destroy(gameObject);
    }

    public readonly struct Data
    {
        public readonly MainLevel MainLevel;
        public readonly CameraSwitcher CameraSwitcher;
        public readonly IInteractableEvent BattleEvent;

        public Data(CameraSwitcher cameraSwitcher, MainLevel mainLevel, IInteractableEvent battleEvent)
        {
            CameraSwitcher = cameraSwitcher;
            MainLevel = mainLevel;
            BattleEvent = battleEvent;
        }
    }
}