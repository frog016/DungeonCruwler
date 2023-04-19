using UnityEngine;

public abstract class ScriptableTemporaryEffect : ScriptableObject, ITemporaryEffect
{
    [SerializeField] private int _duration;

    public ICharacter Target { get; set; }
    public bool Applied { get; private set; }
    public int Duration { get => _duration; set => _duration = value; }

    public virtual void Apply()
    {
        Applied = true;
    }

    public virtual void Remove()
    {
        Applied = false;
    }
}