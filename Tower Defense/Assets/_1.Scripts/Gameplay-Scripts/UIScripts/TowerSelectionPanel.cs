using UnityEngine;
using Buildings;
using GlobalUIEvents;
using Managers;

public class TowerSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    [SerializeField] private BuildingManager buildingBuilder;

    private TacticalPoint _currentTacticalPoint;


    private void Awake()
    {
        UIEvents.onEmptyPositionSelected.AddListener(SetActive);
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
        if(_panel.activeSelf)
        {
            _panel.SetActive(false);
            _currentTacticalPoint = null;
        }
    }

    public void CreateTower(CombatTower tower)
    {
        buildingBuilder.Build(_currentTacticalPoint, tower);
    }
}
