using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public static ScoreManager instance;
    [SerializeField] private int score = 0;
    public int Score { get { return score; } }
 


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    public int CurrentScore
    {
        get { return score; }
    }
}
