using UnityEngine;
using Buildings;
using GlobalUIEvents;
using Managers;

public class TowerSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    private TacticalPoint _currentTacticalPoint;


    private void Awake()
    {
        UIEvents.onEmptyPositionSelected.AddListener(SetActive);
        UIEvents.onDeselectPosition.AddListener(SetDeactive);
        _panel.SetActive(false);
    }

    private void SetActive(short positionIndex)
    {
        _currentTacticalPoint = TacticalPoints.instance.Get(positionIndex);
        transform.position = (Vector2)_currentTacticalPoint.transform.position + _offset;
        _panel.SetActive(true);
    }
    private void SetDeactive()
    {
        if(_panel.activeSelf)
        {
            _panel.SetActive(false);
            _currentTacticalPoint = null;
        }
    }

    public void CreateTower(Building tower)
    {
        BuildingManager.instance.Build(_currentTacticalPoint, tower);
    }
}
