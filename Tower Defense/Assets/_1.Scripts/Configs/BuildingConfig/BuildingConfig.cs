using UnityEngine;

namespace ConfigClasses
{
    /** Пространство имен конфигурационных классов.
    *  Пространство имён для классов-конфигов. 
    *  К этому пространству имён относятся классы, наследующиеся от ConfigBuilding.
    */
    namespace ConfigBuildings
    {
        public abstract class BuildingConfig : EntityConfig
        {
            [Header("Экономические свойства")]
            [SerializeField]
            [Tooltip("Стоимость")]
            private int _levelCost; /**< integer variable. Стоимость прокачки или покупки*/
            [SerializeField]
            [Tooltip("Сумма возврата при продаже")]
            private int _sellCost; /**< integer variable. Сумма возврата при продаже*/

            /**
            * Геттер, возвращающий int переменную стоимости _levelCost
            */
            public int levelCost => _levelCost;

            /**
            * Геттер, возвращающий int переменную цены продажи _sellCost
            */
            public int sellCost => _sellCost;
        }
    }
}