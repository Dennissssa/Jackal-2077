using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 根据玩家的移动方向设置动画参数
        if (moveX > 0 && moveY == 0) // 右
        {
            animator.SetTrigger("Right");
        }
        else if (moveX < 0 && moveY == 0) // 左
        {
            animator.SetTrigger("Left");
        }
        else if (moveX == 0 && moveY > 0) // 上
        {
            animator.SetTrigger("Up");
        }
        else if (moveX == 0 && moveY < 0) // 下
        {
            animator.SetTrigger("Down");
        }
        else if (moveX > 0 && moveY > 0) // 右上
        {
            animator.SetTrigger("UpRight");
        }
        else if (moveX < 0 && moveY > 0) // 左上
        {
            animator.SetTrigger("UpLeft");
        }
        else if (moveX > 0 && moveY < 0) // 右下
        {
            animator.SetTrigger("DownRight");
        }
        else if (moveX < 0 && moveY < 0) // 左下
        {
            animator.SetTrigger("DownLeft");
        }
    }
}