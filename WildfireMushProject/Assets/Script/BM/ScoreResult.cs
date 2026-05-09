using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResult : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    

    [SerializeField] private TextMeshProUGUI _scoreResultText;

    

    
    

    void Start()
    {
        Time.timeScale = 0.0f;
        
        _scoreResultText.text = "Score Result: " + _scoreManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    
}
