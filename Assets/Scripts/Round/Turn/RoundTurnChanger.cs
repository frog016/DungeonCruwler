using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ITurnSystem))]
public class RoundTurnChanger : MonoBehaviour
{
    private ITurnSystem _turnSystem;

    private void Awake()
    {
        _turnSystem = GetComponent<ITurnSystem>();
    }

    private void Start()
    {
        StartCoroutine(WaitUntilEntityTurnEnded());
    }

    private IEnumerator WaitUntilEntityTurnEnded()
    {
        var wait = new WaitUntil(() => _turnSystem.Current.Resource.Amount == 0);
        while (true)
        {
            yield return wait;
            _turnSystem.Next();
        }
    }
}