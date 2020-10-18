using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesParticlesOnLoss : MonoBehaviour
{
    [SerializeField]
    LivesSprite sprite = null;

    static HeartDeathParticlePool pool;

    // Start is called before the first frame update
    void Start()
    {
        sprite.OnLifeStateChanged.AddListener(SpawnParticlesIfNecessary);
    }

    void FindReference()
    {
        if (pool == null)
        {
            pool = FindObjectOfType<HeartDeathParticlePool>();
        }
    }

    void SpawnParticlesIfNecessary(bool hasLife)
    {
        if (!hasLife)
        {
            FindReference();
            if (pool != null)
            {
                var particle = pool.GetParticle();
                particle.transform.position = transform.position;
                particle.gameObject.SetActive(true);
            }
        }
    }
}
