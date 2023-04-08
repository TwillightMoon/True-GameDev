using UnityEngine;

using StatsEnums;
using DamageTypes;
using Structs;

/** Пространство имен конфигурационных классов.
 *  Пространство имён для классов-конфигов. 
 *  К этому пространству имён относятся классы, наследующиеся от ScriptableObject
 */
namespace ConfigClasses
{
    /** Пространство имен конфигурационных классов, относящихся к постройкам.
    *   Конфигурационные классы, относящиеся к родительскому классу BuildingsConfig
    */
    namespace BuildingConfig 
    {
        /** Родительский класс
        *  Родительский класс, содержащий все характеристики для построек
        */
        abstract public class BuildingsConfig : ScriptableObject
        {
            [Header("Основные свойства")]
            [SerializeField]
            [Tooltip("Уровень постройки")]
            private Levels _towerLevel; /**< enum variable. Уровень, к которому относятся хар-ки */
            [SerializeField]
            [Tooltip("Спрайт постройки")]
            private Sprite _towerSprite; /**< Sprite variable. Отображаемый спрайт постройки */

            [Header("Экономические свойства")]
            [SerializeField]
            [Tooltip("Стоимость")]
            private int _levelCost; /**< integer variable. Стоимость прокачки или покупки*/
            [SerializeField]
            [Tooltip("Сумма возврата при продаже")]
            private int _sellCost; /**< integer variable. Сумма возврата при продаже*/

            [Header("Бовые характеристики")]
            [SerializeField]
            [Tooltip("Урон постройки, наносимый противнику")]
            private Damage _damage; /**< Damage variable. Структура с информаницей об уровен */
            [Space]
            [SerializeField]
            [Tooltip("Время на следующий выстрел")]
            private float _fireRatePerSecond; /**< float variable. Время на следующий выстрел */
            [SerializeField]
            [Tooltip("Радиус действия постройки")]
            private float _combatRadius; /**< float variable. Радиус действия башни */

            protected DamageType m_damageType = DamageType.Physical; /**< enum variable. Тип урона. По дефолту DamageType.Physical*/

            /**
             * Геттер, возвращающий объект перечисления Levels _towerLevel
             */
            public Levels towerLevel => _towerLevel;

            /**
             * Геттер, возвращающий int переменную стоимости _levelCost
             */
            public int levelCost => _levelCost;

            /**
             * Геттер, возвращающий int переменную цены продажи _sellCost
             */
            public int sellCost => _sellCost;

            /**
             * Геттер, возвращающий Sprite переменную _towerSprite
             */
            public Sprite towerSprite => _towerSprite;

            /**
             * Геттер, возвращающий объект структуры Damage _damage
             */
            public Damage damage => _damage;
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
