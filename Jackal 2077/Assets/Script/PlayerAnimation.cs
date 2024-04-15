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

        // ������ҵ��ƶ��������ö�������
        if (moveX > 0 && moveY == 0) // ��
        {
            animator.SetTrigger("Right");
        }
        else if (moveX < 0 && moveY == 0) // ��
        {
            animator.SetTrigger("Left");
        }
        else if (moveX == 0 && moveY > 0) // ��
        {
            animator.SetTrigger("Up");
        }
        else if (moveX == 0 && moveY < 0) // ��
        {
            animator.SetTrigger("Down");
        }
        else if (moveX > 0 && moveY > 0) // ����
        {
            animator.SetTrigger("UpRight");
        }
        else if (moveX < 0 && moveY > 0) // ����
        {
            animator.SetTrigger("UpLeft");
        }
        else if (moveX > 0 && moveY < 0) // ����
        {
            animator.SetTrigger("DownRight");
        }
        else if (moveX < 0 && moveY < 0) // ����
        {
            animator.SetTrigger("DownLeft");
        }
    }
}