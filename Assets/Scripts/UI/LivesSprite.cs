using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class LivesSprite : MonoBehaviour
{
    [SerializeField]
    Image image = null;

    [SerializeField]
    Color heartGood = Color.white;

    [SerializeField]
    Color heartBad = Color.black;

    [SerializeField]
    bool hasLife = false;

    public bool HasLife
    {
        get
        {
            return hasLife;
        }
        set
        {
            if (value != hasLife)
            {
                OnLifeStateChanged.Invoke(value);
            }
            hasLife = value;
            image.color = hasLife ? heartGood : heartBad;
        }
    }

    public class LifeStateChanged : UnityEvent<bool> { }

    public LifeStateChanged OnLifeStateChanged = new LifeStateChanged();
}
