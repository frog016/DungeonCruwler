using UnityEngine;
using Zenject;

[RequireComponent(typeof(SphereCollider))]
public class HiddenObjectDetector : MonoBehaviour
{
    private ICharacter _character;
    private SphereCollider _sphere;

    [Inject]
    public void Constructor(ICharacter character)
    {
        _character = character;
    }

    private void Start()
    {
        _sphere = GetComponent<SphereCollider>();
        _character.Stats.ValueChanged += SetUpDetectionArea;
        SetUpDetectionArea(StatType.Review, _character.Stats.GetStat(StatType.Review));
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.TryGetComponent<IHiddenObject>(out var hiddenEvent))
            hiddenEvent.Discover(_character);
    }

    private void SetUpDetectionArea(StatType areaRadiusType, int radius)
    {
        if (areaRadiusType != StatType.Review)
            return;

        _sphere.radius = radius;
    }
}