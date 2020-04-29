using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public GameObject thePauseScreen;
    private PlayerController thePlayer;
    private LevelManager theLevelManager;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)    //Check if game is paused
            {
                ResumeGame();   //When game is paused and press Escape button, resume game
            }
            else
            {
                PauseGame();    //When game is running and press Escape button, pause game
            }           
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0;    // freeze the game
        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
        theLevelManager.levelMusic.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;  //resume back to normal realtime
        thePauseScreen.SetActive(false);
        thePlayer.canMove = true;
        theLevelManager.levelMusic.Play();
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1.0f;  //Avoid game stuck at frozen when change scene during game paused
        SceneManager.LoadScene("Main Menu");
    }
}
