using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayingWave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textWave;

    private int _currentWave = 0;
    private int _wavesCount = 0;

    private void Awake()
    {
        _wavesCount = WaveManager.instance.waveCount;
        WaveManager.onWaveChanged.AddListener(UpdateWaves);
    }

    private void UpdateWaves()
    {
        _textWave.text = $"{CacheStrings.GetCacheNum(++_currentWave)}/{CacheStrings.GetCacheNum(_wavesCount)}";
    }
}
