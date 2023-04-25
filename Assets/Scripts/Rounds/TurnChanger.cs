using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Round))]
public class TurnChanger : MonoBehaviour
{
    private Round _round;

    private void Awake()
    {
        _round = GetComponent<Round>();
    }

    private void OnEnable()
    {
        _round.TurnStarted += ChangeTurn;
    }

    private void OnDisable()
    {
        _round.TurnStarted -= ChangeTurn;
    }

    private void ChangeTurn(ITurnEntity entity)
    {
        StartCoroutine(WaitUntilEnergyEndedCoroutine(entity));
    }

    private IEnumerator WaitUntilEnergyEndedCoroutine(ITurnEntity entity)
    {
        yield return new WaitUntil(() => entity.Energy.CurrentAmount == 0);
        Debug.Log($"{entity} turn ended.");
        _round.Next();
    }
}