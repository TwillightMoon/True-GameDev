using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDetector : MonoBehaviour
{
    private CircleCollider2D _circleCollider2d;
    private Buildings _parentBuilding;

    private LinkedList<Enemy> _enemyList;

    public UnityEvent onEnemyEnter;

    public float combatRadius
    {
        get => _circleCollider2d.radius;

        set
        {
            if (value > 0) _circleCollider2d.radius = value;
        }
    }

    public void Init(Buildings parent)
    {
        _enemyList = new LinkedList<Enemy>();
        _circleCollider2d = GetComponent<CircleCollider2D>();
        _circleCollider2d.isTrigger = true;
        SetParent(parent);
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
        if(_enemyList.Count > 0)
            return _enemyList.First.Value == enemy;
        return false;
    }

    private void SetParent(Buildings parentBuilding) => this._parentBuilding = parentBuilding;

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
        if(Application.isPlaying)
        {
            Gizmos.color = Color.green; // устанавливаем цвет
            Gizmos.DrawWireSphere(transform.position, _circleCollider2d.radius); // рисуем окружность
        }
    }
}
