using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Event/Actions/Observe Room", fileName = "ObserveRoomAction")]
public class ObserveRoomAction : ScriptableEventAction
{
    [SerializeField] private int _viewRadius;
    [SerializeField] private FogDiscoverer _discovererPrefab;

    private IGameObjectFactory _factory;
    private FogOfWar _fog;

    [Inject]
    public void Constructor(IGameObjectFactory factory, FogOfWar fog)
    {
        _factory = factory;
        _fog = fog;
    }

    public override void Invoke(EventBehaviour owner, ICharacter target)
    {
        base.Invoke(owner, target);
        var discoverer = _factory.CreateFromComponent(_discovererPrefab);
        discoverer.transform.SetParent(owner.transform);
        discoverer.transform.localPosition = Vector3.zero;
        discoverer.ViewRadius = _viewRadius;

        _fog.AddDiscoverer(discoverer);
    }
}
