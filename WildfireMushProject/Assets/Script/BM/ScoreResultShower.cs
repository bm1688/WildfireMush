using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResultShower : MonoBehaviour
{
    [SerializeField] private GameObject _scorePage;

    [SerializeField] private Timer _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer.currentTime >= _timer.TimerDuration)
        {
            _scorePage.SetActive(true);
        }
    }
}
