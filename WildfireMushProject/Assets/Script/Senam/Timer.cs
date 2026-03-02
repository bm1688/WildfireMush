using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    

    [SerializeField] private float timerDuration = 10f;
    private float timer;
    [SerializeField] private Slider timeSlider;

    private void Start()
    {
        timer = 0f; 
        timeSlider.maxValue = timerDuration; 
    }

    private void Update()
    {
        timer += Time.deltaTime; 
        timeSlider.value = timer; 
        if (timer >= timerDuration)
        {
            Time.timeScale = 0f;
        }
    }
}
