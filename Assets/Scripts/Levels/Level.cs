using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Camera _activeCamera;
    private CameraSwitcher _switcher;

    public virtual void Load(CameraSwitcher switcher)
    {
        _switcher = switcher;
        _switcher.Switch(_activeCamera);
    }

    public virtual void Unload()
    {
        _switcher.ReturnPrevious();
        Destroy(gameObject);
    }
}