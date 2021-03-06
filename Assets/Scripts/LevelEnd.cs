﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;  // Name of the level we want to load
    public string levelToUnlock;

    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;

    public float waitToMove; //Wait a second before player walks off to the side of screen
    public float waitToLoad; //Wait a few seconds before loading the new level 

    private bool movePlayer;

    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;


    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();

        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayer)
        {
            thePlayer.rb.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.rb.velocity.y, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //SceneManager.LoadScene(levelToLoad);

            theSpriteRenderer.sprite = flagOpen;

            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;
        theCamera.followTarget = false;
        theLevelManager.levelMusic.Stop();
        theLevelManager.gameOverMusic.Play();

        thePlayer.rb.velocity = Vector3.zero;   //Stop player movement

        PlayerPrefs.SetInt(levelToUnlock, 1);

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(levelToLoad);
    }
}
