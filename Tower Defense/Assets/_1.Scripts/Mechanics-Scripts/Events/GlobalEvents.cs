using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent<int> onEnemyOnBase = new UnityEvent<int>();
    public static UnityEvent onEnemyDeath = new UnityEvent();

    public static void SendEnemyOnBase(int baseDamage) => onEnemyOnBase.Invoke(baseDamage);
    public static void SendEnemyDeath() => onEnemyDeath.Invoke();

}
