using UnityEngine;

public class PlayerMissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab; // 导弹预制体
    public float fireInterval = 1f; // 发射间隔时间
    public AudioClip fireSound; // 发射子弹的音频

    private bool canFire = true; // 控制是否可以发射子弹
    private AudioSource audioSource; // AudioSource 组件用于播放音频

    private void Start()
    {
        // 获取 AudioSource 组件的引用
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(FireMissilesWithInterval());
        }
    }

    private System.Collections.IEnumerator FireMissilesWithInterval()
    {
        canFire = false; // 禁止连续发射子弹

        // 播放发射子弹的音频
        audioSource.PlayOneShot(fireSound);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        FireMissile(direction);

        yield return new WaitForSeconds(fireInterval);

        canFire = true; // 允许再次发射子弹
    }

    private void FireMissile(Vector2 direction)
    {
        // 创建导弹实例
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        // 设置导弹的移动方向
        MissileMovement missileMovement = missile.GetComponent<MissileMovement>();
        if (missileMovement != null)
        {
            missileMovement.SetDirection(direction);
        }
    }
}