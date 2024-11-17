using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Shoot")]
public class ShootAction : FSMAction
{
    public override void Execute(StateManager _stateMachine)
    {
        AIAlly allyComponent = _stateMachine.GetComponent<AIAlly>();
        Entity enemy = allyComponent.GetClosestEnemy();
        
        allyComponent.LookAtTarget(enemy.transform.position);


        Shoot shootComponent = _stateMachine.GetComponent<Shoot>();
        shootComponent.StartShooting(true);
    }
}