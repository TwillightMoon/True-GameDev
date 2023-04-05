using UnityEngine;
using UnityEngine.Events;

namespace GlobalUIEvents
{
    public class UIEvents : MonoBehaviour
    {
        //События обработки касаний
        public static UnityEvent<TacticalPoint> onEmptyPositionSelected = new UnityEvent<TacticalPoint>();
        public static UnityEvent<TacticalPoint> onOccupiedPositionSelect = new UnityEvent<TacticalPoint>();
        public static UnityEvent onDeselectPosition = new UnityEvent();

        //События нажатия кнопки
        public static UnityEvent onButtonClick = new UnityEvent();

        //События изменения баланса
        public static UnityEvent<int> onBalanceChange = new UnityEvent<int>();


        public static void SendSelectedEmptyBlock(TacticalPoint blockPosition) => onEmptyPositionSelected.Invoke(blockPosition);

        public static void SendDeselectBlock() => onDeselectPosition.Invoke();

        public static void SendSelectedOccupiedBlock(TacticalPoint blockPosition) => onOccupiedPositionSelect.Invoke(blockPosition);

        public static void SendButtonClick() => onButtonClick.Invoke();

        public static void SendBalanceChange(int newBalance)
        {
            onBalanceChange.Invoke(newBalance);
        } 
    }
}
