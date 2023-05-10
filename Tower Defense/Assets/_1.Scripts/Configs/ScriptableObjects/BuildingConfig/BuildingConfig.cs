using StatsEnums;
using UnityEngine;

/** Пространство имен конфигурационных классов.
 *  Пространство имён для классов-конфигов. 
 *  К этому пространству имён относятся классы, наследующиеся от ScriptableObject.
 */
namespace ConfigClasses
{
    namespace ConfigBuildings
    {
        public class BuildingConfig : ScriptableObject
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
        }
    }
}