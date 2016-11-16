using UnityEngine;
using System.Collections;

public class EnemyActions : MonoBehaviour
{
    public Transform character;
    public int speed = 3;
    public int EnemyAttackRange = 1;
    public int EnemyAttackTime = 5;
    public int EnemyHealthPoints = 20;

    PlayerController PlayerController;

    public void Start()
    {
        PlayerController = GetComponent<PlayerController>();
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
            EnemyAttackTime = 5; /*Cooldown Time for next attack*/
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
    public void TransformEnemy()  /*Enemy Movement*/
    {
        transform.LookAt(character.position);

        if (Vector2.Distance(transform.position, character.position) > EnemyAttackRange)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }
    public void EnemyAttack()
    {
        if (Vector2.Distance(transform.position, character.position) <= EnemyAttackRange)
        {
            Debug.Log("Enemy did damage");

            PlayerController.GetComponent<PlayerController>().TakeDamage(1); /*The Amount of Damage dealt by the enemy*/
        }
    }
}