using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private float life;

    public void Playerdamage(float damage)
    {
        life -= damage;

        if (life <= 0 )
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
