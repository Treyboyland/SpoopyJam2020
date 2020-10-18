using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSound : MonoBehaviour
{
    [SerializeField]
    PlayerShoot shoot = null;

    [SerializeField]
    AudioSource source = null;

    [SerializeField]
    AudioClip clip = null;

    // Start is called before the first frame update
    void Start()
    {
        shoot.OnBulletFired.AddListener(() => source.PlayOneShot(clip));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
