using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationSpeedOverTime : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    [SerializeField]
    AnimationCurve curve;

    [SerializeField]
    float secondsPerLoop;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeTime());
    }


    IEnumerator ChangeTime()
    {
        float elapsed = 0;
        while (true)
        {
            elapsed += Time.deltaTime;
            var particleMain = particle.main;
            particleMain.simulationSpeed = curve.Evaluate(elapsed / secondsPerLoop);
            yield return null;
        }
    }
}
