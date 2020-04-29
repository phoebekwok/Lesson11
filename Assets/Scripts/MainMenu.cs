using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // New Game
    public void NewGame()
    {
        SceneManager.LoadScene("Level01");
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Instruction
    public void Instructions()
    {

    }

    // Close instruction
    public void CloseInstructions()
    {

    }

    // Credits
    public void Credits()
    {
        
    }

    // Close Credits
    public void CloseCredits()
    {
        
    }
}
