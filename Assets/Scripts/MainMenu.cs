
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startGameButton;

    private void Start()
    {
        Debug.Log("start");       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("listener works");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
