using UnityEngine;

[RequireComponent(typeof(Energy))]
public class TurnEntity : MonoBehaviour, ITurnEntity
{
    [SerializeField] private Team _team;

    public Team Team => _team;
    public Energy Energy { get; private set; }

    private void Awake()
    {
        Energy = GetComponent<Energy>();
    }
}