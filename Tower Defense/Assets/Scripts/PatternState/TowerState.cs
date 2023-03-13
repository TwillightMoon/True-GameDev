using UnityEngine;

public abstract class TowerState : State
{
    protected CombatTower parentTower;

    public void Init(CombatTower parentTower)
    {
        if (!this.parentTower)
            this.parentTower = parentTower;
    }

    public abstract override void StateStart();
    public abstract override void StateStop();

    public abstract override void ChangeState<T>();
}
