using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName; // Ŀ�곡��������

    private void Update()
    {
        // ��鳡���б��Ϊ"Enemy"�Ķ�������
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            // �л���Ŀ�곡��
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
