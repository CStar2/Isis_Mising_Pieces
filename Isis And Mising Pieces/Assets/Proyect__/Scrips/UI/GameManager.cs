using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    // Instancia única del GameManager para acceder desde otros scripts 
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                var newGO = new GameObject("GameManager");
                //Destruye otras instancias de GM, pero no destruyas la puntuacion
                DontDestroyOnLoad(newGO);
                _instance = newGO.AddComponent<GameManager>();
            }
            return _instance;
        }
    }


    private ScoreManager _scoreManager = new();
    
    public ScoreManager ScoreManager => _scoreManager;
   
    public object AnimationController { get; internal set; }


    //Codigo para que solo exista un game manager. 
    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }


    }
}
