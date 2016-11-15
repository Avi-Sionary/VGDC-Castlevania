using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public BoxCollider2D enemyboundry;
    GameObject Player;

    EnemyActions enemy;

    void start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerController");
        enemy = enemy.GetComponent<EnemyActions>();
    }
    void Update()
    {
        enemy.update();
        enemy.EnemyAttack();
    }
    void OnTriggerStay2D(BoxCollider2D collider2D)
    {
        enemy.TransformEnemy();
    }
}

public class EnemyActions : MonoBehaviour
{
    public Transform character;
    public int speed = 3;
    public int EnemyAttackRange = 1;
    public int EnemyAttackTime = 5;
    public int EnemyHealthPoints = 20;

    GameObject Player;

    public void start()
    {
        Player = GameObject.FindGameObjectWithTag("PlayerHealth");
    }
    public void update()
    {
        if(EnemyAttackTime > 0)
        {
            EnemyAttackTime -= 1;
        }
        if(EnemyAttackTime == 0)
        {
            EnemyAttack();
            EnemyAttackTime = 5; /*Cooldown Time for next attack*/
        }
    }
    public void EnemyDeath(int dmg)
    {
        Debug.Log("Enemy took damage");

        EnemyHealthPoints -= dmg;

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
        if(Vector2.Distance(transform.position, character.position) <= EnemyAttackRange)
        {
            Player.SendMessage("TakeDamage", 1); /*The Amount of Damage dealt by the enemy*/
        }
    }
}
