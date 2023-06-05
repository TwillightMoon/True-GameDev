using TMPro;
using GlobalUIEvents;
using UnityEngine;

public class DisplayingBalance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balanceText;

    private void Awake()
    {
        UIEvents.onBalanceChange.AddListener(SetNewBalance);
    }

    private void SetNewBalance(int newBalance)
    {
        _balanceText.text = CacheStrings.GetCacheNum(newBalance);
    }
}
