using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        var player = other.gameObject.GetComponent<Player>();

        if (player != null) //Bullets handle bullet collisions
        {
            HandleCollision(player);
            return;
        }

        var enemyOther = other.gameObject.GetComponent<Enemy>();

        if (enemyOther != null)
        {
            HandleCollision(enemyOther);
            return;
        }

    }

    void HandleCollision(Enemy enemyOther)
    {
        if (enemy.IsHurtByBullets)
        {
            if (enemyOther.IsInfected)
            {
                enemy.ApplyDamageOverTime(1, 2);
            }
            return;
        }

        if (enemyOther.IsInfected)
        {
            enemyOther.Kill();
            ScoreCounter.Counter.Score += (int)(2.5 * enemyOther.Points);
            enemy.ApplyDamageOverTime(1, 5);
        }
    }


    void HandleCollision(Player player)
    {
        // if (enemy.IsInfected)
        // {
        //     return;
        // }

        player.Lives--;
    }
}
