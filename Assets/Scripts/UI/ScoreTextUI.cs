using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox = null;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.Counter.OnScoreChanged.AddListener(SetText);
        SetText(ScoreCounter.Counter.Score);
    }

    void SetText(int score)
    {
        textBox.text = "Score " + score;
    }
}
