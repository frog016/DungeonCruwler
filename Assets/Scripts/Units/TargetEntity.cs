using UnityEngine;

public class TargetEntity : MonoBehaviour, ITargetable
{
    [SerializeField] private Team _team;

    public Team Team => _team;
}