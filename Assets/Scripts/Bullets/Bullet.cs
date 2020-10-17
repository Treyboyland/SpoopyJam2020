using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    bool isPlayerBullet = false;

    public bool IsPlayerBullet
    {
        get
        {
            return isPlayerBullet;
        }
    }

    [SerializeField]
    bool isPiercing = false;

    [SerializeField]
    int damage = 0;

    /// <summary>
    /// Amount of damage this bullet does to stuff
    /// </summary>
    /// <value></value>
    public int Damage
    {
        get
        {
            return damage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
