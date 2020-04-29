using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    // Store sprite images flag open and close
    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;

    public bool checkpointActive;

	// Use this for initialization
	void Start () {
        //Get and store a reference to the SpriteRenderer component so that we can access it.
        theSpriteRenderer = GetComponent<SpriteRenderer>(); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Check for when the player enters the checkpoint
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Set the sprite in the Sprite Renderer to flagOpen sprite
            theSpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}
