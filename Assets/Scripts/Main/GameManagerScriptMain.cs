using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScriptMain : MonoBehaviour
{
    public GameObject gameOverText;
    public Text scoreText;
    private int score = 0;
    // private bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // scoreText = "SCORE: " + score; // Don't forget ".text"
        // scoreText.text = "SCORE:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        // if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        
        // When GameOverText appears
        if (gameOverText.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            // isGameOver = false;
            SceneManager.LoadScene("Main");
            
        }
    }

    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    public void GameOver()
    {
        // gameOverText.SetActive(true);
        
        StartCoroutine(DelayMethod(1.5f, () =>
        {
            gameOverText.SetActive(true);
            // isGameOver = true;
        }));
    }
    
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
