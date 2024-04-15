using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
    public float detectionRange = 10f; // ��ⷶΧ
    public float playerMemoryTime = 1f; // ���λ�ü���ʱ��
    public GameObject bulletPrefab; // �ӵ�Ԥ����
    public float bulletSpeed = 10f; // �ӵ��ٶ�
    public float shootInterval = 1f; // ������
    public AudioClip shootSound; // �����ӵ�����Ƶ

    private Transform player; // ��ҵ� Transform ���
    private Vector3 lastPlayerPosition; // ��ҵ���һ��λ��
    private bool isChasing = false; // �Ƿ�����׷�����
    private bool canShoot = true; // �Ƿ���Է����ӵ�
    private AudioSource audioSource; // AudioSource ������ڲ�����Ƶ

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = player.position;

        // ��ȡ AudioSource ���������
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (player == null)
        {
            return; // ��Ҳ����ڣ�ִֹͣ�к����߼�
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
        // �������Ƿ��ڷ�Χ��
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // ��¼���λ��
            lastPlayerPosition = player.position;

            // ֹͣ׷�����
            isChasing = false;

            // �����ӵ�
            Shoot();
        }
    }

    private void ChasePlayer()
    {
        // ����ҵ���һ��λ���ƶ������ﲻ��Ҫ�ƶ����룩
        // ������ҵ���һ��λ��
        lastPlayerPosition = player.position;
    }

    private void Shoot()
    {
        if (canShoot)
        {
            // �����ӵ�ʵ��
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // �����ӵ����ƶ�������ٶ�
            Vector3 direction = (lastPlayerPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            // ���ŷ����ӵ�����Ƶ
            audioSource.PlayOneShot(shootSound);

            canShoot = false;

            // ������ʱ�����ȴ�һ��ʱ����ٴ��������ӵ�
            StartCoroutine(ResetShootTimer());
        }
    }

    private IEnumerator ResetShootTimer()
    {
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }
}