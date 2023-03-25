using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UnityEvent<DefensivePosition> onEmptyPositionSelected = new UnityEvent<DefensivePosition>();
    public static UnityEvent onDeselectPosition = new UnityEvent();

    public static UnityEvent<DefensivePosition> onOccupiedPositionSelect = new UnityEvent<DefensivePosition>();

    [SerializeField] private Transform _selectTowerPanel;

    public static void SendSelectedEmptyBlock(DefensivePosition blockPosition)
    {
        onEmptyPositionSelected.Invoke(blockPosition);
    }

    public static void SendDeselectBlock()
    {
        onDeselectPosition.Invoke();
    }

    public static void SendSelectedOccupiedBlock(DefensivePosition blockPosition)
    {
        onOccupiedPositionSelect.Invoke(blockPosition);
    }
}
