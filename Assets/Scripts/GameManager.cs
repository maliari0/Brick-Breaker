using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: "+ lives;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        livesText.text = "Lives: " + lives;

        if (lives < 0)
        {
            Debug.Log("Out of lives");
        }
    }

    public void UpdateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }
}
