using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/PlayerNeedTacticalShoot")]
public class PlayerNeedTacticalShoot : Decision
{
    static public bool isRightClicked = false;
    public override bool Decide(StateManager _stateMachine)
    {
        CheckIfNeedTacticalShoot playerNeedTacticalShoot = _stateMachine.GetComponent<CheckIfNeedTacticalShoot>();
        return playerNeedTacticalShoot.PlayerNeedsTacticalShoot();
    }
}