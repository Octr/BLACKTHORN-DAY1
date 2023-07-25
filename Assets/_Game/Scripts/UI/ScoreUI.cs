using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : Singleton<ScoreUI>
{
    [SerializeField] public TextMeshProUGUI scoreTMP;
    public int ScoreValue;

    private void Start()
    {
        ScoreValue = 0;
        UpdateText();
    }

    public void UpdateText()
    {
        scoreTMP.text = ScoreValue.ToString();
    }

    public void UpdateScore(int value)
    {
        ScoreValue += value;
        UpdateText();
    }
}
