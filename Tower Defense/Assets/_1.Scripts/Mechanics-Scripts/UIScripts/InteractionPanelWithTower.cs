using UnityEngine;
using GlobalUIEvents;
using Managers;

public class InteractionPanelWithTower : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    private TacticalPoint _currentTacticalPoint;

    private void Awake()
    {
        UIEvents.onOccupiedPositionSelect.AddListener(SetActive);
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
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
            _currentTacticalPoint = null;
        }
    }

    public void UpgradeTower()
    {
        BuildingManager.instance.UpgradeTower(_currentTacticalPoint);
    }
    public void DestructBuilding()
    {
        BuildingManager.instance.SellBuild(_currentTacticalPoint);
    }
}
