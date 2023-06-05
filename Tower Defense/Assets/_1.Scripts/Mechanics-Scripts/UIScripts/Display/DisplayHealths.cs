using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHealths : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthsPointText;

    private void Awake()
    {
        StartGameManager.onHealthChange.AddListener(UpdateText);
    }

    private void UpdateText(int text)
    {
        _healthsPointText.text = CacheStrings.GetCacheNum(text);
    }
}
