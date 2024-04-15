using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Animator explosionAnimator; // 爆炸动画的Animator组件


    private void Start()
    {
        explosionAnimator = GetComponent<Animator>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bullet")
        {
            explosionAnimator.SetTrigger("EXP");
            Destroy(other.gameObject);
            StartCoroutine(DestroyWithDelay());
        }
    }

    private System.Collections.IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.6f);

        // 删除敌人
        Destroy(gameObject);
    }
}