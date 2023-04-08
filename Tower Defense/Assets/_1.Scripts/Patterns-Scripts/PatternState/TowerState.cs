using UnityEngine;

namespace Buildings
{
    /** Пространство имён, содержащее классы, реализующие состояния башен. */
    namespace TowerStates
    {
        /** Родительский класс для всех состояний башен. */
        public abstract class TowerState : State
        {
            protected CombatTower parentTower; /**< CombatTower variable. Родительская башня, к которой относится состояние. */

            /** Метод инициализации состояния.
             * @param parentTower. Родительская башня.
             */
            public void Init(CombatTower parentTower)
            {
                if (!this.parentTower)
                    this.parentTower = parentTower;
            }

            /**Метод старта состояния.
             * Метод должен вызываться каждый раз, когда состояние становится действующим.
             */
            public abstract override void StateStart();
            /**Метод остановки состояния.
             * Метод должен вызываться каждый раз, когда состояние останавливается.
             */
            public abstract override void StateStop();

            /**Метод смены состояния.
             * Дочерние классы переписывают его под свои нужды.
             */
            public abstract override void ChangeState<T>();
        }
    }
}

