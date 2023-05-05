using UnityEngine;

[CreateAssetMenu(menuName = "Event/Actions/Observe Room", fileName = "ObserveRoomAction")]
public class ObserveRoomAction : ScriptableEventAction<VisibilityUnlockerEvent>
{
    [SerializeField] private int _viewRadius;
    [SerializeField] private FogDiscoverer _discovererPrefab;

    public override void Invoke(VisibilityUnlockerEvent owner, ICharacter target)
    {
        var discoverer = Instantiate(_discovererPrefab, owner.ViewTransform);
        discoverer.ViewRadius = _viewRadius;
        discoverer.Map = owner.Map;
        owner.Fog.AddDiscoverer(discoverer);
    }
}
