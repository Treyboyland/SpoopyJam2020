using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChangerOverTime : MonoBehaviour
{
    [SerializeField]
    Camera cameraToControl = null;

    [SerializeField]
    float secondsToLoop = 0;

    [SerializeField]
    Gradient colorLoop;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorLoop());
    }

    IEnumerator ColorLoop()
    {
        float elapsed = 0;
        while (true)
        {
            while (elapsed < secondsToLoop / 2)
            {
                elapsed += Time.deltaTime;
                cameraToControl.backgroundColor = colorLoop.Evaluate(elapsed / (secondsToLoop / 2));
                yield return null;
            }
            elapsed = 0;
            while (elapsed < secondsToLoop / 2)
            {
                elapsed += Time.deltaTime;
                cameraToControl.backgroundColor = colorLoop.Evaluate(1 - (elapsed / (secondsToLoop / 2)));
                yield return null;
            }
            elapsed = 0;
        }
    }
}
