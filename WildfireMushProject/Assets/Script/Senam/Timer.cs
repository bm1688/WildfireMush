using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    

    [SerializeField] private float timerDuration = 10f;
    public float TimerDuration => timerDuration; 
    private float timer;
    public float currentTime => timer;


    private void Start()
    {
        timer = 0f; 

    }

    private void Update()
    {
        timer += Time.deltaTime; 

        if (timer >= timerDuration)
        {
            Time.timeScale = 0f;
        }
    }
}
