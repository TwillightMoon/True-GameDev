using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unit.EnemyScrips;
using ConfigClasses.BuildingConfig;
using System;

namespace Buildings
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class EnemyDetector : MonoBehaviour, IModule
    {
        private CircleCollider2D _circleCollider2d;
        private Building _parentBuilding;

        private LinkedList<Enemy> _enemyList;

        public UnityEvent onEnemyEnter;

        private float combatRadius;

        private void Awake()
        {
            _enemyList = new LinkedList<Enemy>();
            _circleCollider2d = GetComponent<CircleCollider2D>();
            _circleCollider2d.isTrigger = true;

            SetParent();
        }

        private void SetParent()
        {
            try
            {
                _parentBuilding = (Building)FindParentHub();
            }
            catch (InvalidCastException e)
            {
                Debug.LogError("Произошла ошибка приведения типов: " + e.Message);

            }
        }

        private void OnEnable()
        {
            _parentBuilding.AddModule(this);
        }
        private void OnDisable()
        {
            _parentBuilding.RemoveModule(this);
        }

        public Enemy GetNextEnemy()
        {
            Enemy result = null;
            if (_enemyList.Count > 0)
                result = _enemyList.First.Value;

            return result;
        }
        public bool IsHeadLink(Enemy enemy)
        {
            if (_enemyList.Count > 0)
                return _enemyList.First.Value == enemy;
            return false;
        }



        //Отслеживание противников в радиусе
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("hit");
            if (enemy)
            {
                _enemyList.AddLast(enemy);

                if (_enemyList.Count == 1)
                {
                    onEnemyEnter.Invoke();
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("out");
            if (enemy)
                _ = _enemyList.Remove(enemy);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.green; // устанавливаем цвет
                Gizmos.DrawWireSphere(transform.position, _circleCollider2d.radius); // рисуем окружность
            }
        }

        public void SetSpecifications(BuildingsConfig specifications)
        {
            if (specifications.combatRadius < 0) return;

            _circleCollider2d.radius = specifications.combatRadius;
        }

        public IModuleHub FindParentHub()
        {
            IModuleHub moduleHub = transform.GetComponentInParent<IModuleHub>();

            return moduleHub;
        }
    }

}
