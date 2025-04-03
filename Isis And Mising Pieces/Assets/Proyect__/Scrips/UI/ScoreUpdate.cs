using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private ScoreManager scoreManager;
    private void Update()

        
    {
        //Cuando pasen los 15 frames/ cada 15 frames, buscamos y cambiamos la puntuacion

        if (Time.frameCount % 15 == 0)
        {
           // scoreText = GameManager.instance.ScoreManager(scoreManager);
        }
    }
}
