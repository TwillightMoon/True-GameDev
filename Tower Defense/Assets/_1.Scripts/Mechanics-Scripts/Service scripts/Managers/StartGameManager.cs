using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [Header("Компоненты")]
    [SerializeField] private WalletScript _walletScript;

    [Header("Свойства уровня")]
    [SerializeField] private int _startBalance;

    private void Start()
    {
        _walletScript.SetCurrentBalace(_startBalance);
    }
}
