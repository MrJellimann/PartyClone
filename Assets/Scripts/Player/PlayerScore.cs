using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    public Text scoreText; // Reference to the UI text object to display the score

    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText(); // Update the score text when the game starts
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText(); // Update the score text when the score changes
    }

    public void SubScore(int value)
    {
        if (score - value < 0)
            score = 0;
        else
            score -= value;
        UpdateScoreText(); // Update the score text when the score changes
    }

    public void SetScore(int value)
    {
        score = value;
        UpdateScoreText(); // Update the score text when the score changes
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadBall"))
        {
            SubScore(5);
            Destroy(other.gameObject); // Destroy the BadBall object
        }
        else if (other.gameObject.CompareTag("GoodBall"))
        {
            AddScore(10);
            Destroy(other.gameObject); // Destroy the GoodBall object
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the text of the score text object
    }
}
