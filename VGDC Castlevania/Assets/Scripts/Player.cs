using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 5;
    float jumpPower = 5;

    bool isGrounded;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().MovePosition((Vector2)this.transform.position + new Vector2(speed * Time.deltaTime, 0));
        }
    }
}
