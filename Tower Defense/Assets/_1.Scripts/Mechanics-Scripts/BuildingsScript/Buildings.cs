using StatsEnums;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Buildings : MonoBehaviour, IStateChange
{
    [Header("Компоненты")]
    [SerializeField] protected EnemyDetector _enemyDetector;

    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;

    [Header("Характеристика постройки")]
    [SerializeField] protected BuildingsConfig _buildingCharacteristic;

    [Header("Характеристика постройки на каждом уровне")]
    private int _currentLevelIndex = 0;
    [SerializeField] protected BuildingsConfig[] _towerLevels;

    [Header("Состояния постройки")]
    [SerializeField] protected TowerState[] towerStates;
    protected TowerState currentState;

    public EnemyDetector enemyDetector => _enemyDetector;
    public BuildingsConfig buildingsConfig => _buildingCharacteristic;


    protected void Init()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody2D.bodyType = RigidbodyType2D.Static;

        SortLevels();
    }


    public virtual void IntoCombat()
    {
        ChangeState<TowerCombat>();
    }

    public void SetLevel(Levels newLevel)
    {
        _currentLevelIndex = Mathf.Clamp((int)newLevel, 0, _towerLevels.Length - 1);

        if (_towerLevels[_currentLevelIndex] && _towerLevels[_currentLevelIndex].towerLevel == newLevel)
        {
            _buildingCharacteristic = _towerLevels[_currentLevelIndex];
            Debug.Log(string.Format("Set new Level: {0}", newLevel));
            SetNewCharacteristics();
        }
    }
    public void SetLevel()
    {
        int newLevel = Mathf.Clamp(_currentLevelIndex+1, 0, _towerLevels.Length - 1);

        if ((newLevel > _currentLevelIndex) && _towerLevels[_currentLevelIndex] )
        {
            _currentLevelIndex = newLevel;
            _buildingCharacteristic = _towerLevels[_currentLevelIndex];
            Debug.Log(string.Format("Set new Level: {0}", _towerLevels[_currentLevelIndex]));
            SetNewCharacteristics();
        }
    }

    private void SetNewCharacteristics()
    {
        if (_enemyDetector)
            _enemyDetector.combatRadius = _buildingCharacteristic.combatRadius;
        else
            Debug.LogError("EnemyDetector не установлен!");

        if (_spriteRenderer)
            _spriteRenderer.sprite = _buildingCharacteristic.towerSprite;
        else
            Debug.LogError("SpriteRenderer не установлен!");
    }


    //Реализация контракта IStateChange
    public void ChangeState<T>() where T : State
    {
        TowerState newState = FindState<T>();
        if (newState)
        {
            if (currentState) currentState.StateStop();

            currentState = newState;
            currentState.StateStart();
        }

        Debug.Log($"new state {currentState} is set.");
    }

    //Служебные методы
    private void SortLevels()
    {
        for (int i = 1; i < _towerLevels.Length; i++)
        {
            BuildingsConfig cacheConfig = _towerLevels[i];

            int j = i - 1;
            for (; j >= 0 && _towerLevels[j].towerLevel > cacheConfig.towerLevel; j--)
                _towerLevels[j + 1] = _towerLevels[j];

            _towerLevels[j + 1] = cacheConfig;
        }

        Debug.Log("Levels was sorted");
    }

    private TowerState FindState<T>() where T : State
    {
        TowerState findResult = null;

        for(int i = 0; i < towerStates.Length; i++)
            if (towerStates[i] is T)
                findResult = towerStates[i];

        return findResult;
    }
}
