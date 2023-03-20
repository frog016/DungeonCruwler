using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera _active;

    private Camera _previous;

    public void Switch(Camera next)
    {
        _previous = _active;
        SetActiveCamera(next);
    }

    public void ReturnPrevious()
    {
        SetActiveCamera(_previous);
    }

    private void SetActiveCamera(Camera activeCamera)
    {
        _active.enabled = false;
        _active = activeCamera;
        _active.enabled = true;
    }
}