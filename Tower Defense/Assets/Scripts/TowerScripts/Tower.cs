using UnityEngine;
using TowerStats;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Tower : MonoBehaviour
{
    [Header("Характеристика башни на каждом уровне")]
    [SerializeField] private TowerStatsInfo[] towerLevels;

    [Header("Компоненты")]
    private CircleCollider2D _combarRadius;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private Levels currentLevelIndex = Levels.First;

    private void OnValidate()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;

        TowerStatsInfo currentLevel = towerLevels[Convert.ToByte(currentLevelIndex)];
        if (currentLevel)
        {
            _combarRadius.radius = towerLevels[Convert.ToByte(currentLevelIndex)].combatRadius;
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _combarRadius = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody2D.bodyType = RigidbodyType2D.Static;

        TowerStatsInfo currentLevel = towerLevels[Convert.ToByte(currentLevelIndex)];
        if (currentLevel)
        {
            _combarRadius.radius = towerLevels[Convert.ToByte(currentLevelIndex)].combatRadius;
        }
    }
}
