using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    public bool isGrounded = false;
    Rigidbody2D myRigidbody;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", isGrounded);
        anim.SetFloat("Speed", speed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.5282174f, 0.5282174f, 0.5282174f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(0.5282174f, 0.5282174f, 0.5282174f);
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

        if (Input.GetKeyDown(KeyCode.K) && isGrounded)
        {
            Debug.Log("JUMP!");
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            isGrounded = false;
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
}