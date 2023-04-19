using Buildings;
using ConfigClasses.BuildingConfig;
using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CombatRadiusVisualizer : MonoBehaviour, IModule
{
    [Header("Свойства")]
    [SerializeField] private int _segments;

    [SerializeField] private float _lineWidth;
    [SerializeField] private Color _lineColor;

    private float radius; /**< Float. Радиус окружности. */
    private LineRenderer _lineRenderer; /**< LineRenderer. Компонент, отрисовывающий линию. */

    private Building _parentBuilding;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _segments + 1;

        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;

        _lineRenderer.startColor = _lineColor;
        _lineRenderer.endColor = _lineColor;

        SetParent();

        _parentBuilding.onSelect.AddListener(ActiveLine);
        _parentBuilding.onDeselect.AddListener(DeactiveLine);

    }

    private void OnEnable()
    {
        _parentBuilding.AddModule(this);
    }
    private void OnDisable()
    {
        _parentBuilding.RemoveModule(this);
    }

    private void SetParent()
    {
        try
        {
            _parentBuilding = (Building)FindParentHub();
        }
        catch (InvalidCastException e)
        {
            Debug.LogError("Произошла ошибка приведения типов: " + e.Message);

        }
    }

    public void ActiveLine()
    {
        _lineRenderer.enabled = true;
    }
    public void DeactiveLine()
    {
        _lineRenderer.enabled = false;
    }

    private void SetLine()
    {
        Vector3[] points = new Vector3[_segments + 1];
        float angle = 0f;

        for (int i = 0; i < _segments + 1; i++)
        {
            float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float y = Mathf.Cos(angle * Mathf.Deg2Rad) * (radius * 0.90F);
            points[i] = new Vector3(x, y, 0f) + transform.position;
            angle += 360f / _segments;
        }

        _lineRenderer.SetPositions(points);
    }

    public void SetSpecifications(BuildingsConfig specifications)
    {
        radius = specifications.combatRadius;
        SetLine();
    }

    public IModuleHub FindParentHub()
    {
        IModuleHub moduleHub = transform.GetComponentInParent<IModuleHub>();

        return moduleHub;
    }
}
