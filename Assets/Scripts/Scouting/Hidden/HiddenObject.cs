using System;
using UnityEngine;

public class HiddenObject : MonoBehaviour, IHiddenObject
{
    [SerializeField] private int _detectionClass;

    public event Action Discovered;
    public bool Detected { get; private set; }

    private bool _tried;

    public void Discover(ICharacter character)
    {
        if (_tried)
            return;

        Debug.Log("Start discovering");
        var review = character.Stats.GetStat(StatType.Review);
        if (TryDiscover(review))
        {
            Detected = true;
            Debug.Log($"Event ({gameObject}) with detection class {_detectionClass} has been detected.");
            Discovered?.Invoke();
        }
        else
        {
            Debug.Log($"Event ({gameObject}) detection failed.");
        }

        _tried = true;
    }

    private bool TryDiscover(int review)
    {
        return Dice.RollD20() + review >= _detectionClass;
    }
}