using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 玩家移动速度
    public GameObject missilePrefab; // 导弹预制体
    public AudioClip fireSound; // 发射子弹的音频

    private Rigidbody2D rb;
    private Vector2 movement;
    private AudioSource audioSource; // AudioSource 组件用于播放音频

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

        // 按下空格键时发射导弹
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
        // 创建导弹实例
        GameObject missile = Instantiate(missilePrefab, transform.position, transform.rotation);

        // 设置导弹的移动方向，可以根据需要进行调整
        MissileMovement missileMovement = missile.GetComponent<MissileMovement>();
        if (missileMovement != null)
        {
            missileMovement.SetDirection(transform.up);
        }

        // 播放发射子弹的音频
        audioSource.PlayOneShot(fireSound);
    }
}