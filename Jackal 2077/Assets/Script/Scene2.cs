using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName; // 目标场景的名称

    private void Update()
    {
        // 检查场景中标记为"Enemy"的对象数量
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            // 切换到目标场景
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
