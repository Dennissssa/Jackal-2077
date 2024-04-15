using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.5f;  // ���������
    public float floatFrequency = 1f;   // ������Ƶ��

    private Rigidbody2D rb;
    private Vector2 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // ���㸡���Ĵ�ֱλ��
        float offsetY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // Ӧ�ø���λ�Ƶ�����λ��
        Vector2 newPosition = startPosition + new Vector2(0f, offsetY);
        rb.MovePosition(newPosition);
    }
}