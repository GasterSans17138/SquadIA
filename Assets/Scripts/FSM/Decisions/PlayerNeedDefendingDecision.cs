using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerNeedDefendingDecision")]
public class PlayerNeedDefendingDecision : Decision
{
    static public bool isMiddleMouseButtonClicked = false;
    public override bool Decide(StateManager _stateMachine)
    {
        CheckIfNeedDefend playerNeedDefend = _stateMachine.GetComponent<CheckIfNeedDefend>();
        return playerNeedDefend.PlayerNeedDefending();
    }
}