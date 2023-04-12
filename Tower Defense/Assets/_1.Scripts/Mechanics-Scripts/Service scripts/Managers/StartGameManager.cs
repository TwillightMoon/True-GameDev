using UnityEngine;

namespace Managers
{
    /** Менеджер, содержащий и применяющий все настроки к уровню */
    public class StartGameManager : MonoBehaviour
    {
        [Header("Компоненты")]
        [SerializeField] private WalletScript _walletScript; /**< WalletScript variable. Объект, содержащий текующий баланс игрока. */

        [Header("Свойства уровня")]
        [SerializeField] private int _startBalance; /**< Integer variable. Начальный баланс на уровне */

        private void Start()
        {
            _walletScript.SetCurrentBalace(_startBalance);
        }
    }
}

