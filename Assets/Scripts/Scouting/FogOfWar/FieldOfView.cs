using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private int _verticesCount;
    [SerializeField] private int _radius;
    [SerializeField] private MeshFilter _filter;

    private CircleViewAreaGenerator _areaGenerator;

    private void Awake()
    {
        _areaGenerator = new CircleViewAreaGenerator(_verticesCount, _radius);
    }

    private void Update()
    {
        _filter.mesh = _areaGenerator.Generate(transform.position);
    }
}
