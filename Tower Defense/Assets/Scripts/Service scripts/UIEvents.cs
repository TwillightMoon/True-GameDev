using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UnityEvent<DefensivePosition> onEmptyPositionSelected = new UnityEvent<DefensivePosition>();
    public static UnityEvent onDeselectPosition = new UnityEvent();

    [SerializeField] private Transform _selectTowerPanel;

    public static void SendSelectedBlock(DefensivePosition blockPosition)
    {
        onEmptyPositionSelected.Invoke(blockPosition);
    }
    public static void SendDeselectBlock()
    {
        onDeselectPosition.Invoke();
    }
}
