using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AIAlly : Entity
{
    [SerializeField] private GameManager gameManager;

    private Vector3 targetToLook = Vector3.up;
    private bool lookAtTarget = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public Entity GetClosestEnemy()
    {
        Entity closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject e in gameManager.enemies) 
        {
            if (e == null) continue;
            Entity en = e.GetComponent<Entity>();

            float distanceToEnemy = Vector3.Distance(currentPosition, e.transform.position);
            if (distanceToEnemy < closestDistance && !en.isDead)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = en;
            }
        }
        return closestEnemy;
    }

    public void RotateTowardsEnemy(Entity _closestEnemy)
    {
        if (_closestEnemy == null) return;

        Vector3 directionToEnemy = (_closestEnemy.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);

        float rotationSpeed = 360f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void LookAtTarget(Vector3 target = new Vector3())
    {
        if(target!=Vector3.zero)
        {
            targetToLook = target;
            lookAtTarget = true;
        }
    
        transform.LookAt(targetToLook);
    }
    public void DontLook()
    {
        lookAtTarget = false;
    }

    public void Update()
    {
        if (lookAtTarget)
            LookAtTarget();
    }
}