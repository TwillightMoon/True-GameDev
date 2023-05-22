namespace Units
{
    namespace UnitStates
    {
        public abstract class UnitState : State
        {
            protected Unit parentUnit; /**< Unit variable. Родительский юнит, к которой относится состояние. */

            public virtual void Init(Unit parentUnit)
            {
                if (!this.parentUnit)
                    this.parentUnit = parentUnit;
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