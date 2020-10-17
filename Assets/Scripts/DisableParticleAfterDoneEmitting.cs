using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticleAfterDoneEmitting : MonoBehaviour
{
    [SerializeField]
    ParticleSystem rootParticle = null;

    [SerializeField]
    List<ParticleSystem> particles = null;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DisableAfterDone());
        }
    }

    bool AreAnyParticlesEmitting()
    {
        foreach (var particle in particles)
        {
            if (particle.isPlaying || particle.isEmitting)
            {
                return true;
            }
        }

        return false;
    }


    IEnumerator DisableAfterDone()
    {
        rootParticle.Play();

        while (AreAnyParticlesEmitting())
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
