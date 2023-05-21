using StatsEnums.DamageTypes;
using Structs;
using UnityEngine;


namespace ConfigClasses
{
    /** Пространство имен конфигурационных классов, относящихся к постройкам.
    *   Конфигурационные классы, относящиеся к родительскому классу TowerConfig
    */
    namespace ConfigBuildings
    {
        /** Родительский класс
        *  Родительский класс, содержащий все характеристики для боевых построек
        */
        public abstract class TowerConfig : BuildingConfig
        {
            [Header("Боевые характеристики")]
            [SerializeField]
            protected DamageType m_damageType = DamageType.Physical; /**< enum variable. Тип урона. По дефолту DamageType.Physical*/
            [SerializeField]
            [Tooltip("Урон")]
            private MinMax _damage; /**< Damage variable. Структура с информаницей об уровен */
            [SerializeField]
            [Tooltip("Время на следующую атаку")]
            private float _attackRatePerSecond; /**< float variable. Время на следующий выстрел */

            public virtual DamageType GetDamageType() => m_damageType;

            /**
            * Геттер, возвращающий объект структуры Damage _damage
            */
            public MinMax damage => _damage;
            /**
             * Геттер, возвращающий float переменную времени на выстрел _fireRatePerSecond
             */
            public float fireRatePerSecond => _attackRatePerSecond;
        }
    }
}