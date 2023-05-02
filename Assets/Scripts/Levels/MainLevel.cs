using UnityEngine;

public class MainLevel : MonoBehaviour
{
    public void Load()
    {
        gameObject.SetActive(true);
    }

    public void Unload()
    {
        gameObject.SetActive(false);
    }
}