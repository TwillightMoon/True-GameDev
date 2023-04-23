using UnityEngine;
using Unit.EnemyScrips;

namespace Buildings
{
    namespace TowerStates
    {
        /** Состояние, определяющее поведение башни в состоянии боя. */
        public class TowerCombat : TowerState
        {

            private EnemyDetector _enemyDetector;
            private Enemy _currentEnemy /**< Enemy variable. Переменная, хранящего текущую цель для атаки. */;

            public override void Init(CombatTower parentTower)
            {
                base.Init(parentTower);

                _enemyDetector = parentTower.GetComponentInChildren<EnemyDetector>();
            }

            /**Метод старта состояния. 
             * Метод берет первого врага, вошедшего в зону действия.
             */
            public override void StateStart()
            {
                _currentEnemy = _enemyDetector.GetNextEnemy();
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
                if (_currentEnemy && _enemyDetector.IsHeadLink(_currentEnemy))
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
