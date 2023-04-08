using UnityEngine;

namespace Buildings
{
    namespace TowerStates
    {
        /** Состояние, определяющее поведение башни в состоянии боя. */
        public class TowerCombat : TowerState
        {
            [Header("Префабы")]
            [SerializeField] GameObject bullet /**< GameObject variable. Префаб пули. */;

            private Enemy _currentEnemy /**< Enemy variable. Переменная, хранящего текущую цель для атаки. */;

            /**Метод старта состояния. 
             * Метод берет первого врага, вошедшего в зону действия.
             */
            public override void StateStart()
            {
                _currentEnemy = parentTower.enemyDetector.GetNextEnemy();
                Debug.Log(_currentEnemy);
            }

            /**Метод остановки состояния. 
             * Метод сбрасывает значение переменной _currentEnemy.
             */
            public override void StateStop()
            {
                _currentEnemy = null;
            }

            /**Метод обновления в реальном времени.
             * Метод осуществляет проверку и атаку цели.
             * В случае отсутствия врага, меняет состояние на TowerChill.
             */
            public override void UpdateRun()
            {
                if (_currentEnemy && parentTower.enemyDetector.IsHeadLink(_currentEnemy))
                    Debug.Log((_currentEnemy.transform.position - transform.position).normalized);
                else
                    ChangeState<TowerChill>();
            }

            public override void ChangeState<T>()
            {
                parentTower.ChangeState<T>();
            }
        }
    }
}
