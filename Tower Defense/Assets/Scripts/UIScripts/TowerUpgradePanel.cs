using UnityEngine;

public class TowerUpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    private DefensivePosition _currentPosition;

    private void Awake()
    {
        UIEvents.onOccupiedPositionSelect.AddListener(SetActive);
        UIEvents.onDeselectPosition.AddListener(SetDeactive);

        _panel.SetActive(false);
    }

    private void SetActive(DefensivePosition pos)
    {
        _currentPosition = pos;
        transform.position = (Vector2)pos.transform.position + _offset;

        _panel.SetActive(true);
    }
    private void SetDeactive()
    {
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
            _currentPosition = null;
        }
    }

    public void UpgradeTower()
    {
        _currentPosition.GetBuilding().SetLevel();
    }
}
