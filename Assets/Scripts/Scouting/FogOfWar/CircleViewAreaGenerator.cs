using UnityEngine;

public class CircleViewAreaGenerator
{
    public readonly int VerticesCount;

    private readonly float _radius;
    private readonly Mesh _generatedMesh = new Mesh();

    public CircleViewAreaGenerator(int verticesCount, float radius)
    {
        VerticesCount = verticesCount;
        _radius = radius;
    }

    public Mesh Generate(Vector3 position)
    {
        _generatedMesh.Clear();
        var vertices = new Vector3[VerticesCount + 2];
        var triangles = new int[VerticesCount * 3];

        var currentVertex = Vector3.forward;
        vertices[0] = position;
        var vertexIndex = 1;
        var triangleIndex = 0;
        var stepAngle = (360f / VerticesCount) * Mathf.Deg2Rad;
        for (var i = 0; i <= VerticesCount; i++)
        {
            if (Physics.Raycast(position, (position + currentVertex).normalized, out var hit, _radius))
                vertices[vertexIndex] = hit.point;
            else
                vertices[vertexIndex] = position + currentVertex * _radius;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex;
                triangles[triangleIndex + 2] = vertexIndex - 1;
                triangleIndex += 3;
            }

            vertexIndex++;
            currentVertex = currentVertex.RotateInPlane(stepAngle);
        }

        _generatedMesh.vertices = vertices;
        _generatedMesh.triangles = triangles;

        return _generatedMesh;
    }
}