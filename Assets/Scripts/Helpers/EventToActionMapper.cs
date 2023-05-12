using UnityEngine;

[CreateAssetMenu(menuName = "Mapper/Interactable Event to Event Action", fileName = "EventToActionMapper")]
public class EventToActionMapper : TypeMapper<ScriptableEvent, ScriptableEventAction[]>
{
}