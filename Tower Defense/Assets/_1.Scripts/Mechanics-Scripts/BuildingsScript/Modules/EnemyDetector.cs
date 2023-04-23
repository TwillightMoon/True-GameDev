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
        public UnityEvent onEnemyCrossesArea = new UnityEvent();

        private CircleCollider2D _circleCollider2d;
        private Building _parentBuilding;

        private LinkedList<Enemy> _enemyList;

        private bool isActive = false;

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
            isActive = true;
            CheckCollidersInZone();
            _parentBuilding.AddModule(this);
        }

        private void OnDisable()
        {
            isActive = false;
            _enemyList.Clear();
            _parentBuilding.RemoveModule(this);
        }

        public Enemy GetNextEnemy() => ((_enemyList.Count <= 0) ? null : _enemyList.First.Value);
        public bool IsHeadLink(Enemy enemy) => ((_enemyList.Count <= 0) ? false : _enemyList.First.Value == enemy);
 
        //Отслеживание противников в радиусе
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!isActive) return;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("hit");
            if (enemy)
            {
                _enemyList.AddLast(enemy);
                onEnemyCrossesArea.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!isActive) return;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("out");
            if (enemy)
                _ = _enemyList.Remove(enemy);
        }

        private void CheckCollidersInZone()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _circleCollider2d.radius);

            foreach (Collider2D collider in colliders)
            {
                OnTriggerEnter2D(collider);
            }
        }

        public void SetSpecifications(BuildingsConfig specifications)
        {
            if (specifications.combatRadius < 0) return;

            _circleCollider2d.radius = specifications.combatRadius;
        }

        public IModuleHub FindParentHub() => transform.GetComponentInParent<IModuleHub>();
    }

}
