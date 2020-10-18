using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle = null;

    [SerializeField]
    MonoBehaviour prefabToSpawn = null;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenSpawn());
        }
    }

    IEnumerator WaitThenSpawn()
    {
        particle.gameObject.SetActive(true);

        //It would be better to 

        while (particle.gameObject.activeInHierarchy)
        {
            yield return null;
        }

        var obj = MasterPool.Pool.GetObject(prefabToSpawn);
        obj.transform.position = transform.position;
        obj.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
