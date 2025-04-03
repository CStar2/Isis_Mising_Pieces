using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{

    [SerializeField] private Button QuitButton;

    public GameObject ContinueButton;
    public GameObject Buttons;
    public GameObject Data;
    public GameObject GameData;

    private void Start()
    {
        QuitButton.onClick.AddListener(QuitGame);
        
    }

    public void StartGame(string sceneName)
    {
        
        Buttons.SetActive(false);
        Data.SetActive(true);

    }

    public void play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void ManageGames(string sceneName)
    {
        Buttons.SetActive(false);
        GameData.SetActive(true);
    }

    public void Back()
    {
        Buttons.SetActive(true);
        Data.SetActive(false);
        GameData.SetActive(false);
    }

  

    private void QuitGame()
    {
        Application.Quit();
    }
}
