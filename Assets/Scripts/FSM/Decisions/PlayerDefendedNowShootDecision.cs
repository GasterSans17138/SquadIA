using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerDefendedNowShootDecision")]
public class PlayerDefendedNowShootDecision : Decision
{
    static public bool defending = false;
    public override bool Decide(StateManager _stateMachine)
    {
        CheckIfDefendDone playerNoLongerNeedDefend = _stateMachine.GetComponent<CheckIfDefendDone>();
        return playerNoLongerNeedDefend.PlayerNoLongerNeedDefending();
    }
}