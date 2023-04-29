using TMPro;
using GlobalUIEvents;
using UnityEngine;

public class DisplayingBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balanceText;

    private string[] _balanceArray;
    private const int _MAX_BALANCE = 3000;

    private void Awake()
    {
        InitBalanceArray();

        UIEvents.onBalanceChange.AddListener(SetNewBalance);
    }

    private void SetNewBalance(int newBalance)
    {
        if (newBalance < _MAX_BALANCE)
            _balanceText.text = _balanceArray[newBalance];
        else
            _balanceText.text = newBalance.ToString();
    }

    private void InitBalanceArray()
    {
        if(_balanceArray == null)
        {
            _balanceArray = new string[_MAX_BALANCE];

            for (int i = 0; i < _MAX_BALANCE; i++)
                _balanceArray[i] = i.ToString();
        }
    }
}
