using StatsEnums.DamageTypes;
using StatsEnums.DamageRistances;
using Structs;
using UnityEngine;

namespace ConfigClasses
{
    namespace UnitConfigs
    {
        [CreateAssetMenu(fileName = "TypicalUnit", menuName = "Gameplay/Units/New Unit")]
        public class UnitConfig : EntityConfig
        {
            [Header("Жизненные показатели")]
            [SerializeField] private int _healthPoints;

            [Header("Мобильные характеристики")]
            [SerializeField] private int _velocity;

            [Header("Защитные характеристики")]
            [SerializeField] private DamageResistance _physicalDamageResistance;
            [SerializeField] private DamageResistance _energyDamageResistance;
            [SerializeField] private DamageResistance _areaDamageResistance;
            [SerializeField] private DamageResistance _amyDamageResistance;

            [Header("Боевые характеристики")]
            [SerializeField]
            protected DamageType m_damageType = DamageType.Physical; /**< enum variable. Тип урона. По дефолту DamageType.Physical*/
            [SerializeField]
            [Tooltip("Урон")]
            private MinMax _damage; /**< Damage variable. Структура с информаницей об уровен */
            [SerializeField]
            [Tooltip("Время на следующую атаку")]
            private float _attackRatePerSecond; /**< float variable. Время на следующий выстрел */

            [Header("Экономические свойства")]
            [SerializeField] private int _rewardForMurder;
            [SerializeField] private int _damageToBase;

            public int healthPoints => _healthPoints;
            public int velocity => _velocity;

            public DamageResistance physicalDamageResistance => _physicalDamageResistance;
            public DamageResistance energyDamageResistance => _energyDamageResistance;
            public DamageResistance areaDamageResistance => _areaDamageResistance;
            public DamageResistance amyDamageResistance => _amyDamageResistance;

            /**
            * Геттер, возвращающий объект структуры DamageType m_damageType
            */
            public DamageType GetDamageType() => m_damageType;
            /**
            * Геттер, возвращающий объект структуры MinMax _damage
            */
            public MinMax damage => _damage;
            /**
             * Геттер, возвращающий float переменную времени на выстрел _fireRatePerSecond
             */
            public float fireRatePerSecond => _attackRatePerSecond;

            public int rewardForMurder => _rewardForMurder;
            public int damageToBase => _damageToBase;
        }
    }
}