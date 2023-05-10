using UnityEngine;

using DamageTypes;
using Structs;


namespace ConfigClasses
{
    /** Пространство имен конфигурационных классов, относящихся к постройкам.
    *   Конфигурационные классы, относящиеся к родительскому классу TowerConfig
    */
    namespace ConfigBuildings
    {
        /** Родительский класс
        *  Родительский класс, содержащий все характеристики для построек
        */
        abstract public class TowerConfig : BuildingConfig
        {
            [Header("Бовые характеристики")]
            [SerializeField]
            [Tooltip("Урон постройки, наносимый противнику")]
            private MinMax _damage; /**< Damage variable. Структура с информаницей об уровен */
            [Space]
            [SerializeField]
            [Tooltip("Время на следующий выстрел")]
            private float _fireRatePerSecond; /**< float variable. Время на следующий выстрел */
            [SerializeField]
            [Tooltip("Радиус действия постройки")]
            private float _combatRadius; /**< float variable. Радиус действия башни */

            protected DamageType m_damageType = DamageType.Physical; /**< enum variable. Тип урона. По дефолту DamageType.Physical*/

            /**
             * Геттер, возвращающий объект структуры Damage _damage
             */
            public MinMax damage => _damage;
            /**
             * Геттер, возвращающий float переменную времени на выстрел _fireRatePerSecond
             */
            public float fireRatePerSecond => _fireRatePerSecond;
            /**
             * Геттер, возвращающий float переменную радиуса действия _combatRadius
             */
            public float combatRadius => _combatRadius;


            /**
             * Метод, возвращающий объект перечисления DamageType m_damageType
             */
            public virtual DamageType GetDamageType() => m_damageType;
        }
    }
}