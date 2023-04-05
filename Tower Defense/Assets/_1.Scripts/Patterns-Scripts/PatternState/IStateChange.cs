

interface IStateChange
{
    public void ChangeState<T>() where T : State;
}
