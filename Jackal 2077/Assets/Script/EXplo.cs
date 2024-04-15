using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AnimationClip explosionClip; // ��ը��������

    private bool hasExploded = false; // �Ƿ��Ѿ����Ź���ը����

    private void OnDestroy()
    {
        // ����Ƿ��Ѿ����Ź���ը����
        if (!hasExploded)
        {
            // ����һ���µĶ�������ʵ��
            AnimationClip instanceClip = Instantiate(explosionClip);

            // ������������ӵ����������
            Animation animation = GetComponent<Animation>();
            animation.AddClip(instanceClip, instanceClip.name);

            // ���Ŷ�������
            animation.Play(instanceClip.name);

            // ����Ѿ����Ź���ը����
            hasExploded = true;
        }
    }
}