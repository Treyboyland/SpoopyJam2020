using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionParticle : MonoBehaviour
{
    [SerializeField]
    Vector2 scaleRange = new Vector2();

    [SerializeField]
    Vector2 loopRangeSeconds = new Vector2();

    Vector3 startScale;

    bool scaleSet = false;

    void SetInitialScale()
    {
        if (!scaleSet)
        {
            scaleSet = true;
            startScale = transform.localScale;
        }
    }

    private void OnEnable()
    {
        SetInitialScale();
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(RandomizeGrowth());
        }
    }

    IEnumerator RandomizeGrowth()
    {
        while (true)
        {
            float elapsed = 0;
            float multiplier = Random.Range(scaleRange.x, scaleRange.y);
            float secondsToLoop = Random.Range(loopRangeSeconds.x, loopRangeSeconds.y);
            
            var endScale = startScale * multiplier;
            while (elapsed <= secondsToLoop)
            {
                transform.localScale = Vector3.Lerp(startScale, endScale, elapsed / secondsToLoop);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = endScale;

            elapsed = 0;

            while (elapsed <= secondsToLoop)
            {
                transform.localScale = Vector3.Lerp(endScale, startScale, elapsed / secondsToLoop);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = startScale;
        }
    }
}
