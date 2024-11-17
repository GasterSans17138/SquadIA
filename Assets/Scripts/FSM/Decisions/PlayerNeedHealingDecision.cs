using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerNeedHealingDecision")]
public class PlayerNeedHealingDecision : Decision
{
    public override bool Decide(StateManager _stateMachine)
    {
        if(!CheckHealthPlayerForStoppingHealing.alreadyUsed)
        {
            CheckHealthPlayerForHealing playerNeedHealing = _stateMachine.GetComponent<CheckHealthPlayerForHealing>();
            return playerNeedHealing.PlayerNeedHealing();
        }
        return false;
    }
}