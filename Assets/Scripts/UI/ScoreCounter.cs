using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{

    static ScoreCounter _instance = null;

    public static ScoreCounter Counter
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value != score)
            {
                score = value;
                OnScoreChanged.Invoke(score);
            }
        }
    }

    public class ScoreChanged : UnityEvent<int> { }

    public ScoreChanged OnScoreChanged = new ScoreChanged();

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
}
