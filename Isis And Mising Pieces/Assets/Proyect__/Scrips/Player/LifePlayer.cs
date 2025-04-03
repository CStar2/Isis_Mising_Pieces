using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private float MaxLive;

    [SerializeField] private Livebar Livebar;
    


    private void Start()
    {
        life = MaxLive;
        Livebar.chancelive(life);
    }

    public void Playerdamage(float damage)
    {
        life -= damage;
        Livebar.nowlife(life);

        if (life <= 0 )
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

   
}
