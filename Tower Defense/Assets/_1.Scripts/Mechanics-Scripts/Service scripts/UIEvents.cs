using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GlobalUIEvents
{
    public class UIEvents : MonoBehaviour
    {
        //События обработки касаний
        public static UnityEvent<short> onEmptyPositionSelected = new UnityEvent<short>();
        public static UnityEvent<short> onOccupiedPositionSelect = new UnityEvent<short>();
        public static UnityEvent onDeselectPosition = new UnityEvent();
        public static UnityEvent onGamePause = new UnityEvent();
        public static UnityEvent onGameResume = new UnityEvent();

        //События нажатия кнопки
        public static UnityEvent onButtonClick = new UnityEvent();

        //События изменения баланса
        public static UnityEvent<int> onBalanceChange = new UnityEvent<int>();


        public static void SendSelectedEmptyBlock(short pointIndex) => onEmptyPositionSelected.Invoke(pointIndex);

        public static void SendDeselectBlock() => onDeselectPosition.Invoke();

        public static void SendSelectedOccupiedBlock(short pointIndex) => onOccupiedPositionSelect.Invoke(pointIndex);

        public static void SendButtonClick() => onButtonClick.Invoke();

        public static void SendBalanceChange(int newBalance)
        {
            onBalanceChange.Invoke(newBalance);
        } 

        public static void Pause(bool flag)
        {
            if(flag == true)
            {
                SendPauseGame();
            }
            else
            {
                SendResumeGame();
            }
        }

        private static void SendPauseGame()
        {
            Debug.Log("Pause");
            Time.timeScale = 0;
            onGamePause.Invoke();
        }
        private static void SendResumeGame()
        {
            Time.timeScale = 1;
            onGameResume.Invoke();
        }
    }
}
