using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnBullet;
    public float bulletSpeed = 10f;
    public float arcHeight = 2f;
    public void StartShooting(bool _IsFriend)
    {
        if (bulletPrefab != null || spawnBullet != null)
        {
            GameObject bulletObj = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
            bulletObj.transform.parent = null;
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.shooterFriendly = _IsFriend;
                
            Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                Vector3 forwardForce = spawnBullet.forward * bulletSpeed;
                Vector3 upwardForce = Vector3.up * arcHeight;
                bulletRb.velocity = forwardForce + upwardForce;
            }
        }

        else Debug.LogWarning("Bullet or spawn point is not assigned.");
    }
}