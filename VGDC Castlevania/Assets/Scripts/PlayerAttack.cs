using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    //bool to check whether the player is attacking or not

    private float attackTimer = 0;
    private float attackCoolDown = 0.3f;
    //cooldown between attacks.

    public int dmg = 20;
    //how much damage your attack does

    private Animator anim;
    //animations!

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        //Run this code when mouse left-clicks
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;

            /// <summary>
            /// Grab the world coordinates of where the mouse is when left-clicked
            /// </summary>
            Vector3 mousePixelPos = Input.mousePosition;
            Debug.LogFormat("This is the pixel coordinates of where the mouse is: {0}", mousePixelPos);

            Vector3 badMouseWorldPos = Camera.main.ScreenToWorldPoint(mousePixelPos);
            Debug.LogFormat("This is the world coordinates (in game) of where the mouse is: {0}", badMouseWorldPos);

            Vector2 goodMouseWorldPos = (Vector2)badMouseWorldPos;
            Debug.LogFormat("This is the 2D world coordinates (in game) of where the mouse should be (gets rid of z = -10): {0}", goodMouseWorldPos);

            /// <summary>
            /// Use the goodMouseWorldPos to get the direction of the ray.
            /// (Two points create a vector - to find the direction of that vector using those points, subtract the end-point by the origin point)
            /// </summary>
            Vector2 badRayDir = goodMouseWorldPos - new Vector2(0, 0);
            Debug.LogFormat("This is the direction of the ray from the world's origin (i.e. mousePos - (0,0)): {0}", badRayDir);

            //Rather than using the world's origin, the raycast (the whip) should spawn from the player's origin
            //The player's origin can be retrieved by using this.transform.position.
            //This, however, returns a Vector3, so it must be casted to a Vector2 so that we can do the subtraction with goodMouseWorldPos (which is also a Vector2)
            Vector2 goodRayDir = goodMouseWorldPos - (Vector2)this.transform.position;
            Debug.LogFormat("This is the direction of the ray from the player's origin (i.e. mousePos - [player's origin = {0}]): {1}", this.transform.position, goodRayDir);


            /// <summary>
            /// Now we can use the ray direction for use in our raycast. We save what was hit by our raycast in a variable called hit
            /// </summary>
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, goodRayDir);

            //Check for the hit's tag, but also check if we even hit anything in the first place.
            //(If we hit nothing, there'll be a null error, so let's check for this first, which is just "if(hit)")

            //if (hit && hit.collider.CompareTag("Enemy"))
            //{
            //    Debug.LogFormat("An enemy was hit and it is located at: {0}: ", hit.collider.transform.position);
            //}
            //else
            //{
            //    Debug.Log("Nothing was hit");
            //}

            /// <summary>
            /// If we want to limit the RayCast, we can limit it with a distance parameter. The above code does a raycast infinitely in that direction.
            /// This will limit the distance
            /// </summary>

            float distance = 1f;
            RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, goodRayDir, distance);
            if (hit2 && hit2.collider.CompareTag("Enemy"))
            {
                Debug.LogFormat("An enemy was hit and it is located at: {0}: ", hit2.collider.transform.position);
                GetComponent<Collider2D>().SendMessageUpwards("Damage", dmg);
                /// 'SendMessage Damage has no receiver!'
            }
            else
            {
                Debug.Log("Nothing was hit");
            }

            

        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
        anim.SetBool("Attacking", attacking);
    }

}