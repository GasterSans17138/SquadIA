using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private float distanceToShoot;
    [SerializeField] private float frequenceInS = 0.5f;
    private List<GameObject> goodGuys;
    private Shoot shoot;
    private Coroutine shootingCoroutine;
    private bool shooting = false;

    private Entity target;

    private Entity GetClosestGoodGuy()
    {
        Entity closestGG = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject e in goodGuys)
        {
            if (e == null) continue;
            Entity en = e.GetComponent<Entity>();

            float distanceToGG = Vector3.Distance(currentPosition, e.transform.position);
            if (distanceToGG < closestDistance && !en.isDead)
            {
                closestDistance = distanceToGG;
                closestGG = en;
            }
        }
        return closestGG;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        goodGuys = GameObject.Find("GameManager").GetComponent<GameManager>().goodGuys;
        shoot = GetComponent<Shoot>();

    }

    // Update is called once per frame
    void Update()
    {
        target = GetClosestGoodGuy();
        transform.LookAt(target.transform.position);
        if(!shooting)
        {
            shootingCoroutine = StartCoroutine(ShootAtInterval());

            shooting = true;
        }
    }


    IEnumerator ShootAtInterval()
    {
        while (true) // Infinite loop to keep shooting
        {
            Entity e = target;

            if (Vector3.Distance(transform.position, e.transform.position) <= distanceToShoot)
            {
                shoot.StartShooting(false);
            }

            // Wait for the specified interval before the next shot
            yield return new WaitForSeconds(frequenceInS);
        }
    }
}
