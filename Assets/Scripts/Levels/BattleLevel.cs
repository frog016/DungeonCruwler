using UnityEngine;

public class BattleLevel : Level<BattleLevel.Data>
{
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
        Destroy(_data.BattleEvent.gameObject);
        Destroy(gameObject);
    }

    public readonly struct Data
    {
        public readonly MainLevel MainLevel;
        public readonly CameraSwitcher CameraSwitcher;
        public readonly InteractableEventBehaviour BattleEvent;

        public Data(CameraSwitcher cameraSwitcher, MainLevel mainLevel, InteractableEventBehaviour battleEvent)
        {
            CameraSwitcher = cameraSwitcher;
            MainLevel = mainLevel;
            BattleEvent = battleEvent;
        }
    }
}