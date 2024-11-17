using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadFormation : MonoBehaviour
{
    public Transform player;
    private List<GameObject> goodGuys;//ignore 0 it's the player

    public State healerState;
    public State defenderState;

    public float followDistance = 5f;
    private Vector3[] formationOffsets;

    void Start()
    {
        // Arrow formation
        
        goodGuys = GameObject.Find("GameManager").GetComponent<GameManager>().goodGuys;
        formationOffsets = new Vector3[goodGuys.Count];
        for (int i = 1; i < goodGuys.Count; i++)
        {
            float offsetX = (i % 2 == 0 ? 1 : -1) * (i / 2 + 1) * 1.5f;
            float offsetZ = -(i / 2 + 1) * 1.5f;
            formationOffsets[i] = new Vector3(offsetX, 0, offsetZ);
        }
    }

    void Update()
    {
        Vector3 playerPosition = player.position - player.forward * followDistance;

        for (int i = 1; i < goodGuys.Count; i++)
        {
            if (goodGuys[i].GetComponent<StateManager>().currentState == healerState || goodGuys[i].GetComponent<StateManager>().currentState == defenderState || goodGuys[i].GetComponent<Entity>().isDead)
                continue;

            Vector3 targetPosition = playerPosition + player.rotation * formationOffsets[i];
            MoveAllyToPosition(goodGuys[i].transform, targetPosition);
        }
    }

    private void MoveAllyToPosition(Transform ally, Vector3 targetPosition)
    {
        NavMeshAgent navMeshAgent = ally.GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}