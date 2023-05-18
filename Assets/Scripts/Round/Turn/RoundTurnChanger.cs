using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ITurnSystem))]
public class RoundTurnChanger : MonoBehaviour
{
    private ITurnSystem _turnSystem;
    private Coroutine _waitTurnEndedCoroutine;

    private void Awake()
    {
        _turnSystem = GetComponent<ITurnSystem>();
    }

    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }

    private IEnumerator Subscribe()
    {
        yield return new WaitUntil(() => _turnSystem is { Current: { Resource: { } } });
        _waitTurnEndedCoroutine = StartCoroutine(WaitUntilEntityTurnEnded());
    }

    private void OnDisable()
    {
        if (_waitTurnEndedCoroutine == null)
            return;
        
        StopCoroutine(_waitTurnEndedCoroutine);
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