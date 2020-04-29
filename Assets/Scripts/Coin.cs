using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private LevelManager theLevelManager;   //Make a reference to the LevelManager 

    public int coinValue;   //We can have more types of coins with different values

    // Use this for initialization
    void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
