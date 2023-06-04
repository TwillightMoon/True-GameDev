using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    /** Менеджер, содержащий и применяющий все настроки к уровню */
    public class StartGameManager : Singleton<StartGameManager>
    {
        [Header("Компоненты")]

        [Header("Свойства уровня")]
        [SerializeField] private int _startBalance; /**< Integer variable. Начальный баланс на уровне */

        private void Start()
        {
            Time.timeScale = 1.0F;

            WalletScript.instance.SetCurrentBalace(_startBalance);
        }
    }
}

