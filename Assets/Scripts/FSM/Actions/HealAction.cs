using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Heal")]
public class HealAction : FSMAction
{
    private Entity player;
    private float healRange = 4f;
    private float heal = -5f;

    public override void Execute(StateManager _stateMachine)
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            player = playerObj.GetComponent<Entity>();
        }
        float distanceToPlayer = Vector3.Distance(_stateMachine.transform.position, player.transform.position);
        
        if (distanceToPlayer <= healRange) HealPlayer();

        else MoveTowardsPlayer(_stateMachine); 
    }
    private void MoveTowardsPlayer(StateManager _stateMachine)
    {
        float stoppingDistance = 4f;
        NavMeshAgent navMeshAgent = _stateMachine.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(player.transform.position);
        if (navMeshAgent.remainingDistance <= stoppingDistance && !navMeshAgent.pathPending)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
        }
    }

    private void HealPlayer()
    {
        player.DealDamage(heal);
    }
}