using UnityEngine;

public class TowerSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    [SerializeField] private Transform parentForTower;

    private TacticalPoint _currentPosition;


    private void Awake()
    {
        UIEvents.onEmptyPositionSelected.AddListener(SetActive);
        UIEvents.onDeselectPosition.AddListener(SetDeactive);
        _panel.SetActive(false);
    }

    private void SetActive(TacticalPoint pos)
    {
        _currentPosition = pos;
        transform.position = (Vector2)pos.transform.position + _offset;
        _panel.SetActive(true);
    }
    private void SetDeactive()
    {
        if(_panel.activeSelf)
        {
            _panel.SetActive(false);
            _currentPosition = null;
        }
    }

    public void CreateTower(CombatTower tower)
    {
        _currentPosition.SetBuilding(tower, parentForTower);
    }
}
