using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/TacticAction")]
public class TacticAction : FSMAction
{
    public override void Execute(StateManager _stateMachine)
    {
        AIAlly allyComponent = _stateMachine.GetComponent<AIAlly>();
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        allyComponent.LookAtTarget(playerController.GetPointToTarget());

        Shoot shootComponent = _stateMachine.GetComponent<Shoot>();
        shootComponent.StartShooting(true);
    }
}