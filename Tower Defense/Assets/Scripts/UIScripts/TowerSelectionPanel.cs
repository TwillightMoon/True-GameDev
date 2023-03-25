using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TowerSelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Vector2 _offset;

    [SerializeField] private Transform parentForTower;

    private DefensivePosition _currentPosition;


    private void Awake()
    {
        UIEvents.onEmptyPositionSelected.AddListener(SetActive);
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
        _panel.SetActive(false);
        _currentPosition = null;
    }

    public void CreateTower(CombatTower tower)
    {
        _currentPosition.SetBuilding(tower, parentForTower);
    }
}