using UnityEngine;

public abstract class TowerState : State
{
    protected Tower parentTower;

    public void Init(Tower parentTower)
    {
        if (!this.parentTower)
            this.parentTower = parentTower;
    }

    public abstract override void StateStart();
    public abstract override void StateStop();

    public abstract override void ChangeState<T>();
}
