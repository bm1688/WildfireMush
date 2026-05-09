using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private Timer _timer;

    [SerializeField] private TextMeshProUGUI _scoreResultText;

    [SerializeField] private GameObject _scorePage;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer.currentTime >= _timer.TimerDuration)
        {
            Time.timeScale = 0.0f;
            _scorePage.SetActive(true);
            _scoreResultText.text = "Score Result: " + _scoreManager.Score.ToString();
        }
    }
}
