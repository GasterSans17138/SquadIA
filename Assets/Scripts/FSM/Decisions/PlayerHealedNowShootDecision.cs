using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerHealedNowShoot")]
public class PlayerHealedNowShootDecision : Decision
{
    public override bool Decide(StateManager _stateMachine)
    {
        CheckHealthPlayerForStoppingHealing playerNoLongerNeedHealing = _stateMachine.GetComponent<CheckHealthPlayerForStoppingHealing>();
        return playerNoLongerNeedHealing.PlayerNoLongerNeedHealing();
    }
}