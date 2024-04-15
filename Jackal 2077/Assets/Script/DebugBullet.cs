using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Environment"))
        {
            if (CompareTag("Bullet"))
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Environment"))
        {
            if (CompareTag("EnemyBullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}