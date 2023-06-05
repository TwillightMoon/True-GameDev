using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Structs.WaveStruct;

public class WaveManager : Singleton<WaveManager>
{
    public static UnityEvent onWaveChanged = new UnityEvent();

    [Header("Описание волн")]
    [SerializeField] private Wave[] _waves;
    private int _currentWave = 0;

    [Header("Позиции ключевых объектов")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parentForUnits;

    [Header("Параметры")]
    [Tooltip("Время между созданием отдельных юнитов")]
    [SerializeField] private float _timeBetweenUnitSpawn;

    private int _unitsOnScreen = 0;

    public int waveCount => _waves.Length;

    private Coroutine groupSpawner;

    private void Awake()
    {
        GlobalEvents.onEnemyDeath.AddListener(UnitOnScreenDecrease);
    }

    public void SpawnStart()
    {
        StartCoroutine(waveSpawn(_waves[0]));
    }

    private IEnumerator waveSpawn(Wave currentWave)
    {
        onWaveChanged.Invoke();

        int i = 0;

        groupSpawner = StartCoroutine(groupSpawn(currentWave.GetUnitGroup(i)));

        while(i < currentWave.groupCount-1)
        {
            if(groupSpawner != null)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenGroups);
            groupSpawner = StartCoroutine(groupSpawn(currentWave.GetUnitGroup(++i)));
        }

        if(_currentWave < _waves.Length-1)
           StartCoroutine(waintForNextWave(currentWave.timeForWave));
    }

    private IEnumerator groupSpawn(UnitGroup unitGroup)
    {
        Queue<Transform> path = PathGenerator.instance.GeneratePath();
        Transform groupParent = CreateParentForGroup();
        
        for (int i = 0; i < unitGroup.unitCount; i++)
        {
            Instantiate(unitGroup.Get(i), _spawnPoint.position, Quaternion.identity, groupParent).MoveTo(path);
            UnitOnScreenIncrease();
            yield return new WaitForSeconds(_timeBetweenUnitSpawn);
        }

        groupSpawner = null;
    }

    private IEnumerator waintForNextWave(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(waveSpawn(_waves[++_currentWave]));
    }

    private Transform CreateParentForGroup()
    {
        Transform parentForGroup = new GameObject("UnitGroup").transform;
        parentForGroup.parent = _parentForUnits.transform;
        return parentForGroup;
    }
    private void UnitOnScreenIncrease()
    {
        _unitsOnScreen++;
    }
    private void UnitOnScreenDecrease()
    {
        _unitsOnScreen--;
    }
}
