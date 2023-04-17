using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FogRenderer : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _alpha;
    [SerializeField, Range(0, 1)] private float _lerpSpeedCoefficient;
    [SerializeField] private Color _color;
    [SerializeField] private Material _material;

    public Texture2D TargetTexture { get; private set; }
    public Texture2D BufferTexture { get; private set; }

    private MeshRenderer _meshRenderer;

    public void InitializeRenderer(Texture2D targetTexture, Texture2D bufferTexture)
    {
        TargetTexture = targetTexture;
        BufferTexture = bufferTexture;

        BufferTexture.wrapMode = TextureWrapMode.Clamp;
        BufferTexture.filterMode = FilterMode.Bilinear;

        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = new Material(_material);
        _meshRenderer.material.SetTexture("_MainTex", BufferTexture);
    }

    public void UpdateTargetTexture(VisibilityType[] visibilityMap)
    {
        var textureColors = GetTextureColors(
            visibilityMap,
            new Vector2Int(TargetTexture.width, TargetTexture.height),
            _alpha);

        _meshRenderer.material.SetColor("_Color", _color);
        TargetTexture.SetPixels(textureColors);
        TargetTexture.Apply();
    }

    public void UpdateBufferTexture()
    {
        for (var x = 0; x < BufferTexture.width; x++)
            for (var y = 0; y < BufferTexture.height; y++)
                BufferTexture.SetPixel(x, y, Color.Lerp(
                    BufferTexture.GetPixel(x, y),
                    TargetTexture.GetPixel(x, y),
                    _lerpSpeedCoefficient));

        BufferTexture.Apply();
    }

    private static Color[] GetTextureColors(VisibilityType[] visibilityMap, Vector2Int textureSize, float alpha)
    {
        var colors = new Color[textureSize.y * textureSize.x];
        for (var y = 0; y < textureSize.y; y++)
        {
            for (var x = 0; x < textureSize.x; x++)
            {
                var visibility = 1 - (int)visibilityMap[y * textureSize.x + x];
                colors[y * textureSize.x + x] = new Color(
                    visibility, visibility,
                    visibility, visibility * alpha);
            }
        }

        return colors;
    }
}