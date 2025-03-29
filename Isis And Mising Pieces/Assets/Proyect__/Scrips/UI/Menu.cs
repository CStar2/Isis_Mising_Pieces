using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button NewGameButton;
    //[SerializeField] private Button ContinueButton;
    [SerializeField] private Button QuitButton;

    public GameObject ContinueButton;
    public GameObject Buttons;

    private void Start()
    {
        QuitButton.onClick.AddListener(QuitGame);
        //NewGameButton.onClick.AddListener(SceneManager.LoadScene());
    }

    private void StartGame()
    {
        throw new NotImplementedException();
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void ManageGames(string sceneName)
    {
        Buttons.SetActive(false);
    }





    private void QuitGame()
    {
        Application.Quit();
    }
}
