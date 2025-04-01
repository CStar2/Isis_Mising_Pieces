using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score => score;

  

    public void AddScore(int value)
    {
        score += value;
        if (Score == 5)
        {
            SceneManager.LoadScene("GameFinal");
        }
    }

   
  
  
    public void ResetScore()
    {
        score = 0;
    }


}

