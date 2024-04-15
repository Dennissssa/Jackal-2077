using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AnimationClip explosionClip; // 爆炸动画剪辑

    private bool hasExploded = false; // 是否已经播放过爆炸动画

    private void OnDestroy()
    {
        // 检查是否已经播放过爆炸动画
        if (!hasExploded)
        {
            // 创建一个新的动画剪辑实例
            AnimationClip instanceClip = Instantiate(explosionClip);

            // 将动画剪辑添加到动画组件中
            Animation animation = GetComponent<Animation>();
            animation.AddClip(instanceClip, instanceClip.name);

            // 播放动画剪辑
            animation.Play(instanceClip.name);

            // 标记已经播放过爆炸动画
            hasExploded = true;
        }
    }
}