using UnityEngine;
using GlobalUIEvents;

public class InteractionPanelWithTower : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private BuildingBuilder _towerManager;
    [SerializeField] private Vector2 _offset;

    private TacticalPoint _currentTacticalPoint;

    private void Awake()
    {
        UIEvents.onOccupiedPositionSelect.AddListener(SetActive);
        UIEvents.onDeselectPosition.AddListener(SetDeactive);

        _panel.SetActive(false);
    }

    private void SetActive(TacticalPoint pos)
    {
        _currentTacticalPoint = pos;
        transform.position = (Vector2)pos.transform.position + _offset;

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
        _towerManager.UpgradeTower(_currentTacticalPoint);
    }
    public void DestructBuilding()
    {
        _towerManager.SellBuild(_currentTacticalPoint);
    }
}
