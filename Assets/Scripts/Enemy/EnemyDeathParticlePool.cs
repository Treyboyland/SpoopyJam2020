using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathParticlePool : MonoBehaviour
{
    [SerializeField]
    DisableParticleAfterDoneEmitting enemyParticlePrefab = null;

    [SerializeField]
    int initialSize = 0;

    List<DisableParticleAfterDoneEmitting> pool = new List<DisableParticleAfterDoneEmitting>();


    DisableParticleAfterDoneEmitting InstantiateObject()
    {
        var newObject = Instantiate(enemyParticlePrefab, transform);
        newObject.gameObject.SetActive(false);
        return newObject;
    }

    private void Awake()
    {
        InitializePool();
    }


    void InitializePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            pool.Add(InstantiateObject());
        }
    }

    /// <summary>
    /// Returns an available object from the pool.
    /// <para> NOTE: This object should be set active before calling for another one </para>
    /// </summary>
    /// <returns></returns>
    public DisableParticleAfterDoneEmitting GetParticle()
    {
        foreach (var particle in pool)
        {
            if (!particle.gameObject.activeInHierarchy)
            {
                return particle;
            }
        }

        var newObject = InstantiateObject();
        pool.Add(newObject);

        return newObject;
    }
}
