using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    public bool isGrounded = false;
    Rigidbody2D myRigidbody;

    public int startingHealth = 100;
    public int currentHealth;
    public int lives;
    //we need this to keep track of player lives.  
    //We can set it to whatever in the start function.

    bool isDead;
    bool damaged;

    private Animator anim;
    public GameObject currentCheckpoint;


    // Use this for initialization
    void Start()
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

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.5282174f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.5282174f);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move right");
            //this.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.GetComponent<Rigidbody2D>().MovePosition((Vector2)this.transform.position + new Vector2(speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move left");
            //this.transform.Translate(-speed * Time.deltaTime, 0, 0);
            this.GetComponent<Rigidbody2D>().MovePosition((Vector2)this.transform.position + new Vector2(-speed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("JUMP!");
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            isGrounded = false;
        }
    }

    public void Death()
    {
        isDead = true;
        Debug.Log("Player Died");

        // Play any death sounds or animations that we want here.
        if (lives > 0)
        {
            Respawn();
            lives--;
        }

    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Respawn()
    {
        Debug.Log("Player respawn");
        currentHealth = startingHealth;
        isDead = false;

        this.transform.position = currentCheckpoint.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    public void setPosition(float x, float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    ////this is a test method to kill the player
    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    //if (other.name == "Player")
    //    //{
    //    //    Death();
    //    //}
    //}
}