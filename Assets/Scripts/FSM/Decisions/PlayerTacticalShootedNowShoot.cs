using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerTacticalShootedNowShoot")]
public class PlayerTacticalShootedNowShoot : Decision
{
    public override bool Decide(StateManager _stateMachine)
    {
        CheckIfTacticalDone playerNoLongerNeedTacticalShoot = _stateMachine.GetComponent<CheckIfTacticalDone>();
        return playerNoLongerNeedTacticalShoot.PlayerNoLongerNeedTacticalShoot();
    }
}