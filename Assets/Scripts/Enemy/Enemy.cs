using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int health = 0;

    int currentHealth;

    static EnemyDeathParticlePool particlePool = null;

    public class DamageEvent : UnityEvent<int> { }

    public DamageEvent OnDamageTaken = new DamageEvent();

    [SerializeField]
    bool isHurtByBullets = true;

    public bool IsHurtByBullets
    {
        get
        {
            return isHurtByBullets;
        }
    }

    [SerializeField]
    bool isKicked = false;

    private void OnEnable()
    {
        currentHealth = health;
    }

    void SpawnParticle()
    {
        particlePool = particlePool == null ? Object.FindObjectOfType<EnemyDeathParticlePool>() : particlePool;
        if (particlePool != null)
        {
            var particle = particlePool.GetParticle();
            particle.transform.position = transform.position;
            particle.gameObject.SetActive(true);
        }
    }

    public void Damage(int val)
    {
        OnDamageTaken.Invoke(val);
        currentHealth = Mathf.Max(0, currentHealth - val);
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            SpawnParticle();
        }
    }

    public void ApplyDamageOverTime(int dmg, int seconds)
    {
        StartCoroutine(ApplyDamage(dmg, seconds));
    }

    IEnumerator ApplyDamage(int dmg, int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Damage(dmg);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
