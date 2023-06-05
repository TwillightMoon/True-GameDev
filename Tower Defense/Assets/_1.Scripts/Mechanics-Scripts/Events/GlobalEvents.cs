using Units.EnemyScrips;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent<int> onEnemyOnBase = new UnityEvent<int>();
    public static UnityEvent<Enemy> onEnemyDeath = new UnityEvent<Enemy>();

    public static void SendEnemyOnBase(int baseDamage) => onEnemyOnBase.Invoke(baseDamage);
    public static void SendEnemyDeath(Enemy enemy) => onEnemyDeath.Invoke(enemy);

}
