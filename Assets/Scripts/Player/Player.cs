using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int lives = 0;

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            if (value < lives)
            {
                lives = Mathf.Max(0, value);
                OnDamageTaken.Invoke();
            }
            else
            {
                lives = value;
            }
            OnLivesChanged.Invoke(lives);
        }
    }

    public class LivesChanged : UnityEvent<int> { }

    public LivesChanged OnLivesChanged = new LivesChanged();

    public UnityEvent OnDamageTaken = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
