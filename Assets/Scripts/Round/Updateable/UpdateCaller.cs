using UnityEngine;

public class UpdateCaller : MonoBehaviour
{
    private ITurnSystem _turnSystem;
    private IUpdateable[] _updateableEntities;

    public virtual void Constructor(ITurnSystem turnSystem, IUpdateable[] updateableEntities)
    {
        _turnSystem = turnSystem;
        _updateableEntities = updateableEntities;
    }

    private void OnEnable()
    {
        _turnSystem.RoundEnded += UpdateAllEntities;
    }

    private void OnDisable()
    {
        _turnSystem.RoundEnded -= UpdateAllEntities;
    }

    private void UpdateAllEntities()
    {
        foreach (var updateable in _updateableEntities)
            updateable.UpdateEntity();
    }
}