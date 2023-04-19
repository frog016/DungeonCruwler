using UnityEngine;

public abstract class ScriptableTickableEffect : ScriptableObject, ITickableEffect
{
    [SerializeField] private int _duration;

    public ICharacter Target { get; set; }
    public int Duration { get => _duration; set => _duration = value; }

    public abstract void Apply();
}