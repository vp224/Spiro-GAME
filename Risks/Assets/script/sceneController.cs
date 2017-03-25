using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneController : MonoBehaviour {

    // Use this for initialization
    public Button mainMenu;
    public Button playAgain;
    public GameObject fadeIn;

    private Animator mainMenuAnim;
    private Animator playAgainAnim;

    void Start()
    {
        mainMenuAnim = mainMenu.GetComponent<Animator>();
        playAgainAnim = playAgain.GetComponent<Animator>();
    }

	public void Play( )
    {
        SceneManager.LoadScene("game");
    }
    public void Help()
    {
        SceneManager.LoadScene("help");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    public void GameOver()
    {
        //SceneManager.LoadScene("gameOver");
        mainMenuAnim.SetBool("gameOver", true);
        playAgainAnim.SetBool("gameOver", true);
        fadeIn.GetComponent<fadeOut>().fadeIn();
    }
    
}
