using UnityEngine;

public class TowerChill : TowerState
{
    public override void StateStart()
    {
        _isActive = true;
    }

    public override void StateStop()
    {
        _isActive = false;
    }

    public override void ChangeState<T>()
    {
        parentTower.ChangeState<T>();
    }
}
