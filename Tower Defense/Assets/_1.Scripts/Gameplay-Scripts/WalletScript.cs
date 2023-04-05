using UnityEngine;
using GlobalUIEvents;

public class WalletScript : MonoBehaviour
{
    private int _currentBalance = 0;

    public int currentBalance => _currentBalance;
    public void SetCurrentBalace(int newBalace) 
    {
        Debug.Log("SetBalance");
        _currentBalance = newBalace > 0 ? newBalace : 0;
        UIEvents.SendBalanceChange(_currentBalance);
    }
    public void AddToCurrentBalace(int accrualAmount)
    {
        _currentBalance += accrualAmount > 0 ? accrualAmount : 0;
        UIEvents.SendBalanceChange(_currentBalance);
    }
    public void SubFromCurrentBalance(int deductionAmount)
    {
        _currentBalance -= deductionAmount > 0 ? deductionAmount : 0;
        UIEvents.SendBalanceChange(_currentBalance);
    }
}
