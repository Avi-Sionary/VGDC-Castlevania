using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public BoxCollider2D enemyboundry;

    EnemyActions enemy;

    void start()
    {
        enemy = enemy.GetComponent<EnemyActions>();
    }
    void Update()
    {
        enemy.EnemyAttack();
    }
    void OnTriggerStay2D(Collider2D Collider2D)
    {
        enemy.TransformEnemy();
    }
}
