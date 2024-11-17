using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class State : BaseState
{
    public List<FSMAction> action = new List<FSMAction>();
    public List<Transition> transitions = new List<Transition>();

    public override void Execute(StateManager _machine)
    {
        foreach (var action in action)
            action.Execute(_machine);

        foreach (var transition in transitions)
            transition.Execute(_machine);
    }
}