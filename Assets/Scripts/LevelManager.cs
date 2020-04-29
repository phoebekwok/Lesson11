using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer; //Make a reference to an object of PlayerController 

    public GameObject deathSplosion;    //Make a reference to the particle effect prefab

    public int maxHealth;
    public int healthCount;

    private bool respawning;

    public int coinCount;   //Keep track of number of coins that the player collected

    public Text coinText;

    public GameObject gameOverScreen;

    // Make a reference to the 3 heart images
    public Image heart1;
    public Image heart2;
    public Image heart3;

    // Store sprite images heartFull, heartHalf and heartEmpty
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public AudioSource coinSound;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;


    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        healthCount = maxHealth;

        coinText.text = "Coins: " + coinCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
	}

    public void Respawn()
    {
        if (healthCount > 0)
        {
            StartCoroutine("RespawnCo");    // In the () is the string name of the Coroutine
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameOverMusic.Play();
        }
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);   // Deactivate the player in the world

        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);  // Create object

        yield return new WaitForSeconds(waitToRespawn); // How many seconds we want the game to wait for 

        //healthCount = maxHealth;
        respawning = false;
        //UpdateHeartMeter();     //Update the heart meter when player respawns

        thePlayer.transform.position = thePlayer.respawnPosition;   // Move the player to respawn position
        thePlayer.gameObject.SetActive(true);   // Reactivate the player in the world
    }

    public void HurtPlayer(int damageToTake)
    {
        //healthCount = healthCount - damageToTake;
        healthCount -= damageToTake;
        UpdateHeartMeter();     //Update the heart sprite when player gets hurt
        thePlayer.Knockback();

        thePlayer.hurtSound.Play();
    }

    public void AddCoins(int coinsToAdd)
    {
        //coinCount = coinCount + coinsToAdd;
        coinCount += coinsToAdd;    //Short form

        coinText.text = "Coins: " + coinCount;

        coinSound.Play();
    }

    // Update the heart sprite 
    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            //When healthCount = 600, full health
            case 600:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;

            //Take away half of the heart when player gets hit once
            case 500:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;

            case 400:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;

            case 300:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;

            case 200:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            case 100:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            //Any other situations
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }

    public void AddHealth (int healthToAdd)
    {
        healthCount += healthToAdd;
        
        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }
        coinSound.Play();
        UpdateHeartMeter();
    }
}
