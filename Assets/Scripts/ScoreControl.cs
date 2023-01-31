using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    
    private TextMeshProUGUI scoretext;
    private int score = 0;
    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    public void increasescore(int increment)
    {
        score += increment;
    }
    private void RefreshUi()
    {
        scoretext.text = "Score : " + score;
    }

    private void Update()
    {
        RefreshUi();
    }



}
