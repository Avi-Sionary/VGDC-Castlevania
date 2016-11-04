using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int lives;
    //we need this to keep track of player lives.  
    //We can set it to whatever in the start function.

    PlayerController playerController;
    bool isDead;
    bool damaged;
    
	// Use this for initialization
	void Start ()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        lives = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //This may be used to display if we are being damaged - red flash on model?
	}

    void Death()
    {
        isDead = true;

        // Play any death sounds or animations that we want here.
        if(lives > 0)
        {
            Respawn();
            lives--;
        }

    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Respawn()
    {
        currentHealth = startingHealth;
        playerController.setPosition(0, 0);
        isDead = false;
    }
}
