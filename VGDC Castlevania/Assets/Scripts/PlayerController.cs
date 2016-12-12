using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //I AM AVI HEAR ME ROAR
    public float speed = 2;
    public float speedv = 10f;
    bool isGrounded = false;
    bool isMovingLeft = false;
    bool isMovingRight = false;

    bool Moving = false;

    private Rigidbody2D myRigidbody;

    public LevelManager levelManager;
    public GameObject currentSpawn;

    public int startingHealth = 100;
    public int currentHealth;
    public int lives;
    //we need this to keep track of player lives.  
    //We can set it to whatever in the start function.

    bool isDead;
    bool damaged;

    private Animator anim;


    // Use this for initialization
    void Awake()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        currentHealth = startingHealth;
        lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Speed", speed);

        if (myRigidbody.velocity.x == 0 && Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");
            anim.SetBool("Moving", true);
            isMovingRight = true;
            isMovingLeft = false;
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = false;
            //this.GetComponent<Rigidbody2D>().MovePosition((Vector2)this.transform.position + new Vector2(speed * Time.deltaTime, this.GetComponent<Rigidbody2D>().velocity.y));
        }
        else if (myRigidbody.velocity.x == 0 && Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");
            anim.SetBool("Moving", true);
            isMovingLeft = true;
            isMovingRight = false;
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
            //this.transform.localScale = new Vector3(-1, 1, 1);
            //this.GetComponent<Rigidbody2D>().MovePosition((Vector2)this.transform.position + new Vector2(-speed * Time.deltaTime, this.GetComponent<Rigidbody2D>().velocity.y));
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("JUMP!");
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            isGrounded = false;
            isMovingLeft = false;
            isMovingRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    public void setPosition(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }
    public void Death()
    {
        isDead = true;

        // Play any death sounds or animations that we want here.
        if (lives > 0)
        {
            Respawn();
            lives--;
            Debug.Log(lives + " lives left!");
        }
        else
        {
            GameOver();
        }

    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        Debug.Log(currentHealth + " health");

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Respawn()
    {
        currentHealth = startingHealth;
        Debug.Log("You respawned with " + currentHealth + " health.");
        transform.position = currentSpawn.transform.position;
        isDead = false;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("GameOverScene");
    }
}
