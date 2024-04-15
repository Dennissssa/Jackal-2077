using UnityEngine;

public class PlayerMissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab; // ����Ԥ����
    public float fireInterval = 1f; // ������ʱ��
    public AudioClip fireSound; // �����ӵ�����Ƶ

    private bool canFire = true; // �����Ƿ���Է����ӵ�
    private AudioSource audioSource; // AudioSource ������ڲ�����Ƶ

    private void Start()
    {
        // ��ȡ AudioSource ���������
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
        canFire = false; // ��ֹ���������ӵ�

        // ���ŷ����ӵ�����Ƶ
        audioSource.PlayOneShot(fireSound);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        FireMissile(direction);

        yield return new WaitForSeconds(fireInterval);

        canFire = true; // �����ٴη����ӵ�
    }

    private void FireMissile(Vector2 direction)
    {
        // ��������ʵ��
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        // ���õ������ƶ�����
        MissileMovement missileMovement = missile.GetComponent<MissileMovement>();
        if (missileMovement != null)
        {
            missileMovement.SetDirection(direction);
        }
    }
}