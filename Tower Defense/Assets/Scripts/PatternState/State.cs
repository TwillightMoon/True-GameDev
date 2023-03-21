using UnityEngine;

public abstract class State : MonoBehaviour, IStateChange
{
    public abstract void StateStart();
    public abstract void StateStop();

    public virtual void UpdateRun(){ }
    public virtual void FixedRun(){ }
    public virtual void LateUpdateRun(){ }

    public abstract void ChangeState<T>() where T : State;
}
