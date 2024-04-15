using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "EnemyBullet")
        {
        
            Destroy(gameObject);
         
            SceneManager.LoadScene("EndScene");
        }
    }
}
