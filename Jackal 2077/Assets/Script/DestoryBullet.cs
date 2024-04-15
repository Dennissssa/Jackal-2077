using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isDestroyed = false;

    private void Start()
    {
        Invoke("DestroyBullet", 2f);
    }

    private void DestroyBullet()
    {
        if (!isDestroyed)
        {
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
