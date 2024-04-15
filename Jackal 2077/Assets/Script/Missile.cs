using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    public float speed = 10f; // �����ƶ��ٶ�
    private Vector2 direction;

    private void FixedUpdate()
    {
        Move();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    private void Move()
    {
        Vector2 movement = direction * speed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }
}