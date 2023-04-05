using UnityEngine;

public class TowerCombat : TowerState
{
    [Header("Префабы")]
    [SerializeField] GameObject bullet;

    private Enemy currentEnemy;

    public override void StateStart()
    {
        currentEnemy = parentTower.enemyDetector.GetNextEnemy();
        Debug.Log(currentEnemy);
    }

    public override void StateStop()
    {
        currentEnemy = null;
    }

    public override void UpdateRun()
    {
        if (currentEnemy && parentTower.enemyDetector.IsHeadLink(currentEnemy))
            Debug.Log((currentEnemy.transform.position - transform.position).normalized);
        else
            ChangeState<TowerChill>();
    }

    public override void ChangeState<T>()
    {
        parentTower.ChangeState<T>();
    }
}
