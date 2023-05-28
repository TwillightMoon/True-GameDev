using UnityEngine;

public class TacticalPoints : Singleton<TacticalPoints>
{
    [SerializeField] private Transform _parentOfPoints;

    private TacticalPoint[] _tacticalPoints;

    private void Awake()
    {
        _tacticalPoints = _parentOfPoints.GetComponentsInChildren<TacticalPoint>();

        for(int i = 0; i < _tacticalPoints.Length; i++)
        {
            _tacticalPoints[i].poinIndex = (short)i;
        }
    }

    public TacticalPoint Get(short index) => _tacticalPoints[index];
}