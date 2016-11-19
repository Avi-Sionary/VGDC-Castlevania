using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour
{
    public int speed = 5;
    public int EnemyAttackRange = 1;
    public int EnemyAttackTime = 25;
    public int EnemyHealthPoints = 40;

    PlayerController PlayerController;

    public void Awake()
    {

        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void Update()
    {
        if (EnemyAttackTime > 0)
        {
            EnemyAttackTime -= 1;
        }
        if (EnemyAttackTime == 0)
        {
            EnemyAttack();
            EnemyAttackTime = 25; /*Cooldown Time for next attack*/
        }
    }
    public void EnemyDeath()
    {
        Debug.Log("Enemy took damage");

        EnemyHealthPoints -= 20; /*Amount damage being taken*/

        if (EnemyHealthPoints <= 0) /*If the enemy dies from player*/
        {
            Debug.Log("EnemyDied");

            Destroy(gameObject);
            Destroy(this);
        }
    }
   public void OnTriggerStay2D(Collider2D other)  /*Enemy Movement*/
    {

        if (Vector2.Distance(transform.position, PlayerController.transform.position) > EnemyAttackRange)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            //Vector2.MoveTowards(transform.position, PlayerController.transform.position, speed);
        }
    }
    public void EnemyAttack()
    {
        if (Vector2.Distance(transform.position, PlayerController.transform.position) <= EnemyAttackRange)
        {
            Debug.Log("Enemy did damage");

            PlayerController.TakeDamage(1); /*The Amount of Damage dealt by the enemy*/
        }
    }


}