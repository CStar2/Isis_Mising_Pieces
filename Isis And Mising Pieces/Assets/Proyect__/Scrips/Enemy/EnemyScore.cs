using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScore : MonoBehaviour
{
    //Para cada enemigo diferente, se harian varios.
    public int score = 1;
    

    public void OnDeath()
    {
        GameManager.instance.ScoreManager.AddScore(score);
        
        
    }


}
