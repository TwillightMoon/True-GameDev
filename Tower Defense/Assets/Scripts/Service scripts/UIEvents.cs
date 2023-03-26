using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UnityEvent<DefensivePosition> onEmptyPositionSelected = new UnityEvent<DefensivePosition>();
    public static UnityEvent<DefensivePosition> onOccupiedPositionSelect = new UnityEvent<DefensivePosition>();
    public static UnityEvent onDeselectPosition = new UnityEvent();

    public static UnityEvent onButtonClick = new UnityEvent();

    public static void SendSelectedEmptyBlock(DefensivePosition blockPosition) => onEmptyPositionSelected.Invoke(blockPosition);

    public static void SendDeselectBlock() => onDeselectPosition.Invoke();

    public static void SendSelectedOccupiedBlock(DefensivePosition blockPosition) => onOccupiedPositionSelect.Invoke(blockPosition);

    public static void SendButtonClick() => onButtonClick.Invoke();

}
