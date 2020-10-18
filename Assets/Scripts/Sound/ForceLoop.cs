using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ForceLoop : MonoBehaviour
{
    [SerializeField]
    float loopTime;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (source.time >= loopTime)
        {
            source.time = 0;
        }
    }
}
