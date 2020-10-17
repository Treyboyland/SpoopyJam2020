using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    float secondsBetweenShots = 0;

    [SerializeField]
    BulletPool playerBulletPool = null;

    [SerializeField]
    Transform spawnLocation = null;

    float elapsed = 0;

    const string FIRE_COMMAND = "Fire1";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (Input.GetButton(FIRE_COMMAND) && elapsed >= secondsBetweenShots)
        {
            elapsed = 0;
            Fire();
        }
    }

    void Fire()
    {
        var bullet = playerBulletPool.GetObject();


        bullet.transform.position = spawnLocation.position;
        bullet.transform.rotation = transform.rotation;

        bullet.gameObject.SetActive(true);
    }
}
