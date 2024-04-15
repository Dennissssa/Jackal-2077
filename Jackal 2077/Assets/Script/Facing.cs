using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float detectRange = 5f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float distance = direction.magnitude;

            if (distance <= detectRange)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}