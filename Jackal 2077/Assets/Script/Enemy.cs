using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public float detectionRange = 10f; // 检测范围
    public float playerMemoryTime = 1f; // 玩家位置记忆时间
    public GameObject bulletPrefab; // 子弹预制体
    public float bulletSpeed = 10f; // 子弹速度
    public float shootInterval = 1f; // 发射间隔
    public AudioClip shootSound; // 发射子弹的音频

    private Transform player; // 玩家的 Transform 组件
    private Vector3 lastPlayerPosition; // 玩家的上一秒位置
    private bool isChasing = false; // 是否正在追逐玩家
    private bool canShoot = true; // 是否可以发射子弹
    private AudioSource audioSource; // AudioSource 组件用于播放音频

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = player.position;

        // 获取 AudioSource 组件的引用
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (player == null)
        {
            return; // 玩家不存在，停止执行后续逻辑
        }

        if (!isChasing)
        {
            RandomMovement();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void RandomMovement()
    {
        // 检测玩家是否在范围内
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // 记录玩家位置
            lastPlayerPosition = player.position;

            // 停止追逐玩家
            isChasing = false;

            // 发射子弹
            Shoot();
        }
    }

    private void ChasePlayer()
    {
        // 向玩家的上一秒位置移动（这里不需要移动代码）
        // 更新玩家的上一秒位置
        lastPlayerPosition = player.position;
    }

    private void Shoot()
    {
        if (canShoot)
        {
            // 创建子弹实例
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 设置子弹的移动方向和速度
            Vector3 direction = (lastPlayerPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            // 播放发射子弹的音频
            audioSource.PlayOneShot(shootSound);

            canShoot = false;

            // 启动计时器，等待一段时间后再次允许发射子弹
            StartCoroutine(ResetShootTimer());
        }
    }

    private IEnumerator ResetShootTimer()
    {
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}