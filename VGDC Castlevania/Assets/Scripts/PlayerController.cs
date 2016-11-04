using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    bool isGrounded = false;
    Rigidbody2D myRigidbody;



    // Use this for initialization
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
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