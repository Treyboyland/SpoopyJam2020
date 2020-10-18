using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour
{

    //These transforms set the bounds of the playspace
    public PolygonCollider2D playBounds;

    static PlaySpace _instance;

    public static PlaySpace Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isInBounds(0, 0));
    }

    public bool isInBounds(int x, int y)
    {
        return playBounds.OverlapPoint(new Vector2(x, y));
    }
}