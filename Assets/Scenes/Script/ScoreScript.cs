using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    private int scoreValue = 0;
    private Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Food Counter:  " + scoreValue;
    }

    public void IncreaseScore()
    {
        scoreValue++;
    }

    public void ResetScore()
    {
        scoreValue = 0;
    }
}

