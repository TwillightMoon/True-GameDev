using UnityEngine;

using StatsEnums;
using DamageTypes;
using Structs;

abstract public class BuildingsConfig : ScriptableObject
{
    [Header("Основные свойства")]
    [SerializeField][Tooltip("Уровень постройки")] private Levels _towerLevel;
    [SerializeField][Tooltip("Спрайт постройки")] private Sprite _towerSprite;

    [Header("Экономические свойства")]
    [SerializeField][Tooltip("Стоимость")] private int _levelCost;
    [SerializeField][Tooltip("Сумма возврата при продаже")] private int _sellCost;

    [Header("Бовые характеристики")]
    [SerializeField][Tooltip("Урон постройки, наносимый противнику")] private Damage _damage;
    [Space]
    [SerializeField][Tooltip("Время на следующий выстрел")] private float _fireRatePerSecond;
    [SerializeField][Tooltip("Радиус действия постройки")] private float _combatRadius;

    protected DamageType m_damageType = DamageType.Physical;

    public Levels towerLevel => _towerLevel;
    public int levelCost => _levelCost;
    public int sellCost => _sellCost;
    public Sprite towerSprite => _towerSprite;

    public virtual DamageType GetDamageType() => m_damageType;

    public Damage damage => _damage;
    public float fireRatePerSecond => _fireRatePerSecond;
    public float combatRadius => _combatRadius;
}