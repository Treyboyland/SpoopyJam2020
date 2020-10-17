using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionParticleController : ObjectPool<InfectionParticle>
{
    [SerializeField]
    Vector2Int particlesToSpawn;

    [SerializeField]
    Vector2 minAnchor = new Vector2();

    [SerializeField]
    Vector2 maxAnchor = new Vector2();

    [SerializeField]
    Enemy enemy = null;

    protected override void Awake()
    {
        base.Awake();
        enemy.OnDamageTaken.AddListener(SpawnParticles);
    }

    private void OnEnable()
    {
        DisableAllObjects();
    }

    void SpawnParticles(int num)
    {
        int multiplier = Random.Range(particlesToSpawn.x, particlesToSpawn.y);
        for (int i = 0; i < num * multiplier; i++)
        {
            var particle = GetObject();
            particle.transform.SetParent(enemy.transform);
            Vector3 newPos = new Vector3();
            newPos.x = Random.Range(minAnchor.x, maxAnchor.x);
            newPos.y = Random.Range(minAnchor.y, maxAnchor.y);
            particle.transform.localPosition = newPos;
            particle.gameObject.SetActive(true);
        }

    }
}
