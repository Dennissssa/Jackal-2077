using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDestroyed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;

            // 执行玩家被摧毁的逻辑

            Destroy(gameObject);
        }
    }
}