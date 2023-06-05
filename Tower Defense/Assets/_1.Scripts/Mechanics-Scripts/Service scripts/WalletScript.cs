using UnityEngine;
using GlobalUIEvents;
using Units.EnemyScrips;

public class WalletScript : Singleton<WalletScript>
{
    private int _currentBalance = 0;

    private void Awake()
    {
        GlobalEvents.onEnemyDeath.AddListener(AwardForKill);
    }

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

    private void AwardForKill(Enemy enemy)
    {
        AddToCurrentBalace(enemy.unitCharacteristics.rewardForMurder);
    }
}
