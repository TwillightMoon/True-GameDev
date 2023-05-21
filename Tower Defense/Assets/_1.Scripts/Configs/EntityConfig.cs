using StatsEnums;
using UnityEngine;

/** Пространство имен конфигурационных классов.
 *  Пространство имён для классов-конфигов. 
 *  К этому пространству имён относятся классы, наследующиеся от EntityConfig.
 */
namespace ConfigClasses
{
    public abstract class EntityConfig : ScriptableObject
    {
        [Header("Информационные характеристики")]
        [SerializeField]
        [Tooltip("Уровень")]
        private Levels _towerLevel; /**< enum variable. Уровень, к которому относятся хар-ки */
        [SerializeField]
        [Tooltip("Спрайт")]
        private Sprite _towerSprite; /**< Sprite variable. Отображаемый спрайт постройки */
        [Space]
        [Tooltip("Радиус действия")]
        [SerializeField]
        private float _activeRadius; /**< float variable. Радиус действия башни */

        /**
         * Геттер, возвращающий float переменную радиуса действия _combatRadius
         */
        public float combatRadius => _activeRadius;

        /**
        * Геттер, возвращающий объект перечисления Levels _towerLevel
        */
        public Levels towerLevel => _towerLevel;
        /**
        * Геттер, возвращающий Sprite переменную _towerSprite
        */
        public Sprite towerSprite => _towerSprite;
    }
}
