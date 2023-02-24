using UnityEngine;

public static class CameraExtensions
{
    public static bool ScreenPointToHit(this Camera camera, Vector3 screenPoint, out RaycastHit hit)
    {
        var ray = camera.ScreenPointToRay(screenPoint);
        return Physics.Raycast(ray, out hit);
    }
}