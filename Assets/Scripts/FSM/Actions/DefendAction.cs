using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Defend")]
public class DefendAction : FSMAction
{
    private Entity player;
    public override void Execute(StateManager _stateMachine)
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.GetComponent<Entity>();
        }

        AIAlly allyComponent = _stateMachine.GetComponent<AIAlly>();
        Entity enemy = allyComponent.GetClosestEnemy();

        Vector3 directionToEnemy = (enemy.transform.position - player.transform.position).normalized;

        float defenseDistanceFromPlayer = 2f;
        Vector3 defensePosition = player.transform.position + directionToEnemy * defenseDistanceFromPlayer;
        
        NavMeshAgent navMeshAgent = _stateMachine.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(defensePosition);
    }
}