using UnityEngine;
using TowerStats;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Tower : MonoBehaviour, IStateChange
{
    [Header("Компоненты")]
    private CircleCollider2D _combarRadiusCollider;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private TowerStatsInfo currentLevelCharacteristic;

    [Header("Характеристика башни на каждом уровне")]
    [SerializeField] private TowerStatsInfo[] towerLevels;

    [Header("Состояния башни")]
    [SerializeField] private TowerState[] towerStates;
    private TowerState currentState;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _combarRadiusCollider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _combarRadiusCollider.isTrigger = true;

        ChangeLevel(Levels.First);

        if(towerStates.Length != 0)
        {
            for (int i = 0; i < towerStates.Length; i++)
                towerStates[i].Init(this);
        }

        ChangeState<TowerChill>();
    }

    private void ChangeLevel(Levels newLevel)
    {
        int currentLevelIndex = Mathf.Clamp((int)newLevel, 0, towerLevels.Length-1);

        if (towerLevels[currentLevelIndex] && towerLevels[currentLevelIndex].towerLevel == newLevel)
        { 
            currentLevelCharacteristic = towerLevels[currentLevelIndex];
            Debug.Log(string.Format("Set new Level: {0}", newLevel));
            SetNewCharacteristics();
        }
    }
    private void SetNewCharacteristics()
    {
        if (_combarRadiusCollider)
            _combarRadiusCollider.radius = currentLevelCharacteristic.combatRadius;
        if (_spriteRenderer)
            _spriteRenderer.sprite = currentLevelCharacteristic.towerSprite;
    }

    public void ChangeState<T>() where T : State
    {
        if (currentState) currentState.StateStop();

        for (int i = 0; i < towerStates.Length; i++)
        {
            if(towerStates[i] is T)
            {
                currentState = towerStates[i];
                break;
            }
        }

        currentState.StateStart();

        Debug.Log($"new state {currentState} is set.");
    }
}
