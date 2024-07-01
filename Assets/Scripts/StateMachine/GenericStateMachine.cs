using System.Collections.Generic;

public class GenericStateMachine<T> where T : class
{
    protected T controller;
    protected IStates<T> currentState;
    protected Dictionary<States, IStates<T>> states = new Dictionary<States, IStates<T>>();

    public GenericStateMachine(T controller) => this.controller = controller;

    public void Update() => currentState?.Update();

    protected void ChangeState(IStates<T> newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States newState) => ChangeState(states[newState]);

    protected void SetController()
    {
        foreach (IStates<T> state in states.Values)
        {
            state.Controller = controller;
        }
    }
}