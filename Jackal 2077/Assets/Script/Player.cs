using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ����ƶ��ٶ�
    public GameObject missilePrefab; // ����Ԥ����
    public AudioClip fireSound; // �����ӵ�����Ƶ

    private Rigidbody2D rb;
    private Vector2 movement;
    private AudioSource audioSource; // AudioSource ������ڲ�����Ƶ

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY);

        // ���¿ո��ʱ���䵼��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    private void FireMissile()
    {
        // ��������ʵ��
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

        // ���õ������ƶ����򣬿��Ը�����Ҫ���е���
        MissileMovement missileMovement = missile.GetComponent<MissileMovement>();
        if (missileMovement != null)
        {
            missileMovement.SetDirection(transform.up);
        }

        // ���ŷ����ӵ�����Ƶ
        audioSource.PlayOneShot(fireSound);
    }
}