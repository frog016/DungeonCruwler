using UnityEngine;

public static class CameraExtensions
{
    private const float MaxDistance = 100f;

    public static bool ScreenPointToHit(this Camera camera, Vector3 screenPoint, out RaycastHit hit)
    {
        var ray = camera.ScreenPointToRay(screenPoint);
        return Physics.Raycast(ray, out hit);
    }

    public static bool ScreenPointToHit(this Camera camera, Vector3 screenPoint, LayerMask layer, out RaycastHit hit)
    {
        var ray = camera.ScreenPointToRay(screenPoint);
        return Physics.Raycast(ray, out hit, MaxDistance, layer);
    }
}