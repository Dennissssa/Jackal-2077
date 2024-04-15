using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.5f;  // 浮动的振幅
    public float floatFrequency = 1f;   // 浮动的频率

    private Rigidbody2D rb;
    private Vector2 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // 计算浮动的垂直位移
        float offsetY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // 应用浮动位移到物体位置
        Vector2 newPosition = startPosition + new Vector2(0f, offsetY);
        rb.MovePosition(newPosition);
    }
}