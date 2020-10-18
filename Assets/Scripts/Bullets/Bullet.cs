using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// True if this is a bullet belonging to the player
    /// </summary>
    [SerializeField]
    bool isPlayerBullet = false;

    /// <summary>
    /// True if this is a bullet belonging to the player
    /// </summary>
    /// <value></value>
    public bool IsPlayerBullet
    {
        get
        {
            return isPlayerBullet;
        }
    }

    /// <summary>
    /// True if the bullet will continue moving along if it comes into contact with something
    /// </summary>
    [SerializeField]
    bool isPiercing = false;

    /// <summary>
    /// True if the bullet will continue moving along if it comes into contact with something
    /// </summary>
    /// <value></value>
    public bool IsPiercing
    {
        get
        {
            return isPiercing;
        }
    }

    /// <summary>
    /// Amount of damage this bullet does to stuff
    /// </summary>
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

    /// <summary>
    /// True if the bullet applies damage over time
    /// </summary>
    [SerializeField]
    bool appliesDoT = false;

    /// <summary>
    /// True if the bullet applies damage over time
    /// </summary>
    /// <value></value>
    public bool AppliesDoT
    {
        get
        {
            return appliesDoT;
        }
    }

    /// <summary>
    /// How many seconds should pass before damage is applied again
    /// </summary>
    [SerializeField]
    int secondsPerDamage = 0;

    /// <summary>
    /// How many seconds should pass before damage is applied again
    /// </summary>
    /// <value></value>
    public int SecondsPerDamage
    {
        get
        {
            return secondsPerDamage;
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
