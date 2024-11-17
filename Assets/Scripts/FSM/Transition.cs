using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class Transition : ScriptableObject
{
    public Decision Decision;
    public BaseState TrueState;
    public BaseState FalseState;

    public void Execute(StateManager _stateMachine)
    {
        if (Decision.Decide(_stateMachine) && !(TrueState is RemainInState))
            _stateMachine.currentState = TrueState;
        else if (!(FalseState is RemainInState))
            _stateMachine.currentState = FalseState;
    }
}