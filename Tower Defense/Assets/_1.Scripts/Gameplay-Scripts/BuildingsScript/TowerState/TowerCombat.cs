using UnityEngine;
using Units.EnemyScrips;
using StatsEnums.DamageTypes;
using ConfigClasses.ConfigBuildings;
using System.Collections;

namespace Buildings
{
    namespace TowerStates
    {
        /** Состояние, определяющее поведение башни в состоянии боя. */
        public class TowerCombat : TowerState
        {
            [SerializeField] private Bullet _bulletPrefab;
            [SerializeField] private Transform _gun;

            private EnemyDetector _enemyDetector;
            private Enemy _currentEnemy /**< Enemy variable. Переменная, хранящего текущую цель для атаки. */;
            private IAttacker _physicalAttack;

            Coroutine Kd;

            public override void Init(Building parentTower)
            {
                base.Init(parentTower);

                _enemyDetector = parentTower.GetComponentInChildren<EnemyDetector>();
                _physicalAttack = DamageTypes.GetAttackType(DamageType.Physical);
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
                {
                    if (Kd == null)
                    {
                        Vector2 direction = CalcDirection(_currentEnemy.transform.position);
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                        Bullet bullet = CreateBullet();
                        bullet.transform.rotation = Quaternion.Euler(0,0,angle);
                        bullet.SetAttaker(_physicalAttack, CalcDamage());

                        Shoot(bullet, direction);

                        Kd = StartCoroutine(KD());
                    }
                    
                }
                else
                {
                    _currentEnemy = _enemyDetector.GetNextEnemy();
                    if (!_currentEnemy)
                        ChangeState<TowerChill>();
                }
            }

            public override void ChangeState<T>()
            {
                parentTower.ChangeState<T>();
            }

            private Bullet CreateBullet()
            {
                Bullet bullet = Instantiate(_bulletPrefab);
                if (_gun)
                    bullet.transform.position = _gun.position;
                else
                    bullet.transform.position = transform.position;

                return bullet;
            }
            private void Shoot(Bullet bullet, Vector2 direction)
            {
                bullet.rigbody.AddForce(direction * 7, ForceMode2D.Impulse);
            }
            private float CalcDamage()
            {
                TowerConfig towerConfig = (TowerConfig)parentTower.buildingsConfig;
                float damage = Random.Range(towerConfig.damage.min, towerConfig.damage.max);

                return damage;
            }
            private Vector2 CalcDirection(Vector2 target)
            {
                if (_gun)
                {
                    return (target - (Vector2)_gun.position).normalized;
                }
                return (target - (Vector2)transform.position).normalized;
            }

            private IEnumerator KD()
            {
                TowerConfig towerConfig = (TowerConfig)parentTower.buildingsConfig;
                yield return new WaitForSeconds(towerConfig.fireRatePerSecond);

                Kd = null;
            }
        }

    }
}
