using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private int score;

    public void AddScore(int value)
    {
        score += value;
    }

    public void SubScore(int value)
    {
        if (score - value < 0)
            score = 0;
        else
            score -= value;
    }

    public void SetScore(int value)
    {
        score = value;
    }
}
