using TowerStats;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class Buildings : MonoBehaviour, IStateChange
{
    [Header("Компоненты")]
    protected CircleCollider2D _combarRadiusCollider;
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;

    protected BuildingsConfig currentLevelCharacteristic;

    [Header("Характеристика постройки на каждом уровне")]
    [SerializeField] protected BuildingsConfig[] towerLevels;

    [Header("Состояния постройки")]
    [SerializeField] protected TowerState[] towerStates;
    protected TowerState currentState;


    protected void ChangeLevel(Levels newLevel)
    {
        int currentLevelIndex = Mathf.Clamp((int)newLevel, 0, towerLevels.Length - 1);

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
            if (towerStates[i] is T)
            {
                currentState = towerStates[i];
                break;
            }
        }

        currentState.StateStart();

        Debug.Log($"new state {currentState} is set.");
    }
}
