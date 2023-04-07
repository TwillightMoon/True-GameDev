using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CombatRadiusVisualizer : MonoBehaviour
{
    [Header("Свойства")]
    [SerializeField] private int _segments;
    [SerializeField] private float _lineWidth;
    [SerializeField] private Color _lineColor;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _segments + 1;

        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;

        _lineRenderer.startColor = _lineColor;
        _lineRenderer.endColor = _lineColor;

    }

    public void ActiveLine(bool flag)
    {
        _lineRenderer.enabled = flag;
    }

    public void SetLine(float radius)
    {
        Vector3[] points = new Vector3[_segments + 1];
        float angle = 0f;

        for (int i = 0; i < _segments + 1; i++)
        {
            float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            points[i] = new Vector3(x, y, 0f) + transform.position;
            angle += 360f / _segments;
        }

        _lineRenderer.SetPositions(points);
    }
}
