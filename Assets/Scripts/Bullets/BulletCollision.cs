using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    Bullet bullet;

    void HandleBullet(Enemy enemy)
    {
        if (!enemy.IsHurtByBullets)
        {
            //TODO: Should there be some type of feedback for this?
        }
        else
        {
            if (bullet.AppliesDoT)
            {
                enemy.ApplyDamageOverTime(bullet.Damage, bullet.SecondsPerDamage);
            }
            else
            {
                enemy.Damage(bullet.Damage);
            }
        }
    }

    void HandleBullet(Player player)
    {
        //Remove a life
        player.Lives--;
    }

    /// <summary>
    /// Disables the bullet if the bullet is non-piercing
    /// </summary>
    void DisableIfNeeded()
    {
        if (!bullet.IsPiercing)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            var player = other.gameObject.GetComponent<Player>();
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (bullet.IsPlayerBullet && enemy != null)
            {
                HandleBullet(enemy);
                DisableIfNeeded();
            }
            else if (!bullet.IsPlayerBullet && player != null)
            {
                HandleBullet(player);
                DisableIfNeeded();
            }


        }
    }
}
