using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScriptMain : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // scoreText = "SCORE: " + score; // Don't forget ".text"
        // scoreText.text = "SCORE:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }
}
