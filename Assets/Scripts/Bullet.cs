using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool shooterFriendly;
    public float lifeSpan = 3f;
    public float damage = 3f;
    void Awake()
    {
        Destroy(gameObject, lifeSpan);
    }

    void OnCollisionEnter(Collision _collision)
    {
        GameObject gameObj = _collision.gameObject;
        Entity entity = gameObj.GetComponent<Entity>();

        if (entity != null)
            if (shooterFriendly && !entity.GetComponent<AIEnemy>()) return;

        if (entity != null) entity.DealDamage(damage);

        Destroy(gameObject);
    }
}